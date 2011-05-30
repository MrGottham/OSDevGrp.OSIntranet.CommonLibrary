using OSDevGrp.OSIntranet.CommonLibrary.Domain.Enums;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Kontogruppe.
    /// </summary>
    public class Kontogruppe : KontogruppeBase
    {
        #region Private variables

        private KontogruppeType _kontogruppeType;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en ny kontogruppe.
        /// </summary>
        /// <param name="nummer">Nummer på kontogruppen.</param>
        /// <param name="navn">Navn på kontogruppen.</param>
        /// <param name="kontogruppeType">Type for kontogruppen.</param>
        public Kontogruppe(int nummer, string navn, KontogruppeType kontogruppeType)
            : base(nummer, navn)
        {
            _kontogruppeType = kontogruppeType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Typen for kontogruppen.
        /// </summary>
        public virtual KontogruppeType KontogruppeType
        {
            get
            {
                return _kontogruppeType;
            }
            protected set
            {
                _kontogruppeType = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opdaterer typen for kontogruppen.
        /// </summary>
        /// <param name="kontogruppeType">Type for kontogruppen.</param>
        public virtual void SætKontogruppeType(KontogruppeType kontogruppeType)
        {
            KontogruppeType = kontogruppeType;
        }

        #endregion
    }
}
