using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Basisklasse for en kontogruppe.
    /// </summary>
    public abstract class KontogruppeBase
    {
        #region Private variables

        private readonly int _nummer;
        private string _navn;

        #endregion

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
            _nummer = nummer;
            _navn = navn;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Nummer på kontogruppen.
        /// </summary>
        public virtual int Nummer
        {
            get
            {
                return _nummer;
            }
        }

        /// <summary>
        /// Navn på kontogruppen.
        /// </summary>
        public virtual string Navn
        {
            get
            {
                return _navn;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _navn = value;
            }
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

        /// <summary>
        /// Opdaterer navnet på kontogruppen.
        /// </summary>
        /// <param name="navn">Navn på kontogruppen.</param>
        public virtual void SætNavn(string navn)
        {
            Navn = navn;
        }

        #endregion
    }
}
