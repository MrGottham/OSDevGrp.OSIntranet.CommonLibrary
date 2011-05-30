using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Betalingsbetingelse.
    /// </summary>
    public class Betalingsbetingelse
    {
        #region Private variables

        private readonly int _nummer;
        private string _navn;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en betalingsbetingelse.
        /// </summary>
        /// <param name="nummer">Nummer på betalingsbetingelsen</param>
        /// <param name="navn">Navn på betalingsbetingelsen.</param>
        public Betalingsbetingelse(int nummer, string navn)
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
        /// Nummer på betalingsbetingelsen.
        /// </summary>
        public virtual int Nummer
        {
            get
            {
                return _nummer;
            }
        }

        /// <summary>
        /// Navn på betalingsbetingelsen.
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
        /// Navn på betalingsbetingelse.
        /// </summary>
        /// <returns>Navn på betalingsbetingelse.</returns>
        public override string ToString()
        {
            return Navn;
        }

        /// <summary>
        /// Opdaterer navnet på betalingsbetingelsen.
        /// </summary>
        /// <param name="navn">Navn på betalingsbetingelsen.</param>
        public virtual void SætNavn(string navn)
        {
            Navn = navn;
        }


        #endregion
    }
}
