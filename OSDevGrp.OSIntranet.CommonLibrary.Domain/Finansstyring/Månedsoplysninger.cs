using System;
using System.Threading;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Månedsoplysninger.
    /// </summary>
    public abstract class Månedsoplysninger
    {
        #region Private variables

        private readonly int _år;
        private readonly int _måned;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner nye månedsoplysninger.
        /// </summary>
        /// <param name="år">Årstal.</param>
        /// <param name="måned">Måned.</param>
        protected Månedsoplysninger(int år, int måned)
        {
            _år = år;
            _måned = måned;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Årstal.
        /// </summary>
        public virtual int År
        {
            get
            {
                return _år;
            }
        }

        /// <summary>
        /// Måned.
        /// </summary>
        public virtual int Måned
        {
            get
            {
                return _måned;
            }
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
