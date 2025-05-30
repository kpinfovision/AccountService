using Newtonsoft.Json;


namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class PaginationModel
    {
        const int minPageSize = 5;
        const int maxPageSize = 100;
        public string SortColumn { get; set; }
        public SortOrder SortOrder { get; set; } = 0;
        public int PageNumber { get; set; } = 1;
        [JsonIgnore]
        public int SkipRows { get; set; } = 0;
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < minPageSize)
                {
                    _pageSize = minPageSize;
                }
                else if (value > maxPageSize)
                {
                    _pageSize = maxPageSize;
                }
                else
                    _pageSize = value;

            }
        }
    }
}
