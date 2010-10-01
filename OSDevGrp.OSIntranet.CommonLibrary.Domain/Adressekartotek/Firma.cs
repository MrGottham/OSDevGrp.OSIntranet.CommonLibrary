using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Firma.
    /// </summary>
    public class Firma : AdresseBase
    {
        #region Private variables

        private readonly IList<Person> _personer = new List<Person>();

        #endregion

        #region Constructor

        /// <summary>
        /// Danner et nyt firma.
        /// </summary>
        /// <param name="nummer">Unik identifikation af firmaet.</param>
        /// <param name="navn">Navn på firmaet.</param>
        /// <param name="adressegruppe">Adressegruppe.</param>
        public Firma(int nummer, string navn, Adressegruppe adressegruppe)
            : base(nummer, navn, adressegruppe)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Telefon (1. nummer).
        /// </summary>
        public virtual new string Telefon1
        {
            get
            {
                return base.Telefon1;
            }
        }

        /// <summary>
        /// Telefon (2. nummer).
        /// </summary>
        public virtual new string Telefon2
        {
            get
            {
                return base.Telefon2;
            }
        }

        /// <summary>
        /// Telefax.
        /// </summary>
        public virtual string Telefax
        {
            get
            {
                return Telefon3;
            }
        }

        /// <summary>
        /// Personer, som er tilknyttet firmaet.
        /// </summary>
        public virtual IList<Person> Personer
        {
            get
            {
                return new ReadOnlyCollection<Person>(_personer);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sætter telefonnumre.
        /// </summary>
        /// <param name="telefon1">Telefon (1. nummer).</param>
        /// <param name="telefon2">Telefon (2. nummer).</param>
        /// <param name="telefax">Telefax.</param>
        public virtual new void SætTelefon(string telefon1, string telefon2, string telefax)
        {
            base.SætTelefon(telefon1, telefon2, telefax);
        }

        /// <summary>
        /// Tilføjer en person til firmaet.
        /// </summary>
        /// <param name="person">Person.</param>
        public virtual void TilføjPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            person.SætFirma(this);
            _personer.Add(person);
        }

        #endregion
    }
}
