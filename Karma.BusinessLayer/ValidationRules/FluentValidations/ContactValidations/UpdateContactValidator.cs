using FluentValidation;
using Karma.DtoLayer.Dtos.ContactDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.ContactValidations
{
	public class UpdateContactValidator:AbstractValidator<UpdateContactDto>
	{
        public UpdateContactValidator()
        {
            
        }
    }
}
