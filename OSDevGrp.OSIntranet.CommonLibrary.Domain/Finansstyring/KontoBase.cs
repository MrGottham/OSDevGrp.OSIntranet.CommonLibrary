using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Basisklasse for en konto.
    /// </summary>
    public abstract class KontoBase
    {
        #region Private variables

        private readonly Regnskab _regnskab;
        private readonly string _kontonummer;
        private string _kontonavn;

        #endregion

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
            _regnskab = regnskab;
            _kontonummer = kontonummer;
            _kontonavn = kontonavn;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Regnskab, som kontoen er tilknyttet.
        /// </summary>
        public virtual Regnskab Regnskab
        {
            get
            {
                return _regnskab;
            }
        }

        /// <summary>
        /// Kontonummer.
        /// </summary>
        public virtual string Kontonummer
        {
            get
            {
                return _kontonummer;
            }
        }

        /// <summary>
        /// Kontonavn.
        /// </summary>
        public virtual string Kontonavn
        {
            get
            {
                return _kontonavn;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _kontonavn = value.ToUpper();
            }
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
        /// Tekst for konto.
        /// </summary>
        /// <returns>Tekst for konto.</returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Kontonummer) && !string.IsNullOrEmpty(Kontonavn))
            {
                return string.Format("{0} {1}", Kontonummer, Kontonavn);
            }
            return string.IsNullOrEmpty(Kontonavn) ? string.Empty : Kontonavn;
        }

        /// <summary>
        /// Opdaterer kontonavn.
        /// </summary>
        /// <param name="kontonavn">Kontonavn.</param>
        public virtual void SætKontonavn(string kontonavn)
        {
            Kontonavn = kontonavn;
        }

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
