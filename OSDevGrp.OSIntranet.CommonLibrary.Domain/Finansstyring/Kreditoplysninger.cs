using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
{
    /// <summary>
    /// Kreditoplysninger for en måned i et givent år.
    /// </summary>
    public class Kreditoplysninger : Månedsoplysninger
    {
        #region Constructor

        /// <summary>
        /// Danner nye kreditoplysinger.
        /// </summary>
        /// <param name="år">Årstal.</param>
        /// <param name="måned">Måned.</param>
        /// <param name="kredit">Kredit.</param>
        public Kreditoplysninger(int år, int måned, double kredit) : base(år, måned)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Kredit = kredit;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Konto, som kreditoplysningerne er tilknyttet.
        /// </summary>
        public virtual Konto Konto
        {
            get;
            protected set;
        }

        /// <summary>
        /// Kredit.
        /// </summary>
        public virtual double Kredit
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sætter konto for kreditoplysninger.
        /// </summary>
        /// <param name="konto">Konto.</param>
        internal virtual void SætKonto(Konto konto)
        {
            if (konto == null)
            {
                throw new ArgumentNullException("konto");
            }
            Konto = konto;
        }

        #endregion 
    }
}
