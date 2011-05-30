using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Adressegruppe.
    /// </summary>
    public class Adressegruppe
    {
        #region Private variables

        private readonly int _nummer;
        private string _navn;
        private int _adressegruppeOswebdb;

        #endregion

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
            _nummer = nummer;
            _navn = navn;
            _adressegruppeOswebdb = adressegruppeOswebdb;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Nummer på adressegruppen.
        /// </summary>
        public virtual int Nummer
        {
            get
            {
                return _nummer;
            }
        }

        /// <summary>
        /// Navn på adressegruppen.
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

        /// <summary>
        /// Nummer på den tilsvarende adressegruppe i OSWEBDB.
        /// </summary>
        public virtual int AdressegruppeOswebdb
        {
            get
            {
                return _adressegruppeOswebdb;
            }
            protected set
            {
                _adressegruppeOswebdb = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Navn på adressegruppen.
        /// </summary>
        /// <returns>Navn på adressegruppen.</returns>
        public override string ToString()
        {
            return Navn;
        }

        /// <summary>
        /// Opdaterer navnet på adressegruppen.
        /// </summary>
        /// <param name="navn">Navn på adressegruppen.</param>
        public virtual void SætNavn(string navn)
        {
            Navn = navn;
        }

        /// <summary>
        /// Opdaterer nummeret på den tilsvarende adressegruppe i OSWEBDB.
        /// </summary>
        /// <param name="adressegruppeOswebdb">Nummer på den tilsvarende adressegruppe i OSWEBDB.</param>
        public virtual void SætAdressegruppeOswebdb(int adressegruppeOswebdb)
        {
            AdressegruppeOswebdb = adressegruppeOswebdb;
        }

        #endregion
    }
}
