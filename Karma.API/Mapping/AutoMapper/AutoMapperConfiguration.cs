using AutoMapper;
using Karma.API.Models.BrandModel;
using Karma.API.Models.CategoryModel;
using Karma.API.Models.ColorModel;
using Karma.API.Models.NumberModel;
using Karma.API.Models.ShoeModel;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.DtoLayer.Dtos.CategoryDto;
using Karma.DtoLayer.Dtos.ColorDto;
using Karma.DtoLayer.Dtos.NumberDto;
using Karma.DtoLayer.Dtos.ShoeDto;

namespace Karma.API.Mapping.AutoMapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateBrandDto,CreateBrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandDto,UpdateBrandViewModel>().ReverseMap();

            CreateMap<CreateColorDto, CreateColorViewModel>().ReverseMap();
            CreateMap<UpdateColorDto, UpdateColorViewModel>().ReverseMap();

            CreateMap<CreateCategoryDto, CreateCategoryViewModel>().ReverseMap();
            CreateMap<UpdateCategoryDto, UpdateCategoryViewModel>().ReverseMap();

            CreateMap<CreateNumberDto, CreateNumberViewModel>().ReverseMap();
            CreateMap<UpdateNumberDto, UpdateNumberViewModel>().ReverseMap();

            CreateMap<CreateShoeDto, CreateShoeViewModel>().ReverseMap();
            CreateMap<UpdateShoeDto, UpdateShoeViewModel>().ReverseMap();
        }
    }
}
