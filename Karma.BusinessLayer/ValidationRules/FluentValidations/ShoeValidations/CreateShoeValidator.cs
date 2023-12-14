using FluentValidation;
using Karma.DtoLayer.Dtos.ShoeDto;
using Karma.DtoLayer.Dtos.TasteShoeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.TasteShoeValidations
{
    public class CreateShoeValidator:AbstractValidator<CreateShoeDto>
    {
        public CreateShoeValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz");
            RuleFor(x=>x.Stock).NotEmpty().WithMessage("Stok alanı boş bırakılamaz");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz");
            RuleFor(x=>x.Width).NotEmpty().WithMessage("Genişlik alanı boş bırakılamaz");
            RuleFor(x=>x.Height).NotEmpty().WithMessage("Yükseklik alanı boş bırakılamaz");
            RuleFor(x=>x.Depth).NotEmpty().WithMessage("Derinlik alanı boş bırakılamaz");
        }
    }
}
