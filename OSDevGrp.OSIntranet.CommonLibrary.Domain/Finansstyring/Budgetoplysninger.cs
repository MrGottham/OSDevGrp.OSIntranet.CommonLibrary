using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Budgetoplysinger for en måned i et givent år.
    /// </summary>
    public class Budgetoplysninger : Månedsoplysninger
    {
        #region Constructor

        /// <summary>
        /// Danner nye budgetoplysinger.
        /// </summary>
        /// <param name="år">Årstal.</param>
        /// <param name="måned">Måned.</param>
        /// <param name="indtægter">Indtægter.</param>
        /// <param name="udgifter">Udgifter.</param>
        public Budgetoplysninger(int år, int måned, decimal indtægter, decimal udgifter)
            : base(år, måned)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Indtægter = indtægter;
            Udgifter = udgifter;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Budgetkonto, som budgetoplysningerne er tilknyttet.
        /// </summary>
        public virtual Budgetkonto Budgetkonto
        {
            get;
            protected set;
        }

        /// <summary>
        /// Indtægter.
        /// </summary>
        public virtual decimal Indtægter
        {
            get;
            protected set;
        }

        /// <summary>
        /// Udgifter.
        /// </summary>
        public virtual decimal Udgifter
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sætter budgetkonto for budgetoplysningerne.
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

        #endregion
    }
}
