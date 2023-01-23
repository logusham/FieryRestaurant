using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.DTO.Wrapper
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data)
        {

        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Error { get; set; }
        public string Message { get; set; }
    }
}
