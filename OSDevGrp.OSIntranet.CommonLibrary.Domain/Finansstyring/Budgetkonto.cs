using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Budgetkonto.
    /// </summary>
    public class Budgetkonto : KontoBase, ICalculatable
    {
        #region Private variables

        private readonly IList<Budgetoplysninger> _budgetoplysninger = new List<Budgetoplysninger>();
        private readonly IList<Bogføringslinje> _bogføringslinjer = new List<Bogføringslinje>();
        private Budgetkontogruppe _budgetkontogruppe;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en ny budgetkonto.
        /// </summary>
        /// <param name="regnskab">Regnskab, som budgetkontoen er tilknyttet.</param>
        /// <param name="budgetkontonummer">Kontonummer for budgetkontoen.</param>
        /// <param name="budgetkontonavn">Navn på budgetkontoen.</param>
        /// <param name="budgetkontogruppe">Budgetkontogruppe for budgetkontoen.</param>
        public Budgetkonto(Regnskab regnskab, string budgetkontonummer, string budgetkontonavn, Budgetkontogruppe budgetkontogruppe)
            : base(regnskab, budgetkontonummer, budgetkontonavn)
        {
            if (budgetkontogruppe == null)
            {
                throw new ArgumentException("budgetkontogruppe");
            }
            _budgetkontogruppe = budgetkontogruppe;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Budgetkontogruppe.
        /// </summary>
        public virtual Budgetkontogruppe Budgetkontogruppe
        {
            get
            {
                return _budgetkontogruppe;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _budgetkontogruppe = value;
            }
        }

        /// <summary>
        /// Budget pr. statusdato (beregnes ved hjælp af metoden Calculate).
        /// </summary>
        public virtual decimal BudgetPrStatusdato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Bogført beløb pr. statusdato (beregnes ved hjælp af metoden Calculate).
        /// </summary>
        public virtual decimal BogførtPrStatusdato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Disponibel beløb pr. statusdato (beregnes ved hjælp af metoden Calculate).
        /// </summary>
        public virtual decimal DisponibelPrStatusdato
        {
            get
            {
                if (BudgetPrStatusdato < 0 || BogførtPrStatusdato < 0)
                {
                    return Math.Abs(BudgetPrStatusdato) - Math.Abs(BogførtPrStatusdato);
                }
                return 0;
            }
        }

        /// <summary>
        /// Budgetoplysninger.
        /// </summary>
        public virtual IEnumerable<Budgetoplysninger> Budgetoplysninger
        {
            get
            {
                var comparer = new MånedsoplysningerComparer();
                return new ReadOnlyCollection<Budgetoplysninger>(_budgetoplysninger
                                                                     .OrderByDescending(m => m, comparer)
                                                                     .ToArray());
            }
        }

        /// <summary>
        /// Bogføringslinjer.
        /// </summary>
        public virtual IEnumerable<Bogføringslinje> Bogføringslinjer
        {
            get
            {
                var comparer = new BogføringslinjeComparer();
                return new ReadOnlyCollection<Bogføringslinje>(_bogføringslinjer
                                                                   .OrderByDescending(m => m, comparer)
                                                                   .ToArray());
            }
        }

        #endregion

        #region ICalculatable Members

        /// <summary>
        /// Kalkulering af status på et givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        public virtual void Calculate(DateTime statusDato)
        {
            Calculate(statusDato, int.MaxValue);
        }

        /// <summary>
        /// Kalkulering af status på et givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        /// <param name="løbenr">Den unikke identifikation af bogføringslinjen, som indgår i beregningen.</param>
        public virtual void Calculate(DateTime statusDato, int løbenr)
        {
            foreach (var budgetoplysninger in Budgetoplysninger)
            {
                if (budgetoplysninger.År > statusDato.Year || (budgetoplysninger.År == statusDato.Year && budgetoplysninger.Måned > statusDato.Month))
                {
                    budgetoplysninger.SætBogførtPrStatusdato(0);
                    continue;
                }
                var fraDato = new DateTime(budgetoplysninger.År, budgetoplysninger.Måned, 1);
                if (budgetoplysninger.År == statusDato.Year && budgetoplysninger.Måned == statusDato.Month)
                {
                    budgetoplysninger.SætBogførtPrStatusdato(CalculateBogført(fraDato, statusDato, løbenr));
                    continue;
                }
                var tilDato = new DateTime(budgetoplysninger.År, budgetoplysninger.Måned, DateTime.DaysInMonth(budgetoplysninger.År, budgetoplysninger.Måned));
                budgetoplysninger.SætBogførtPrStatusdato(CalculateBogført(fraDato, tilDato, løbenr));
            }
            var aktuelBudgetoplysninger = Budgetoplysninger.SingleOrDefault(m => m.År == statusDato.Year && m.Måned == statusDato.Month);
            BudgetPrStatusdato = aktuelBudgetoplysninger == null ? 0M : aktuelBudgetoplysninger.Budget;
            BogførtPrStatusdato = aktuelBudgetoplysninger == null ? CalculateBogført(new DateTime(statusDato.Year, statusDato.Month, 1), statusDato, løbenr) : aktuelBudgetoplysninger.BogførtPrStatusdato;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Opdaterer budgetkontogruppe.
        /// </summary>
        /// <param name="budgetkontogruppe">Budgetkontogruppe.</param>
        public virtual void SætBudgetkontogruppe(Budgetkontogruppe budgetkontogruppe)
        {
            Budgetkontogruppe = budgetkontogruppe;
        }

        /// <summary>
        /// Tilføjer budgetoplysinger.
        /// </summary>
        /// <param name="budgetoplysninger">Budgetoplysninger.</param>
        public virtual void TilføjBudgetoplysninger(Budgetoplysninger budgetoplysninger)
        {
            if (budgetoplysninger == null)
            {
                throw new ArgumentNullException("budgetoplysninger");
            }
            budgetoplysninger.SætBudgetkonto(this);
            _budgetoplysninger.Add(budgetoplysninger);
        }

        /// <summary>
        /// Tilføjer en bogføringslinje.
        /// </summary>
        /// <param name="bogføringslinje">Bogføringslinje.</param>
        public virtual void TilføjBogføringslinje(Bogføringslinje bogføringslinje)
        {
            if (bogføringslinje == null)
            {
                throw new ArgumentNullException("bogføringslinje");
            }
            bogføringslinje.SætBudgetkonto(this);
            _bogføringslinjer.Add(bogføringslinje);
        }

        /// <summary>
        /// Beregner, hvad der er bogført i en given periode.
        /// </summary>
        /// <param name="fraDato">Fra dato.</param>
        /// <param name="tilDato">Til dato.</param>
        /// <param name="løbenr">Den unikke identifikation af bogføringslinjen, som indgår i beregningen.</param>
        /// <returns>Beløbet der er bogført i perioden.</returns>
        private decimal CalculateBogført(DateTime fraDato, DateTime tilDato, int løbenr)
        {
            return Bogføringslinjer
                .Where(m =>
                       m.Dato.Date.CompareTo(fraDato.Date) >= 0 &&
                       (m.Dato.Date.CompareTo(tilDato.Date) < 0 ||
                        (m.Dato.Date.CompareTo(tilDato.Date) == 0 && m.Løbenummer <= løbenr)))
                .Sum(m => m.Debit - m.Kredit);
        }

        #endregion
    }
}
