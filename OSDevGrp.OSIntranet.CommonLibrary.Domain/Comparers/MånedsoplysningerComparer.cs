using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers
{
    /// <summary>
    /// Klasse til sammenligning af månedsoplysninger.
    /// </summary>
    public class MånedsoplysningerComparer : IComparer<Månedsoplysninger>
    {
        #region IComparer<Månedsoplysninger> Members

        /// <summary>
        /// Sammenligning af månedsoplysninger.
        /// </summary>
        public int Compare(Månedsoplysninger x, Månedsoplysninger y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            var result = x.År.CompareTo(y.År);
            return result == 0 ? x.Måned.CompareTo(y.Måned) : result;
        }

        #endregion
    }
}
