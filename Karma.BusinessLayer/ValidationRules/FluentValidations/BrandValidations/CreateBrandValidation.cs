using FluentValidation;
using Karma.DtoLayer.Dtos.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.BrandValidations
{
    public class CreateBrandValidation:AbstractValidator<CreateBrandDto>
    {
        public CreateBrandValidation()
        {
            RuleFor(x=>x.BrandName).NotEmpty();
            RuleFor(x => x.BrandName).MinimumLength(2).WithMessage("Marka en az 2 karakter olmalıdır.");
        }
    }
}
