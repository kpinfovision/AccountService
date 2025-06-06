using Newtonsoft.Json;
using Xome.Cascade2.SharedUtilities.ResponseModels;

namespace Xome.Cascade2.AccountService.Domain.Entities.Pagination
{
    public class PagedRequest
    {
        public Dictionary<string, string>? Filters { get; set; }

        public string? SortColumn { get; set; }
        public bool? SortDescending { get; set; } = false;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
