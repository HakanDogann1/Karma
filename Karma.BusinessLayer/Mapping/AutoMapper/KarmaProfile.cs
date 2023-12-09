using AutoMapper;
using Karma.DtoLayer.Dtos.BasketDto;
using Karma.DtoLayer.Dtos.BrandDto;
using Karma.DtoLayer.Dtos.CategoryDto;
using Karma.DtoLayer.Dtos.ColorDto;
using Karma.DtoLayer.Dtos.CommentDto;
using Karma.DtoLayer.Dtos.NumberDto;
using Karma.DtoLayer.Dtos.ShoeDto;
using Karma.DtoLayer.Dtos.TasteShoeDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Mapping.AutoMapper
{
    public class KarmaProfile : Profile
    {
        public KarmaProfile()
        {
            CreateMap<CreateBasketDto,Basket>().ReverseMap();
            CreateMap<UpdateBasketDto,Basket>().ReverseMap();
            CreateMap<ResultBasketDto,Basket>().ReverseMap();
            CreateMap<ResultBrandDto,Brand>().ReverseMap();
            CreateMap<CreateBrandDto,Brand>().ReverseMap();
            CreateMap<UpdateBrandDto,Brand>().ReverseMap();
            CreateMap<ResultCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,Category>().ReverseMap();
            CreateMap<CreateCategoryDto,Category>().ReverseMap();
            CreateMap<ResultColorDto,Color>().ReverseMap();
            CreateMap<UpdateColorDto,Color>().ReverseMap();
            CreateMap<CreateColorDto,Color>().ReverseMap();
            CreateMap<ResultCommentDto,Comment>().ReverseMap();
            CreateMap<UpdateCommentDto,Comment>().ReverseMap();
            CreateMap<CreateCommentDto,Comment>().ReverseMap();
            CreateMap<CreateNumberDto,Number>().ReverseMap();
            CreateMap<ResultNumberDto,Number>().ReverseMap();
            CreateMap<UpdateNumberDto,Number>().ReverseMap();
            CreateMap<UpdateShoeDto,Shoe>().ReverseMap();
            CreateMap<ResultShoeDto,Shoe>().ReverseMap();
            CreateMap<CreateShoeDto,Shoe>().ReverseMap();
            CreateMap<ResultTasteShoeDto,TasteShoe>().ReverseMap();
            CreateMap<CreateTasteShoeDto,TasteShoe>().ReverseMap();
            CreateMap<UpdateTasteShoeDto,TasteShoe>().ReverseMap();
        }
    }
}
