using System;
using System.Threading;

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

        #region Methods

        /// <summary>
        /// Tekst for månedsoplysninger.
        /// </summary>
        /// <returns>Tekst for månedsoplysninger.</returns>
        public override string ToString()
        {
            var dateForMonth = new DateTime(År, Måned, 1);
            return dateForMonth.ToString("MMMM yyyy", Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
        }

        #endregion
    }
}
