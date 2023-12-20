﻿using FluentValidation;
using Karma.BusinessLayer.Abstract;
using Karma.BusinessLayer.Concrete;
using Karma.BusinessLayer.ValidationRules.FluentValidations.BrandValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.CategoryValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ColorValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ContactValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ImageValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.NewCollectionValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.NumberValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ServiceValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.ShoeValidations;
using Karma.BusinessLayer.ValidationRules.FluentValidations.TasteShoeValidations;
using Karma.DataAccessLayer.Abstract;
using Karma.DataAccessLayer.Concrete;
using Karma.DataAccessLayer.Context;
using Karma.DataAccessLayer.EntityFramework;
using Karma.DataAccessLayer.UnitOfWork;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.DtoLayer.Dtos.CategoryDto;
using Karma.DtoLayer.Dtos.ColorDto;
using Karma.DtoLayer.Dtos.ContactDto;
using Karma.DtoLayer.Dtos.ImageDto;
using Karma.DtoLayer.Dtos.NewCollectionDto;
using Karma.DtoLayer.Dtos.NumberDto;
using Karma.DtoLayer.Dtos.ServiceDto;
using Karma.DtoLayer.Dtos.ShoeDto;
using Karma.EntityLayer.Concrete;
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

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IColorService, ColorManager>();
            services.AddScoped<IColorDal, EfColorDal>();

            services.AddScoped<INumberService, NumberManager>();
            services.AddScoped<INumberDal, EfNumberDal>();

            services.AddScoped<IShoeService, ShoeManager>();
            services.AddScoped<IShoeDal, EfShoeDal>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

			services.AddScoped<IContactDal, EfContactDal>();
			services.AddScoped<IContactService, ContactManager>();

			services.AddScoped<INewCollectionDal, EfNewCollectionDal>();
			services.AddScoped<INewCollectionService, NewCollectionManager>();

			services.AddScoped<IImageDal, EfImageDal>();
			services.AddScoped<IImageService, ImageManager>();


			services.AddScoped<IValidator<CreateBrandDto>, CreateBrandValidation>();
            services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandValidation>();

            services.AddScoped<IValidator<CreateNumberDto>, CreateNumberValidator>();
            services.AddScoped<IValidator<UpdateNumberDto>, UpdateNumberValidator>();

            services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryValidator>();
            services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryValidator>();

            services.AddScoped<IValidator<CreateColorDto>, CreateColorValidator>();
            services.AddScoped<IValidator<UpdateColorDto>, UpdateColorValidator>();

            services.AddScoped<IValidator<CreateShoeDto>, CreateShoeValidator>();
            services.AddScoped<IValidator<UpdateShoeDto>, UpdateShoeValidator>();

			services.AddScoped<IValidator<CreateServiceDto>, CreateServiceValidator>();
			services.AddScoped<IValidator<UpdateServiceDto>, UpdateServiceValidator>();

			services.AddScoped<IValidator<CreateContactDto>, CreateContactValidator>();
			services.AddScoped<IValidator<UpdateContactDto>, UpdateContactValidator>();

			services.AddScoped<IValidator<CreateNewCollectionDto>, CreateNewCollectionValidator>();
			services.AddScoped<IValidator<UpdateNewCollectionDto>, UpdateNewCollectionValidator>();

			services.AddScoped<IValidator<CreateImageDto>, CreateImageValidator>();
			services.AddScoped<IValidator<UpdateImageDto>, UpdateImageValidator>();

			services.AddScoped<IUow, Uow>();


        }
    }
}
