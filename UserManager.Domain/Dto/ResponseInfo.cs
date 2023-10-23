using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Dto
{
    public class ResponseInfo<T>
    {
        public T? Data { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class PagedResponse<T>
    {
        public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(List<T> data, int pageNumber, int pageSize, int totalCount, int totalPages)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }
}
