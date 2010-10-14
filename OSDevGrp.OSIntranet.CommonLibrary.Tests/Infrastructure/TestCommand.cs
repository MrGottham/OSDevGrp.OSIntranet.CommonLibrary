using System;
using OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces;

namespace OSDevGrp.OSIntranet.CommonLibrary.Tests.Infrastructure
{
    /// <summary>
    /// Kommando, der kan benyttes til test af CommandBus.
    /// </summary>
    internal class TestCommand : ICommand
    {
        /// <summary>
        /// Angivelse af, om kommandoen er ændret.
        /// </summary>
        public bool Modified
        {
            get;
            set;
        }

        /// <summary>
        /// Angivelse af den exception, som commandhandleren skal kaste.
        /// </summary>
        public Exception ExceptionToThrow
        {
            get;
            set;
        }
    }
}
