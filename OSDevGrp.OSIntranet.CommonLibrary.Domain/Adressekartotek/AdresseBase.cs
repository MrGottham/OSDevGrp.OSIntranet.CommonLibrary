using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Basisklasse for en adresse.
    /// </summary>
    public abstract class AdresseBase
    {
        #region Constructor

        /// <summary>
        /// Danner en ny adresse.
        /// </summary>
        /// <param name="nummer">Unik identifikation af adressen.</param>
        /// <param name="navn">Navn.</param>
        /// <param name="adressegruppe">Adressegruppe.</param>
        protected AdresseBase(int nummer, string navn, Adressegruppe adressegruppe)
        {
            if (navn == null)
            {
                throw new ArgumentNullException("navn");
            }
            if (adressegruppe == null)
            {
                throw new ArgumentNullException("adressegruppe");
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Nummer = nummer;
            Navn = navn;
            Adressegruppe = adressegruppe;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Unik identifikation af adressen.
        /// </summary>
        public virtual int Nummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Navn.
        /// </summary>
        public virtual string Navn
        {
            get;
            protected set;
        }

        /// <summary>
        /// Adresse (linje 1).
        /// </summary>
        public virtual string Adresse1
        {
            get;
            protected set;
        }

        /// <summary>
        /// Adresse (linje 2).
        /// </summary>
        public virtual string Adresse2
        {
            get;
            protected set;
        }

        /// <summary>
        /// Postnummer og by.
        /// </summary>
        public virtual string PostnrBy
        {
            get;
            protected set;
        }

        /// <summary>
        /// Telefon (1. nummer).
        /// </summary>
        protected virtual string Telefon1
        {
            get;
            set;
        }

        /// <summary>
        /// Telefon (2. nummer).
        /// </summary>
        protected virtual string Telefon2
        {
            get;
            set;
        }

        /// <summary>
        /// Telefon (3. nummer).
        /// </summary>
        protected virtual string Telefon3
        {
            get;
            set;
        }

        /// <summary>
        /// Adressegruppe.
        /// </summary>
        public virtual Adressegruppe Adressegruppe
        {
            get;
            protected set;
        }

        /// <summary>
        /// Bekendtskab.
        /// </summary>
        public virtual string Bekendtskab
        {
            get;
            protected set;
        }

        /// <summary>
        /// Mailadresse.
        /// </summary>
        public virtual string Mailadresse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Webadresse.
        /// </summary>
        public virtual string Webadresse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Betalingsbetingelse.
        /// </summary>
        public virtual Betalingsbetingelse Betalingsbetingelse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Udlånsfrist.
        /// </summary>
        public virtual int Udlånsfrist
        {
            get;
            protected set;
        }

        /// <summary>
        /// Adresselabel til Filofix kalender.
        /// </summary>
        public virtual bool FilofaxAdresselabel
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Navn på adressen.
        /// </summary>
        /// <returns>Navn på adressen.</returns>
        public override string ToString()
        {
            return Navn;
        }

        /// <summary>
        /// Sætter adresseoplysninger.
        /// </summary>
        /// <param name="adresse1">Adresse (linje 1).</param>
        /// <param name="adresse2">Adresse (linje 2).</param>
        /// <param name="postnrBy">Postnummer og by.</param>
        public virtual void SætAdresseoplysninger(string adresse1, string adresse2, string postnrBy)
        {
            Adresse1 = adresse1;
            Adresse2 = adresse2;
            PostnrBy = postnrBy;
        }

        /// <summary>
        /// Sætter telefonnumre.
        /// </summary>
        /// <param name="telefon1">Telefon (1. nummer).</param>
        /// <param name="telefon2">Telefon (2. nummer).</param>
        /// <param name="telefon3">Telefon (3. nummer).</param>
        protected virtual void SætTelefon(string telefon1, string telefon2, string telefon3)
        {
            Telefon1 = telefon1;
            Telefon2 = telefon2;
            Telefon3 = telefon3;
        }

        /// <summary>
        /// Sætter bekendtskab.
        /// </summary>
        /// <param name="bekendtskab">Bekendtskab.</param>
        public virtual void SætBekendtskab(string bekendtskab)
        {
            Bekendtskab = bekendtskab;
        }

        /// <summary>
        /// Sætter mailadresse.
        /// </summary>
        /// <param name="mailadresse">Mailadresse.</param>
        public virtual void SætMailadresse(string mailadresse)
        {
            Mailadresse = mailadresse;
        }

        /// <summary>
        /// Sætter webadresse.
        /// </summary>
        /// <param name="webadresse">Webadresse.</param>
        public virtual void SætWebadresse(string webadresse)
        {
            Webadresse = webadresse;
        }

        /// <summary>
        /// Sætter betalingsbetingelse.
        /// </summary>
        /// <param name="betalingsbetingelse">Betalingsbetingelse.</param>
        public virtual void SætBetalingsbetingelse(Betalingsbetingelse betalingsbetingelse)
        {
            Betalingsbetingelse = betalingsbetingelse;
        }

        /// <summary>
        /// Sætter udlånsfrist.
        /// </summary>
        /// <param name="udlånsfrist">Udlånsfrist-</param>
        public virtual void SætUdlånsfrist(int udlånsfrist)
        {
            Udlånsfrist = udlånsfrist;
        }

        /// <summary>
        /// Sætter adresselabel til Filofax kalender.
        /// </summary>
        /// <param name="filofaxAdresselabel">Angivelse af adresselabel til Filofax kalender.</param>
        public virtual void SætFilofaxAdresselabel(bool filofaxAdresselabel)
        {
            FilofaxAdresselabel = filofaxAdresselabel;
        }

        #endregion
    }
}
