using System;

namespace OSDevGrp.OSIntranet.CommonLibrary.Domain.Finansstyring
{
    /// <summary>
    /// Interface til kalkulering af status på et givent tidspunkt.
    /// </summary>
    public interface ICalculatable
    {
        /// <summary>
        /// Kalkulering af status på et givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        void Calculate(DateTime statusDato);

        /// <summary>
        /// Kalkulering af status på et givent tidspunkt.
        /// </summary>
        /// <param name="statusDato">Statusdato.</param>
        /// <param name="løbenr">Den unikke identifikation af bogføringslinjen, som indgår i beregningen.</param>
        void Calculate(DateTime statusDato, int løbenr);
    }
}
