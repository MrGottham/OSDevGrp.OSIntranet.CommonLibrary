using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Regnskab.
    /// </summary>
    public class Regnskab
    {
        #region Private variables

        private readonly IList<KontoBase> _konti = new List<KontoBase>();

        #endregion

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

        /// <summary>
        /// Konti på regnskabet.
        /// </summary>
        public virtual IList<KontoBase> Konti
        {
            get
            {
                return new ReadOnlyCollection<KontoBase>(_konti);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tilføjer en konto til regnskabet.
        /// </summary>
        /// <param name="konto">Konto.</param>
        public void TilføjKonto(KontoBase konto)
        {
            if (konto == null)
            {
                throw new ArgumentNullException("konto");
            }
            _konti.Add(konto);
        }

        #endregion
    }
}
