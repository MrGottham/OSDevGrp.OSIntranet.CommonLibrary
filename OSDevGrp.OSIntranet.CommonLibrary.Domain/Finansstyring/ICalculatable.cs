using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Interface til kalkulering af status på et givent tidspunkt.
    /// </summary>
    public interface ICalculatable
    {
        /// <summary>
        /// Kalkulering af status på en givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        void Calculate(DateTime statusDato);
    }
}
