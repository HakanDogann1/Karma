using FluentValidation;
using Karma.DtoLayer.Dtos.ColorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.ColorValidations
{
    public class CreateColorValidator:AbstractValidator<CreateColorDto>
    {
        public CreateColorValidator()
        {
            RuleFor(x=>x.ColorName).NotEmpty();
            RuleFor(x=>x.Piece).NotEmpty();
        }
    }
}
