using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
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
        /// <param name="konto">Konto, hvorpå linjen bogføres.</param>
        /// <param name="tekst">Bogføringstekst.</param>
        /// <param name="budgetkonto">Budgetkonto, hvorpå linjen bogføres.</param>
        /// <param name="debit">Debitbeløb.</param>
        /// <param name="kredit">Kreditbeløb.</param>
        public Bogføringslinje(int løbenummer, DateTime dato, string bilag, Konto konto, string tekst, Budgetkonto budgetkonto, double debit, double kredit)
        {
            if (konto == null)
            {
                throw new ArgumentNullException("konto");
            }
            if (string.IsNullOrEmpty(tekst))
            {
                throw new ArgumentNullException("tekst");
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Løbenummer = løbenummer;
            Dato = dato;
            Bilag = bilag;
            Konto = konto;
            Tekst = tekst;
            Budgetkonto = budgetkonto;
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
        public virtual double Debit
        {
            get;
            protected set;
        }

        /// <summary>
        /// Kreditbeløb.
        /// </summary>
        public virtual double Kredit
        {
            get;
            protected set;
        }

        #endregion
    }
}
