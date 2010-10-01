using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Person.
    /// </summary>
    public class Person : AdresseBase
    {
        #region Constructor

        /// <summary>
        /// Danner en ny person.
        /// </summary>
        /// <param name="nummer">Unik identifikation af personen.</param>
        /// <param name="navn">Navn på personen.</param>
        /// <param name="adressegruppe">Adressegruppe.</param>
        public Person(int nummer, string navn, Adressegruppe adressegruppe)
            : base(nummer, navn, adressegruppe)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Telefonnummer.
        /// </summary>
        public virtual string Telefon
        {
            get
            {
                return Telefon1;
            }
        }

        /// <summary>
        /// Mobilnummer.
        /// </summary>
        public virtual string Mobil
        {
            get
            {
                return Telefon2;
            }
        }

        /// <summary>
        /// Fødselsdato.
        /// </summary>
        public virtual DateTime? Fødselsdato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Firma, som personen er tilknyttet.
        /// </summary>
        public virtual Firma Firma
        {
            get;
            protected set;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sætter telefonnumre.
        /// </summary>
        /// <param name="telefon">Telefonnummer.</param>
        /// <param name="mobil">Mobilnummer.</param>
        public virtual void SætTelefon(string telefon, string mobil)
        {
            SætTelefon(telefon, mobil, null);
        }

        /// <summary>
        /// Sætter fødselsdato.
        /// </summary>
        /// <param name="fødselsdato">Fødselsdato.</param>
        public virtual void SætFødselsdato(DateTime? fødselsdato)
        {
            Fødselsdato = fødselsdato;
        }

        /// <summary>
        /// Sætter firma.
        /// </summary>
        /// <param name="firma">Firma.</param>
        internal virtual void SætFirma(Firma firma)
        {
            if (firma == null)
            {
                throw new ArgumentNullException("firma");
            }
            Firma = firma;
        }

        #endregion
    }
}
