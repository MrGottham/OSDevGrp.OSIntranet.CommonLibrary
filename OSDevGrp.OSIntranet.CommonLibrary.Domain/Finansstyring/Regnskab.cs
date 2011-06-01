using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Comparers;
using OSDevGrp.OSIntranet.CommonLibrary.Domain.Fælles;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Regnskab.
    /// </summary>
    public class Regnskab
    {
        #region Private variables

        private readonly int _nummer;
        private readonly IList<KontoBase> _konti = new List<KontoBase>();
        private string _navn;

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
            _nummer = nummer;
            _navn = navn;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Regnskabsnummer.
        /// </summary>
        public virtual int Nummer
        {
            get
            {
                return _nummer;
            }
        }

        /// <summary>
        /// Navn på regnskab.
        /// </summary>
        public virtual string Navn
        {
            get
            {
                return _navn;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _navn = value;
            }
        }

        /// <summary>
        /// Brevhoved til regnskabet.
        /// </summary>
        public virtual Brevhoved Brevhoved
        {
            get;
            protected set;
        }

        /// <summary>
        /// Konti på regnskabet.
        /// </summary>
        public virtual IEnumerable<KontoBase> Konti
        {
            get
            {
                var comparer = new KontoComparer();
                return new ReadOnlyCollection<KontoBase>(_konti.OrderBy(m => m, comparer).ToArray());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Navn på regnskab.
        /// </summary>
        /// <returns>Navn på regnskab.</returns>
        public override string ToString()
        {
            return Navn;
        }

        /// <summary>
        /// Opdaterer navn på regnskabet.
        /// </summary>
        /// <param name="navn">Navn på regnskabet.</param>
        public virtual void SætNavn(string navn)
        {
            Navn = navn;
        }

        /// <summary>
        /// Sætter brevhovedet til regnskabet.
        /// </summary>
        /// <param name="brevhoved">Brevhoved til regnskabet.</param>
        public virtual void SætBrevhoved(Brevhoved brevhoved)
        {
            Brevhoved = brevhoved;
        }

        /// <summary>
        /// Tilføjer en konto til regnskabet.
        /// </summary>
        /// <param name="konto">Konto.</param>
        public virtual void TilføjKonto(KontoBase konto)
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
