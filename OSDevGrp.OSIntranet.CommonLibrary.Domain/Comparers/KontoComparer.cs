using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers
{
    /// <summary>
    /// Klasse til sammenligning af konti.
    /// </summary>
    public class KontoComparer : IComparer<KontoBase>
    {
        #region IComparer<KontoBase> Members

        /// <summary>
        /// Sammenligning af konti.
        /// </summary>
        public int Compare(KontoBase x, KontoBase y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            var regnskabComparer = new RegnskabComparer();
            var result = regnskabComparer.Compare(x.Regnskab, y.Regnskab);
            return result == 0 ? x.Kontonummer.CompareTo(y.Kontonummer) : result;
        }

        #endregion
    }
}
