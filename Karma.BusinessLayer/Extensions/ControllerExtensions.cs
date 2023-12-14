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
               
                return BadRequest(response.CustomErrors) ;

            }
            return NotFound(response);
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
                return BadRequest(response.CustomErrors);
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
