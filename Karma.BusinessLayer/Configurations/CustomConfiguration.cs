using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Concrete;
using Karma.BusinessLayer.ValidationRules.FluentValidations.BrandValidations;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.Context;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.BrandDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Configurations
{
    public static class CustomConfiguration
    {
        public static void CustomConfigurationExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<KarmaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("useSql"));
            });

            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IValidator<CreateBrandDto>, CreateBrandValidation>();
            services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandValidation>();

            services.AddScoped<IUow, Uow>();


        }
    }
}
