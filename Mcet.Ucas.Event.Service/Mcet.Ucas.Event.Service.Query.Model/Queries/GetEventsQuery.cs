using Mcet.Ucas.Event.Service.Query.Model.ReadModels;

namespace Mcet.Ucas.Event.Service.Query.Model.Queries
{
    public class GetEventsQuery : PagedQuery<PagedResultModel<EventSummaryModel>>
    {
        private const string DefaultOrderBy = "StartDate";
        private const bool DefaultAscending = false;

        public GetEventsQuery()
        {
            OrderBy = DefaultOrderBy;
            Ascending = DefaultAscending;
        }
    }
}
