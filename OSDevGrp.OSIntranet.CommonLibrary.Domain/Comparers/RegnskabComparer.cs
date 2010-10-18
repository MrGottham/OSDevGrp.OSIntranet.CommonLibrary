using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers
{
    /// <summary>
    /// Klasse til sammenligning af regnskaber.
    /// </summary>
    public class RegnskabComparer : IComparer<Regnskab>
    {
        #region IComparer<Regnskab> Members

        /// <summary>
        /// Sammenligning af regnskaber.
        /// </summary>
        public int Compare(Regnskab x, Regnskab y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            return x.Nummer.CompareTo(y.Nummer);
        }

        #endregion
    }
}
