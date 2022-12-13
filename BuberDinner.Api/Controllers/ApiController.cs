﻿using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiController : Controller
    {
        protected IActionResult Problem(List<Error>errors)
        {
            if(errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(x => x.Type == ErrorType.Validation))
            {
                return ValidationProblen(errors);
            }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];

            return Problem(firstError);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblen(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem(modelStateDictionary);
        }
    }
}
