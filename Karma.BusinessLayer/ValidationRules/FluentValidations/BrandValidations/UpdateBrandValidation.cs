using FluentValidation;
using Karma.DtoLayer.Dtos.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.BrandValidations
{
    public class UpdateBrandValidation:AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandValidation()
        {
            RuleFor(x=>x.BrandName).NotEmpty();
        }
    }
}
