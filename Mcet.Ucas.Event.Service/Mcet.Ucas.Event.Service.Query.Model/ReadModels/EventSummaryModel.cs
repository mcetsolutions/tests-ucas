using System;

namespace Mcet.Ucas.Event.Service.Query.Model.ReadModels
{
    public class EventSummaryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTimeOffset StartDate { get; set; }
    }
}
