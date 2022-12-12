using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName, request.LastName, request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );

            //AuthenticationResponse response = NewMethod(authResult);
            //return Ok(response);
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email, request.Password);

            //custom logi
            if(authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode:StatusCodes.Status401Unauthorized,
                    title:authResult.FirstError.Description
                    );
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
            //return Ok(response);
        }

        //private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        //{
        //    var response = new AuthenticationResponse(
        //        authResult.User.Id,
        //        authResult.User.FirstName,
        //        authResult.User.LastName,
        //        authResult.User.Email,
        //        authResult.Token
        //    );
        //}
    }
}
