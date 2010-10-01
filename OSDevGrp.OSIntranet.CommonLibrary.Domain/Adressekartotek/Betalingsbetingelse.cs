using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Betalingsbetingelse.
    /// </summary>
    public class Betalingsbetingelse
    {
        #region Constructor

        public Betalingsbetingelse(int nummer, string navn)
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
        /// Nummer på betalingsbetingelsen.
        /// </summary>
        public virtual int Nummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Navn på betalingsbetingelsen.
        /// </summary>
        public virtual string Navn
        {
            get;
            protected set;
        }

        #endregion
    }
}
