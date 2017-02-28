using System;

namespace Mcet.Ucas.Event.Service.Query.Handlers.InMemory.Entities
{
    public class EventEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string Organiser { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
    }
}
