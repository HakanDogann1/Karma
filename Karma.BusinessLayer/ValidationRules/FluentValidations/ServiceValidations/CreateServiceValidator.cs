using FluentValidation;
using Karma.DtoLayer.Dtos.ServiceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.ServiceValidations
{
	public class CreateServiceValidator:AbstractValidator<CreateServiceDto>
	{
        public CreateServiceValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz");
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz");
        }
    }
}
