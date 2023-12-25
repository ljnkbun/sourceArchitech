﻿namespace Shopfloor.Core.Models.Responses
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage => (TotalCount / (PageSize == 0 ? 1 : PageSize)) + 1;

        public PagedResponse()
        {

        }
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public PagedResponse(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}
