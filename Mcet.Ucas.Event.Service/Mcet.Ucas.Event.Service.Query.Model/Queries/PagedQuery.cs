using Mcet.Ucas.Event.Service.Query.Interfaces;

namespace Mcet.Ucas.Event.Service.Query.Model
{
    public abstract class PagedQuery<TResponse> : IQuery<TResponse>
    {
        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;

        public int PageNumber { get; set; } = DefaultPageNumber;
        public int PageSize { get; set; } = DefaultPageSize;
        public string OrderBy { get; set; }
        public bool Ascending { get; set; }
    }
}
