using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Basisklasse for en kontogruppe.
    /// </summary>
    public abstract class KontogruppeBase
    {
        #region Constructor

        /// <summary>
        /// Danner en ny kontogruppe.
        /// </summary>
        /// <param name="nummer">Nummer på kontogruppen.</param>
        /// <param name="navn">Navn på kontogruppen.</param>
        protected KontogruppeBase(int nummer, string navn)
        {
            if (string.IsNullOrEmpty(navn))
            {
                throw new ArgumentNullException("navn");
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Nummer = nummer;
            Navn = navn;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Nummer på kontogruppen.
        /// </summary>
        public virtual int Nummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Navn på kontogruppen.
        /// </summary>
        public virtual string Navn
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Navn på kontogruppen.
        /// </summary>
        /// <returns>Navn på kontogruppen.</returns>
        public override string ToString()
        {
            return Navn;
        }

        #endregion
    }
}
