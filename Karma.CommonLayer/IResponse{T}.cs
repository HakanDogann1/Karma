using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.CommonLayer
{
    public interface IResponse<T> where T : class
    {
        public T Data { get; set; }
        public List<CustomError> CustomErrors { get; set; }
    }
}
