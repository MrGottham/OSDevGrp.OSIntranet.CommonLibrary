namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Månedsoplysninger.
    /// </summary>
    public abstract class Månedsoplysninger
    {
        #region Constructor

        /// <summary>
        /// Danner nye månedsoplysninger.
        /// </summary>
        /// <param name="år">Årstal.</param>
        /// <param name="måned">Måned.</param>
        protected Månedsoplysninger(int år, int måned)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            År = år;
            Måned = måned;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Årstal.
        /// </summary>
        public virtual int År
        {
            get;
            protected set;
        }

        /// <summary>
        /// Måned.
        /// </summary>
        public virtual int Måned
        {
            get;
            protected  set;
        }

        #endregion
    }
}
