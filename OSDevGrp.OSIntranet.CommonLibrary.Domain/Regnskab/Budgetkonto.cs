﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Regnskab
{
    /// <summary>
    /// Budgetkonto.
    /// </summary>
    public class Budgetkonto : KontoBase
    {
        #region Private variables

        private readonly IList<Budgetoplysninger> _budgetoplysninger = new List<Budgetoplysninger>();

        #endregion

        #region Constructor

        /// <summary>
        /// Danner en ny budgetkonto.
        /// </summary>
        /// <param name="regnskab">Regnskab, som budgetkontoen er tilknyttet.</param>
        /// <param name="budgetkontonummer">Kontonummer for budgetkontoen.</param>
        /// <param name="budgetkontonavn">Navn på budgetkontoen.</param>
        /// <param name="budgetkontogruppe">Budgetkontogruppe for budgetkontoen.</param>
        public Budgetkonto(Regnskab regnskab, string budgetkontonummer, string budgetkontonavn, Budgetkontogruppe budgetkontogruppe)
            : base(regnskab, budgetkontonummer, budgetkontonavn)
        {
            if (budgetkontogruppe == null)
            {
                throw new ArgumentException("budgetkontogruppe");
            }
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Budgetkontogruppe = budgetkontogruppe;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }

        #endregion

        #region Properties

        /// <summary>
        /// Budgetkontogruppe.
        /// </summary>
        public virtual Budgetkontogruppe Budgetkontogruppe
        {
            get;
            protected set;
        }

        /// <summary>
        /// Budgetoplysninger.
        /// </summary>
        public virtual IList<Budgetoplysninger> Budgetoplysninger
        {
            get
            {
                return new ReadOnlyCollection<Budgetoplysninger>(_budgetoplysninger);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tilføjer budgetoplysinger.
        /// </summary>
        /// <param name="budgetoplysninger">Budgetoplysninger.</param>
        public virtual void TilføjBudgetoplysninger(Budgetoplysninger budgetoplysninger)
        {
            if (budgetoplysninger == null)
            {
                throw new ArgumentNullException("budgetoplysninger");
            }
            budgetoplysninger.SætBudgetkonto(this);
            _budgetoplysninger.Add(budgetoplysninger);
        }

        #endregion
    }
}
