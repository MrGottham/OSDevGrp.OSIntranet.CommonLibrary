using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Konto.
    /// </summary>
    public class Konto : KontoBase, ICalculatable
    {
        #region Private variables

        private readonly IList<Kreditoplysninger> _kreditoplysninger = new List<Kreditoplysninger>();
        private readonly IList<Bogføringslinje> _bogføringslinjer = new List<Bogføringslinje>();
        private Kontogruppe _kontogruppe;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en ny konto.
        /// </summary>
        /// <param name="regnskab">Regnskab, som kontoen er tilknyttet.</param>
        /// <param name="kontonummer">Kontonummer.</param>
        /// <param name="kontonavn">Navn på kontoen.</param>
        /// <param name="kontogruppe">Kontogruppe.</param>
        public Konto(Regnskab regnskab, string kontonummer, string kontonavn, Kontogruppe kontogruppe)
            : base(regnskab, kontonummer, kontonavn)
        {
            if (kontogruppe == null)
            {
                throw new ArgumentNullException("kontogruppe");
            }
            _kontogruppe = kontogruppe;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Kontogruppe.
        /// </summary>
        public virtual Kontogruppe Kontogruppe
        {
            get
            {
                return _kontogruppe;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _kontogruppe = value;
            }
        }

        /// <summary>
        /// Kredit pr. statusdato (beregnes ved hjælp af metoden Calculate).
        /// </summary>
        public virtual decimal KreditPrStatusdato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Saldo pr. statusdato (beregnes ved hjælp af metoden Calculate).
        /// </summary>
        public virtual decimal SaldoPrStatusdato
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
                return KreditPrStatusdato + SaldoPrStatusdato;
            }
        }

        /// <summary>
        /// Kreditoplysninger.
        /// </summary>
        public virtual IEnumerable<Kreditoplysninger> Kreditoplysninger
        {
            get
            {
                var comparer = new MånedsoplysningerComparer();
                return new ReadOnlyCollection<Kreditoplysninger>(_kreditoplysninger
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
            // Beregn kredit pr. statusdato.
            var kreditoplysninger = Kreditoplysninger
                .SingleOrDefault(m => m.År == statusDato.Year && m.Måned == statusDato.Month);
            KreditPrStatusdato = kreditoplysninger == null ? 0M : kreditoplysninger.Kredit;
            // Beregn saldo pr. statusdato.
            SaldoPrStatusdato = Bogføringslinjer
                .Where(m => m.Løbenummer <= løbenr && m.Dato.CompareTo(statusDato) <= 0)
                .Sum(m => m.Debit - m.Kredit);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opdaterer kontogruppe.
        /// </summary>
        /// <param name="kontogruppe">Kontogruppe.</param>
        public virtual void SætKontogruppe(Kontogruppe kontogruppe)
        {
            Kontogruppe = kontogruppe;
        }

        /// <summary>
        /// Tilføjer kreditoplysinger.
        /// </summary>
        /// <param name="kreditoplysninger">Kreditoplysninger.</param>
        public virtual void TilføjKreditoplysninger(Kreditoplysninger kreditoplysninger)
        {
            if (kreditoplysninger == null)
            {
                throw new ArgumentNullException("kreditoplysninger");
            }
            kreditoplysninger.SætKonto(this);
            _kreditoplysninger.Add(kreditoplysninger);
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
            bogføringslinje.SætKonto(this);
            _bogføringslinjer.Add(bogføringslinje);
        }

        #endregion
    }
}
