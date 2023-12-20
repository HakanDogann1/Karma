using FluentValidation;
using Karma.DtoLayer.Dtos.ContactDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.ContactValidations
{
	public class CreateContactValidator : AbstractValidator<CreateContactDto>
	{
		public CreateContactValidator()
		{
			RuleFor(x=>x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
			RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
			RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz");
			RuleFor(x=>x.Message).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz");

			RuleFor(x => x.Message).MinimumLength(4).WithMessage("Minimum 4 karakter girilmelidir.");
		}
	}
}
