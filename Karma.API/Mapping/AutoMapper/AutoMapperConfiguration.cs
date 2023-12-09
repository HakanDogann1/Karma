using AutoMapper;
using Karma.API.Models.BrandModel;
using Karma.DtoLayer.Dtos.BrandDto;

namespace Karma.API.Mapping.AutoMapper
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateBrandDto,CreateBrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandDto,UpdateBrandViewModel>().ReverseMap();
        }
    }
}
