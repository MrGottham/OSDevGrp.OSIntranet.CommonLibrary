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

        #endregion
    }
}
