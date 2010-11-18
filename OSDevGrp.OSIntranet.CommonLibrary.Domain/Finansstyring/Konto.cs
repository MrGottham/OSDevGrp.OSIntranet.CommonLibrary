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
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Kontogruppe = kontogruppe;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Kontogruppe.
        /// </summary>
        public virtual Kontogruppe Kontogruppe
        {
            get;
            protected set;
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
        /// Kreditoplysninger.
        /// </summary>
        public virtual IList<Kreditoplysninger> Kreditoplysninger
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
        public virtual IList<Bogføringslinje> Bogføringslinjer
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
        /// Kalkulering af status på en givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        public virtual void Calculate(DateTime statusDato)
        {
            // Beregn kredit pr. statusdato.
            var kreditoplysninger = Kreditoplysninger
                .SingleOrDefault(m => m.År == statusDato.Year && m.Måned == statusDato.Month);
            KreditPrStatusdato = kreditoplysninger == null ? 0M : kreditoplysninger.Kredit;
            // Beregn saldo pr. statusdato.
            SaldoPrStatusdato = Bogføringslinjer
                .Where(m => m.Dato.CompareTo(statusDato) <= 0)
                .Sum(m => m.Debit - m.Kredit);
        }

        #endregion

        #region Methods

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
