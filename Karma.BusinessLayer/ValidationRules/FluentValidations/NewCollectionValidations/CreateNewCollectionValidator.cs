using FluentValidation;
using Karma.DtoLayer.Dtos.NewCollectionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.NewCollectionValidations
{
	public class CreateNewCollectionValidator:AbstractValidator<CreateNewCollectionDto>
	{
        public CreateNewCollectionValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("İçerik alanı boş geçilemez.");
        }
    }
}
