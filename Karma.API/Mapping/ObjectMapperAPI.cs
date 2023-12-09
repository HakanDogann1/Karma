using AutoMapper;
using Karma.API.Mapping.AutoMapper;
using System;

namespace Karma.API.Mapping
{
    public static class ObjectMapperAPI
    {
        public static Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapperConfiguration());
            });
            return config.CreateMapper();
        });

        public static IMapper mapper = lazy.Value; 
    }
}
