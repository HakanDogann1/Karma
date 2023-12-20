using FluentValidation;
using Karma.DtoLayer.Dtos.NewCollectionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.NewCollectionValidations
{
	public class UpdateNewCollectionValidator:AbstractValidator<UpdateNewCollectionDto>
	{
        public UpdateNewCollectionValidator()
        {
            
        }
    }
}
