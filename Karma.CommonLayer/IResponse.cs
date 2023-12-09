using Karma.CommonLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.CommonLayer
{
    public interface IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}
