using Autofac;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory;
using Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Interfaces;
using Mcet.Ucas.Event.Service.Query.Interfaces;
using Mcet.Ucas.Event.Service.Query.Model.Queries;
using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using System;
using System.Collections.Generic;

namespace Mcet.Ucas.Event.Service.Query.Api.Ioc.Modules
{
    public class EventModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetEventsQueryHandler>().As<IQueryHandler<GetEventsQuery, PagedResultModel<EventSummaryModel>>>().SingleInstance();
            builder.RegisterType<GetEventDetailsQueryHandler>().As<IQueryHandler<GetEventDetailsQuery, EventDetailsModel>>().SingleInstance();
            builder.Register(
                c => new Dictionary<Type, Func<IQueryHandler>>
                {
                    [typeof(GetEventsQuery)] = c.Resolve<Func<IQueryHandler<GetEventsQuery, PagedResultModel<EventSummaryModel>>>>(),
                    [typeof(GetEventDetailsQuery)] = c.Resolve<Func<IQueryHandler<GetEventDetailsQuery, EventDetailsModel>>>(),
                }).As<IDictionary<Type, Func<IQueryHandler>>>().SingleInstance();

            builder.RegisterType<InMemoryDataStore>().As<IDataStore>();
        }
    }
}