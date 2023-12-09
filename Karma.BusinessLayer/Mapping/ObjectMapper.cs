using AutoMapper;
using Karma.BusinessLayer.Mapping.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Mapping
{
    public static class ObjectMapper
    {
        public static Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile<KarmaProfile>();
            });

            return config.CreateMapper();
        });

        public static IMapper mapper = lazy.Value;
    }
}
