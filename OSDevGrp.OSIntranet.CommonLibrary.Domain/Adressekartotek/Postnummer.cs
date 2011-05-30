using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Adressekartotek
{
    /// <summary>
    /// Postnummer.
    /// </summary>
    public class Postnummer
    {
        #region Private variables

        private readonly string _landekode;
        private readonly string _postnr;
        private string _by;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner et nyt postnummer.
        /// </summary>
        /// <param name="landekode">Landekode.</param>
        /// <param name="postnr">Postnummer.</param>
        /// <param name="by">Bynavn.</param>
        public Postnummer(string landekode, string postnr, string by)
        {
            if (string.IsNullOrEmpty(landekode))
            {
                throw new ArgumentNullException("landekode");
            }
            if (string.IsNullOrEmpty(postnr))
            {
                throw new ArgumentNullException("postnr");
            }
            if (string.IsNullOrEmpty(by))
            {
                throw new ArgumentNullException("by");
            }
            _landekode = landekode;
            _postnr = postnr;
            _by = by;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Landekode.
        /// </summary>
        public virtual string Landekode
        {
            get
            {
                return _landekode;
            }
        }

        /// <summary>
        /// Postnummer.
        /// </summary>
        public virtual string Postnr
        {
            get
            {
                return _postnr;
            }
        }

        /// <summary>
        /// Bynavn.
        /// </summary>
        public virtual string By
        {
            get
            {
                return _by;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _by = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tekst for postnummeret.
        /// </summary>
        /// <returns>Tekst for postnummeret</returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Landekode) && !string.IsNullOrEmpty(Postnr) && !string.IsNullOrEmpty(By))
            {
                return string.Format("{0}-{1}  {2}", Landekode, Postnr, By);
            }
            if (!string.IsNullOrEmpty(Postnr) && !string.IsNullOrEmpty(By))
            {
                return string.Format("{0}  {1}", Postnr, By);
            }
            return string.IsNullOrEmpty(By) ? string.Empty : By;
        }

        /// <summary>
        /// Opdaterer bynavn.
        /// </summary>
        /// <param name="by">Bynavn.</param>
        public virtual void SætBy(string by)
        {
            By = by;
        }

        #endregion
    }
}
