using Mcet.Ucas.Event.Service.Query.Model.ReadModels;
using Mcet.Ucas.Event.Service.Query.Interfaces;
using System;

namespace Mcet.Ucas.Event.Service.Query.Model.Queries
{
    public class GetEventDetailsQuery : IQuery<EventDetailsModel>
    {
        public Guid EventId { get; set; }
    }
}
