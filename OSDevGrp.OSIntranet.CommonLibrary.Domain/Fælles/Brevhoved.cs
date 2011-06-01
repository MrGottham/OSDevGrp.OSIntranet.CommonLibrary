using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Fælles
{
    /// <summary>
    /// Brevhoved.
    /// </summary>
    public class Brevhoved
    {
        #region Private variables

        private readonly int _nummer;
        private string _navn;

        #endregion

        #region Constructor

        /// <summary>
        /// Danner brevhoved.
        /// </summary>
        /// <param name="nummer">Unik identifikation af brevhovedet.</param>
        /// <param name="navn">Navn på brevhovedet.</param>
        public Brevhoved(int nummer, string navn)
        {
            if (string.IsNullOrEmpty(navn))
            {
                throw new ArgumentNullException("navn");
            }
            _nummer = nummer;
            _navn = navn;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Unik identifikation af brevhovedet.
        /// </summary>
        public virtual int Nummer
        {
            get
            {
                return _nummer;
            }
        }

        /// <summary>
        /// Navn på brevhovedet.
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
        /// Brevhovedets 1. linje.
        /// </summary>
        public virtual string Linje1
        {
            get;
            protected set;
        }

        /// <summary>
        /// Brevhovedets 2. linje.
        /// </summary>
        public virtual string Linje2
        {
            get;
            protected set;
        }

        /// <summary>
        /// Brevhovedets 3. linje.
        /// </summary>
        public virtual string Linje3
        {
            get;
            protected set;
        }

        /// <summary>
        /// Brevhovedets 4. linje.
        /// </summary>
        public virtual string Linje4
        {
            get;
            protected set;
        }

        /// <summary>
        /// Brevhovedets 5. linje.
        /// </summary>
        public virtual string Linje5
        {
            get;
            protected set;
        }

        /// <summary>
        /// Brevhovedets 6. linje.
        /// </summary>
        public virtual string Linje6
        {
            get;
            protected set;
        }

        /// <summary>
        /// Brevhovedets 7. linje.
        /// </summary>
        public virtual string Linje7
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Navn på brevhovedet.
        /// </summary>
        /// <returns>Navn på brevhovedet.</returns>
        public override string ToString()
        {
            return Navn;
        }

        /// <summary>
        /// Opdaterer navnet på brevhovedet.
        /// </summary>
        /// <param name="navn">Navn på brevhovedet.</param>
        public virtual void SætNavn(string navn)
        {
            Navn = navn;
        }

        /// <summary>
        /// Sætter brevhovedet 1. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje1(string linje)
        {
            Linje1 = linje;
        }

        /// <summary>
        /// Sætter brevhovedet 2. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje2(string linje)
        {
            Linje2 = linje;
        }

        /// <summary>
        /// Sætter brevhovedet 3. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje3(string linje)
        {
            Linje3 = linje;
        }

        /// <summary>
        /// Sætter brevhovedet 4. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje4(string linje)
        {
            Linje4 = linje;
        }

        /// <summary>
        /// Sætter brevhovedet 5. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje5(string linje)
        {
            Linje5 = linje;
        }

        /// <summary>
        /// Sætter brevhovedet 6. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje6(string linje)
        {
            Linje6 = linje;
        }

        /// <summary>
        /// Sætter brevhovedet 7. linje.
        /// </summary>
        /// <param name="linje">Linje.</param>
        public virtual void SætLinje7(string linje)
        {
            Linje7 = linje;
        }

        #endregion
    }
}
