﻿namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces
{
    /// <summary>
    /// Marker interface.
    /// </summary>
    public interface IQueryHandler
    {
    }

    /// <summary>
    /// Interface til QueryHandler, som håndterer en forespørgelse.
    /// </summary>
    /// <typeparam name="TQuery">Typen af forespørgelsen, som QueryHandleren håndterer.</typeparam>
    /// <typeparam name="TView">Typen af viewet, som QueryHandleren returnerer.</typeparam>
    public interface IQueryHandler<in TQuery, out TView> : IQueryHandler where TQuery : IQuery
    {
        /// <summary>
        /// Eksekvering af forespørgelse.
        /// </summary>
        /// <param name="query">Forespørgelse, som skal eksekveres</param>
        /// <returns>Resultat af forespørgelsen.</returns>
        TView Query(TQuery query);
    }
}
