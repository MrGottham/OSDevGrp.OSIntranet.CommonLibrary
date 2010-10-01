using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Adressegruppe.
    /// </summary>
    public class Adressegruppe
    {
        #region Constructor

        /// <summary>
        /// Danner adressegruppe.
        /// </summary>
        /// <param name="nummer">Nummer på adressegruppen.</param>
        /// <param name="navn">Navn på adressegruppen.</param>
        /// <param name="adressegruppeOswebdb">Nummer på den tilsvarende adressegruppe i OSWEBDB.</param>
        public Adressegruppe(int nummer, string navn, int adressegruppeOswebdb)
        {
            if (string.IsNullOrEmpty(navn))
            {
                throw new ArgumentNullException("navn");
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Nummer = nummer;
            Navn = navn;
            AdressegruppeOswebdb = adressegruppeOswebdb;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Nummer på adressegruppen.
        /// </summary>
        public virtual int Nummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Navn på adressegruppen.
        /// </summary>
        public virtual string Navn
        {
            get;
            protected set;
        }

        /// <summary>
        /// Nummer på den tilsvarende adressegruppe i OSWEBDB.
        /// </summary>
        public virtual int AdressegruppeOswebdb
        {
            get;
            protected set;
        }

        #endregion
    }
}
