using FluentValidation;
using Karma.DtoLayer.Dtos.NumberDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.NumberValidations
{
    public class CreateNumberValidator:AbstractValidator<CreateNumberDto>
    {
        public CreateNumberValidator()
        {
            RuleFor(x=>x.Num).NotEmpty().WithMessage("Numara alanı boş bırakılamaz");
        }
    }
}
