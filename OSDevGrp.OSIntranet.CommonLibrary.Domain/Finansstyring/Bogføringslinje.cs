using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Bogføringslinje.
    /// </summary>
    public class Bogføringslinje
    {
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
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Løbenummer = løbenummer;
            Dato = dato;
            Bilag = bilag;
            Tekst = tekst;
            Debit = debit;
            Kredit = kredit;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Unik identifikation af bogføringslinjen.
        /// </summary>
        public virtual int Løbenummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Bogføringsdato.
        /// </summary>
        public virtual DateTime Dato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Bilagsnummer.
        /// </summary>
        public virtual string Bilag
        {
            get;
            protected set;
        }

        /// <summary>
        /// Konto, hvorpå linjen er bogført.
        /// </summary>
        public virtual Konto Konto
        {
            get;
            protected set;
        }

        /// <summary>
        /// Bogføringstekst.
        /// </summary>
        public virtual string Tekst
        {
            get;
            protected set;
        }

        /// <summary>
        /// Budgetkonto, hvorpå linjen er bogført.
        /// </summary>
        public virtual Budgetkonto Budgetkonto
        {
            get;
            protected set;
        }

        /// <summary>
        /// Debitbeløb.
        /// </summary>
        public virtual decimal Debit
        {
            get;
            protected set;
        }

        /// <summary>
        /// Kreditbeløb.
        /// </summary>
        public virtual decimal Kredit
        {
            get;
            protected set;
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
        /// <param name="budgetkonto"></param>
        internal virtual void SætBudgetkonto(Budgetkonto budgetkonto)
        {
            if (budgetkonto == null)
            {
                throw new ArgumentNullException("budgetkonto");
            }
            Budgetkonto = budgetkonto;
        }

        #endregion
    }
}
