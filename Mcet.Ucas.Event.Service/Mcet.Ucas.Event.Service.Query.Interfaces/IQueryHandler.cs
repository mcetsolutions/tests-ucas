namespace Mcet.Ucas.Event.Service.Query.Interfaces
{
    public interface IQueryHandler { }

    public interface IQueryHandler<in TQuery, out TResponse>: IQueryHandler where TQuery: IQuery<TResponse>
    {
        TResponse Handle(TQuery query);
    }
}
