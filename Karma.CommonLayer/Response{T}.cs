using Karma.CommonLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.CommonLayer
{
    public class Response<T>:Response,IResponse<T> where T : class
    {
        public T Data { get; set; }
        public List<CustomError> CustomErrors { get; set; }
        public Response(string message,ResponseType responseType):base(message,responseType)
        {
        }

        public Response(T data):base(ResponseType.Success)
        {
            Data = data;
        }

        public Response(T data,List<CustomError> customErrors):base(ResponseType.ValidationError)
        {
            Data = data;
            CustomErrors = customErrors;
        }
        public Response(T data,string message):base(message,ResponseType.Success)
        {
            Data =data;
        }

    }
}
