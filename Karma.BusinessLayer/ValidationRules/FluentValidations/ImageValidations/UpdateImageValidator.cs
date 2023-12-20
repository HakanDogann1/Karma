﻿using FluentValidation;
using Karma.DtoLayer.Dtos.ImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.ValidationRules.FluentValidations.ImageValidations
{
	public class UpdateImageValidator:AbstractValidator<UpdateImageDto>
	{
        public UpdateImageValidator()
        {
            
        }
    }
}
