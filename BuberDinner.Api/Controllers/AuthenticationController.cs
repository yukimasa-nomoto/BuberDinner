using BuberDinner.Api.Filters;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //private readonly IAuthenticationService _authenticationService;

        //public AuthenticationController(IAuthenticationService authenticationService)
        //{
        //    _authenticationService = authenticationService;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            //var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            var command = _mapper.Map<RegisterCommand>(request);

            var authResult = await _mediator.Send(command);

            //var authResult = _authenticationService.Register(
            //    request.FirstName, request.LastName, request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );

            //AuthenticationResponse response = NewMethod(authResult);
            //return Ok(response);
        }

        //private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        //{
        //    return new AuthenticationResponse(
        //        authResult.User.Id,
        //        authResult.User.FirstName,
        //        authResult.User.LastName,
        //        authResult.User.Email,
        //        authResult.Token
        //    );
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            //var query = new LoginQuery(request.Email, request.Password);
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            //var authResult = _authenticationService.Login(
            //    request.Email, request.Password);

            //custom logi
            if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode:StatusCodes.Status401Unauthorized,
                    title:authResult.FirstError.Description
                    );
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
            //return Ok(response);
        }

    }
}
