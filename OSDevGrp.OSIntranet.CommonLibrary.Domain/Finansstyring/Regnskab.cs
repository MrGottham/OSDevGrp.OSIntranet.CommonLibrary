using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
{
    /// <summary>
    /// Regnskab.
    /// </summary>
    public class Regnskab
    {
        #region Constructor

        /// <summary>
        /// Danner et nyt regnskab.
        /// </summary>
        /// <param name="nummer">Regnsskabsnummer.</param>
        /// <param name="navn">Navn på regnskab.</param>
        public Regnskab(int nummer, string navn)
        {
            if (string.IsNullOrEmpty(navn))
            {
                throw new ArgumentException(navn);
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Nummer = nummer;
            Navn = navn;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Regnskabsnummer.
        /// </summary>
        public virtual int Nummer
        {
            get;
            protected set;
        }

        /// <summary>
        /// Navn på regnskab.
        /// </summary>
        public virtual string Navn
        {
            get;
            protected set;
        }

        #endregion
    }
}
