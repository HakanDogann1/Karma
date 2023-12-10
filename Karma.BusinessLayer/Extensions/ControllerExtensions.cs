using Karma.CommonLayer;
using Karma.CommonLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Extensions
{
    public class ControllerExtensions:ControllerBase
    {
        [HttpPost]
        public IActionResult TPostActionInstance<T>(Response < T> response) where T : class
        {
            if(response.ResponseType==ResponseType.Success)
            {
                return Ok(response.Data);
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                ModelStateDictionary modelState = new ModelStateDictionary();
                foreach ( var error in response.CustomErrors)
                {
                    
                    modelState.AddModelError(error.PropertyName, error.Description);
                }

                return BadRequest(modelState);

            }
            return NotFound(response.Message);
        }
        [HttpPut]
        public IActionResult TPutActionInstance<T>(Response<T> response) where T : class
        {
            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                return Ok(response.CustomErrors);
            }
            return NotFound(response.Message);
        }
        [HttpGet]
        public IActionResult TGetBaseActionInstance<T>(Response<T> response) where T: class
        {

            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            return NotFound(response);
        }
        

    }
}
