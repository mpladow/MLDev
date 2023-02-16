using Microsoft.AspNetCore.Identity;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services.Interfaces;

namespace MLDev.LOTOW.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private IUserAuthenticationRepository _repository;

        public UserAuthenticationService(IUserAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public Task<RegisterUserResult> RegisterNewUser(UserRegistrationDto userRegistration)
        {
            return _repository.RegisterUserAsync(userRegistration);
        }
    }
}
