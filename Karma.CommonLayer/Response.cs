using Karma.CommonLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.CommonLayer
{
    public class Response : IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

        public Response(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
            
        }
        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }
    }
}
