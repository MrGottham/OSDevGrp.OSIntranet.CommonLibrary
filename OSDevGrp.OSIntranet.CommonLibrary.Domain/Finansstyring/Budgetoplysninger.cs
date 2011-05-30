using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Budgetoplysinger for en måned i et givent år.
    /// </summary>
    public class Budgetoplysninger : Månedsoplysninger
    {
        #region Private variables

        private decimal _indtægter;
        private decimal _udgifter;

        #endregion

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
            _indtægter = indtægter;
            _udgifter = udgifter;
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
            get
            {
                return _indtægter;
            }
            protected set
            {
                _indtægter = value;
            }
        }

        /// <summary>
        /// Udgifter.
        /// </summary>
        public virtual decimal Udgifter
        {
            get
            {
                return _udgifter;
            }
            protected set
            {
                _udgifter = value;
            }
        }

        /// <summary>
        /// Budget.
        /// </summary>
        public virtual decimal Budget
        {
            get
            {
                return Indtægter - Udgifter;
            }
        }

        /// <summary>
        /// Bogført beløb pr. statusdato (beregnes ved hjælp af metoden Calculate på en budgetkonto).
        /// </summary>
        public virtual decimal BogførtPrStatusdato
        {
            get;
            protected set;
        }

        /// <summary>
        /// Disponibel beløb pr. statusdato (beregnes ved hjælp af metoden Calculate på en budgetkonto).
        /// </summary>
        public virtual decimal DisponibelPrStatusdato
        {
            get
            {
                return Math.Max(0, Math.Abs(Budget) - Math.Abs(BogførtPrStatusdato));
            }
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

        /// <summary>
        /// Sætter bogført beløb pr. statusdato.
        /// </summary>
        /// <param name="bogførtPrStatusdato">Bogført beløb pr. statusdato.</param>
        internal virtual void SætBogførtPrStatusdato(decimal bogførtPrStatusdato)
        {
            BogførtPrStatusdato = bogførtPrStatusdato;
        } 

        /// <summary>
        /// Opdaterer indtægter.
        /// </summary>
        /// <param name="indtægter">Indtægter.</param>
        public virtual void SætIndtægter(decimal indtægter)
        {
            Indtægter = indtægter;
        }

        /// <summary>
        /// Opdaterer udgifter.
        /// </summary>
        /// <param name="udgifter">Udgifter.</param>
        public virtual void SætUdgifter(decimal udgifter)
        {
            Udgifter = udgifter;
        }

        #endregion
    }
}
