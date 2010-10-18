using System;
using System.Collections.Generic;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers
{
    /// <summary>
    /// Klasse til sammenligning af adresser.
    /// </summary>
    public class AdresseComparer : IComparer<AdresseBase>
    {
        #region IComparer<AdresseBase> Members

        /// <summary>
        /// Sammenligning af adresser.
        /// </summary>
        public int Compare(AdresseBase x, AdresseBase y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }
            var result = x.Navn.CompareTo(y.Navn);
            return result == 0 ? x.Nummer.CompareTo(y.Nummer) : result;
        }

        #endregion
    }
}
