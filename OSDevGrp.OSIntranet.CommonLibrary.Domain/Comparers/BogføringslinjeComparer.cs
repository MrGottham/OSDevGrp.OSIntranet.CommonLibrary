using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers
{
    /// <summary>
    /// Klasse til sammenligning af månedsoplysninger.
    /// </summary>
    public class BogføringslinjeComparer : IComparer<Bogføringslinje>
    {
        #region IComparer<Bogføringslinje> Members

        /// <summary>
        /// Sammenligning af månedsoplysninger.
        /// </summary>
        public int Compare(Bogføringslinje x, Bogføringslinje y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            var result = x.Dato.CompareTo(y.Dato);
            return result == 0 ? x.Løbenummer.CompareTo(y.Løbenummer) : result;
        }

        #endregion
    }
}
