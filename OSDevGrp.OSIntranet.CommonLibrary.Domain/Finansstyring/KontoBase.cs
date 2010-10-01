using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
{
    /// <summary>
    /// Basisklasse for en konto.
    /// </summary>
    public abstract class KontoBase
    {
        #region Constructor

        /// <summary>
        /// Dannner en ny konto.
        /// </summary>
        /// <param name="regnskab">Regnskab, som kontoen er tilknyttet.</param>
        /// <param name="kontonummer">Kontonummer.</param>
        /// <param name="kontonavn">Kontonavn</param>
        protected KontoBase(Regnskab regnskab, string kontonummer, string kontonavn)
        {
            if (regnskab == null)
            {
                throw new ArgumentNullException("regnskab");
            }
            if (string.IsNullOrEmpty(kontonummer))
            {
                throw new ArgumentNullException("kontonummer");
            }
            if (string.IsNullOrEmpty(kontonavn))
            {
                throw new ArgumentNullException("kontonavn");
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Regnskab = regnskab;
            Kontonummer = kontonummer;
            Kontonavn = kontonavn;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Regnskab, som kontoen er tilknyttet.
        /// </summary>
        public virtual Regnskab Regnskab
        {
            get;
            protected set;
        }

        /// <summary>
        /// Kontonummer.
        /// </summary>
        public virtual string Kontonummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Kontonavn.
        /// </summary>
        public virtual string Kontonavn
        {
            get;
            protected set;
        }

        /// <summary>
        /// Beskrivelse.
        /// </summary>
        public virtual string Beskrivelse
        {
            get;
            protected set;
        }

        /// <summary>
        /// Notat.
        /// </summary>
        public virtual string Note
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sætter beskrivelsen på kontoen.
        /// </summary>
        /// <param name="beskrivelse">Beskrivelse.</param>
        public virtual void SætBeskrivelse(string beskrivelse)
        {
            Beskrivelse = beskrivelse;
        }

        /// <summary>
        /// Sætter notat på kontoen.
        /// </summary>
        /// <param name="notat">Notat.</param>
        public virtual void SætNote(string notat)
        {
            Note = notat;
        }

        #endregion
    }
}
