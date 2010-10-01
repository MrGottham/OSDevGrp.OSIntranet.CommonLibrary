namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
{
    /// <summary>
    /// Kontogruppe til budgetkonti.
    /// </summary>
    public class Budgetkontogruppe : KontogruppeBase
    {
        #region Constructor

        /// <summary>
        /// Danner en kontogruppe til budgetkonti.
        /// </summary>
        /// <param name="nummer">Nummer på kontogruppen.</param>
        /// <param name="navn">Navn på kontogruppen.</param>
        public Budgetkontogruppe(int nummer, string navn)
            : base(nummer, navn)
        {
        }

        #endregion
    }
}
