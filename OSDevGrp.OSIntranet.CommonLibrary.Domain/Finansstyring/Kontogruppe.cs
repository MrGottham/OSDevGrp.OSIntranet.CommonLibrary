using OSDevGrp.OSIntranet.CommonLibrary.Domain.Enums;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Kontogruppe.
    /// </summary>
    public class Kontogruppe : KontogruppeBase
    {
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
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            KontogruppeType = kontogruppeType;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Typen for kontogruppen.
        /// </summary>
        public virtual KontogruppeType KontogruppeType
        {
            get;
            protected set;
        }

        #endregion
    }
}
