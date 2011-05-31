using System;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Bogføringslinje.
    /// </summary>
    public class Bogføringslinje
    {
        #region Private variables

        private readonly int _løbenummer;
        private readonly DateTime _dato;
        private readonly string _bilag;
        private readonly string _tekst;
        private readonly decimal _debit;
        private readonly decimal _kredit;
        private Konto _konto;
        private Budgetkonto _budgetkonto;
        private AdresseBase _adresse;

        #endregion

        #region Constructor

        /// <summary>
        /// Opretter en ny bogføringslinje.
        /// </summary>
        /// <param name="løbenummer">Unik identifikation af bogføringslinjen.</param>
        /// <param name="dato">Bogføringsdato.</param>
        /// <param name="bilag">Bilag.</param>
        /// <param name="tekst">Bogføringstekst.</param>
        /// <param name="debit">Debitbeløb.</param>
        /// <param name="kredit">Kreditbeløb.</param>
        public Bogføringslinje(int løbenummer, DateTime dato, string bilag, string tekst, decimal debit, decimal kredit)
        {
            if (string.IsNullOrEmpty(tekst))
            {
                throw new ArgumentNullException("tekst");
            }
            _løbenummer = løbenummer;
            _dato = dato;
            _bilag = bilag;
            _tekst = tekst;
            _debit = debit;
            _kredit = kredit;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Unik identifikation af bogføringslinjen.
        /// </summary>
        public virtual int Løbenummer
        {
            get
            {
                return _løbenummer;
            }
        }

        /// <summary>
        /// Bogføringsdato.
        /// </summary>
        public virtual DateTime Dato
        {
            get
            {
                return _dato;
            }
        }

        /// <summary>
        /// Bilagsnummer.
        /// </summary>
        public virtual string Bilag
        {
            get
            {
                return _bilag;
            }
        }

        /// <summary>
        /// Konto, hvorpå linjen er bogført.
        /// </summary>
        public virtual Konto Konto
        {
            get
            {
                if (_konto != null)
                {
                    _konto.Calculate(Dato, Løbenummer);
                }
                return _konto;
            }
            protected set
            {
                _konto = value;
            }
        }

        /// <summary>
        /// Bogføringstekst.
        /// </summary>
        public virtual string Tekst
        {
            get
            {
                return _tekst;
            }
        }

        /// <summary>
        /// Budgetkonto, hvorpå linjen er bogført.
        /// </summary>
        public virtual Budgetkonto Budgetkonto
        {
            get
            {
                if (_budgetkonto != null)
                {
                    _budgetkonto.Calculate(Dato, Løbenummer);
                }
                return _budgetkonto;
            }
            protected set
            {
                _budgetkonto = value;
            }
        }

        /// <summary>
        /// Debitbeløb.
        /// </summary>
        public virtual decimal Debit
        {
            get
            {
                return _debit;
            }
        }

        /// <summary>
        /// Kreditbeløb.
        /// </summary>
        public virtual decimal Kredit
        {
            get
            {
                return _kredit;
            }
        }

        /// <summary>
        /// Adresse, som linjen er bogført til.
        /// </summary>
        public virtual AdresseBase Adresse
        {
            get
            {
                if (_adresse != null)
                {
                    _adresse.Calculate(Dato, Løbenummer);
                }
                return _adresse;
            }
            protected set
            {
                _adresse = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tekst for bogføringslinje.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Tekst)
                       ? Dato.ToShortDateString()
                       : string.Format("{0} {1}", Dato.ToShortDateString(), Tekst);
        }

        /// <summary>
        /// Sætter konto, hvorpå linjen er bogført.
        /// </summary>
        /// <param name="konto">Konto.</param>
        internal virtual void SætKonto(Konto konto)
        {
            if (konto == null)
            {
                throw new ArgumentNullException("konto");
            }
            Konto = konto;
        }

        /// <summary>
        /// Sætter budgetkonti, hvorpå linjen er bogført.
        /// </summary>
        /// <param name="budgetkonto">Budgetkonto.</param>
        internal virtual void SætBudgetkonto(Budgetkonto budgetkonto)
        {
            if (budgetkonto == null)
            {
                throw new ArgumentNullException("budgetkonto");
            }
            Budgetkonto = budgetkonto;
        }

        /// <summary>
        /// Sætter adresse, som linjen er bogført til.
        /// </summary>
        /// <param name="adresse">Adresse.</param>
        internal virtual void SætAdresse(AdresseBase adresse)
        {
            if (adresse == null)
            {
                throw new ArgumentNullException("adresse");
            }
            Adresse = adresse;
        }

        #endregion
    }
}
