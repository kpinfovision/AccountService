using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class Pagination
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public Pagination(int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling(1.0 * (double)totalRecords / (double)pageSize);
        }
    }
}
