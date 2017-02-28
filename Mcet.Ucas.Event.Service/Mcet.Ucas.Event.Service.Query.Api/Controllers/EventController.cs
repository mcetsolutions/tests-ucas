using Mcet.Ucas.Event.Service.Query.Interfaces;
using Mcet.Ucas.Event.Service.Query.Model.Queries;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Mcet.Ucas.Event.Service.Query.Api.Controllers
{
    [RoutePrefix("events")]
    public class EventController : ApiController
    {
        private readonly IDictionary<Type, Func<IQueryHandler>> _queryHandlerMap;

        public EventController(IDictionary<Type, Func<IQueryHandler>> queryHandlerMap)
        {
            _queryHandlerMap = queryHandlerMap;
        }

        [Route()]
        [ResponseType(typeof(IEnumerable<EventSummaryModel>))]
        public IHttpActionResult GetEvents([FromUri] GetEventsQuery query)
        {
            var queryHandler = GetQueryHandler<GetEventsQuery, PagedResultModel<EventSummaryModel>>();
            var events = queryHandler.Handle(query ?? new GetEventsQuery());

            return Ok(events);
        }

        [Route("{eventId:guid}")]
        [ResponseType(typeof(EventDetailsModel))]
        public IHttpActionResult GetEventDetails([FromUri] GetEventDetailsQuery query)
        {
            var queryHandler = GetQueryHandler<GetEventDetailsQuery, EventDetailsModel>();
            var eventDetails = queryHandler.Handle(query);

            if (eventDetails == null)
            {
                return NotFound();
            }

            return Ok(eventDetails);
        }

        private IQueryHandler<TQuery, TResponse> GetQueryHandler<TQuery, TResponse>() where TQuery : IQuery<TResponse>
        {
            return (IQueryHandler<TQuery, TResponse>)_queryHandlerMap[typeof(TQuery)]();
        }
    }
}
