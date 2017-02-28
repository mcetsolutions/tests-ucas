using AutoMapper;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Extensions;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Interfaces;
using Mcet.Ucas.Event.Service.Query.Interfaces;
using Mcet.Ucas.Event.Service.Query.Model.Queries;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using System.Collections.Generic;
using System.Linq;

namespace Mcet.Ucas.Event.Service.Query.Handlers.InMemory
{
    public class GetEventsQueryHandler : IQueryHandler<GetEventsQuery, PagedResultModel<EventSummaryModel>>
    {
        private readonly IDataStore _dataStore;

        public GetEventsQueryHandler(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public PagedResultModel<EventSummaryModel> Handle(GetEventsQuery query)
        {
            var skip = query.PageSize * (query.PageNumber - 1);
            var events = _dataStore.GetEvents();
            var pageItems = events.AsQueryable().OrderByPropertyName(query.OrderBy, query.Ascending).Skip(skip).Take(query.PageSize);

            return new PagedResultModel<EventSummaryModel>
            {
                Items = Mapper.Map<List<EventSummaryModel>>(pageItems),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalResults = events.Count()
            };
        }
    }
}
