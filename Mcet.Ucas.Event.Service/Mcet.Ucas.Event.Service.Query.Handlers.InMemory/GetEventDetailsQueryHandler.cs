using Mcet.Ucas.Event.Service.Query.Interfaces;
using Mcet.Ucas.Event.Service.Query.Model.Queries;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using System.Linq;
using AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Interfaces;

namespace Mcet.Ucas.Event.Service.Query.Handlers.InMemory
{
    public class GetEventDetailsQueryHandler : IQueryHandler<GetEventDetailsQuery, EventDetailsModel>
    {
        private readonly IDataStore _dataStore;

        public GetEventDetailsQueryHandler(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public EventDetailsModel Handle(GetEventDetailsQuery query)
        {
            return _dataStore.GetEvents().Where(e => e.Id == query.EventId).Select(e => Mapper.Map<EventDetailsModel>(e)).FirstOrDefault();
        }
    }
}
