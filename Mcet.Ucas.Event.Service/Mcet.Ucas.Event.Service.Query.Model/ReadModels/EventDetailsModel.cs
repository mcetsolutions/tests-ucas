namespace Mcet.Ucas.Event.Service.Query.Model.ReadModels
{
    public class EventDetailsModel : EventSummaryModel
    {
        public string Organiser { get; set; }
        public EventCategory Category { get; set; }
        public string Description { get; set; }
    }
}
