using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
{
    /// <summary>
    /// Konto.
    /// </summary>
    public class Konto : KontoBase
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
        /// Kreditoplysninger.
        /// </summary>
        public virtual IList<Kreditoplysninger> Kreditoplysninger
        {
            get
            {
                return new ReadOnlyCollection<Kreditoplysninger>(_kreditoplysninger);
            }
        }

        /// <summary>
        /// Bogføringslinjer.
        /// </summary>
        public virtual IList<Bogføringslinje> Bogføringslinjer
        {
            get
            {
                return new ReadOnlyCollection<Bogføringslinje>(_bogføringslinjer);
            }
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
