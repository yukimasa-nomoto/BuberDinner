using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;


        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1.validate the user exists
            if (_userRepository.GetUserByEmail(command.Email) is not User user)
            {
                //throw new Exception("User with given email does not exists");
                return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;

            }

            //2.validate the password is correct
            if (user.Password != command.Password)
            {
                //throw new Exception("Invalid password");
                return new[] { Domain.Common.Errors.Errors.Authentication.InvalidCredentials };
            }

            //3.create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
