using System.Collections.Generic;

namespace Mcet.Ucas.Event.Service.Query.Model.ReadModels
{
    public class PagedResultModel<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages
        {
            get
            {
                var completePages = TotalResults / PageSize;
                var overspill = TotalResults % PageSize;

                return completePages + (overspill == 0 ? 0 : 1);
            }
        }
        public IEnumerable<T> Items { get; set; }
    }
}
