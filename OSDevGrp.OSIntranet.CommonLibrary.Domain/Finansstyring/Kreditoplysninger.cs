using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Kreditoplysninger for en måned i et givent år.
    /// </summary>
    public class Kreditoplysninger : Månedsoplysninger
    {
        #region Private variables

        private decimal _kredit;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner nye kreditoplysinger.
        /// </summary>
        /// <param name="år">Årstal.</param>
        /// <param name="måned">Måned.</param>
        /// <param name="kredit">Kredit.</param>
        public Kreditoplysninger(int år, int måned, decimal kredit) : base(år, måned)
        {
            _kredit = kredit;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Konto, som kreditoplysningerne er tilknyttet.
        /// </summary>
        public virtual Konto Konto
        {
            get;
            protected set;
        }

        /// <summary>
        /// Kredit.
        /// </summary>
        public virtual decimal Kredit
        {
            get
            {
                return _kredit;
            }
            protected set
            {
                _kredit = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sætter konto for kreditoplysninger.
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
        /// Opdaterer kredit.
        /// </summary>
        /// <param name="kredit">Kredit.</param>
        public virtual void SætKredit(decimal kredit)
        {
            Kredit = kredit;
        }

        #endregion 
    }
}
