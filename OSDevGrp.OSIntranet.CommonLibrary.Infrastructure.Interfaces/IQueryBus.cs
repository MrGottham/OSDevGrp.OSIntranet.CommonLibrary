namespace OSDevGrp.OSIntranet.CommonLibrary.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface til en QueryBus.
    /// </summary>
    public interface IQueryBus
    {
        /// <summary>
        /// Udfører en forespørgelse.
        /// </summary>
        /// <typeparam name="TQuery">Typen af forespørgelsen, der skal udføres.</typeparam>
        /// <typeparam name="TView">Typen, som forespørgelsen, skal returnerer.</typeparam>
        /// <param name="query">Forespørgelse.</param>
        /// <returns>Værdi, som forespørgelsen, skal returnerer.</returns>
        TView Query<TQuery, TView>(TQuery query) where TQuery : class, IQuery;
    }
}
