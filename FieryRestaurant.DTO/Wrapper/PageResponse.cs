using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.DTO.Wrapper
{
    public class PageResponse<T> :Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 
        public int TotalPages { get; set; }
        public int TotalRecores { get; set; }
   
        public PageResponse(T date,int pageNumber,int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = date;
            this.Message = null;
            this.Succeeded = true;
            this.Error = null;
        }
    }
}
