using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models;
using MLDev.LOTOW.Repositories.Interfaces;

namespace MLDev.LOTOW.Repositories
{
    public class UserAuthenticationRespository : IUserAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        public UserAuthenticationRespository(IMapper mapper, UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<RegisterUserResult> RegisterUserAsync(UserRegistrationDto userForRegistration)
        {
            var DUMMYROLENAME = "Admin";
            IdentityResult result;
            var newUser = _mapper.Map<User>(userForRegistration);

            result = await _userManager.CreateAsync(newUser, userForRegistration.Password);

            if (!result.Succeeded)
            {
                return new RegisterUserResult { Succeeded = false, Errors = result.Errors.Select(e => e.Description) };
            }
            await SeedRoles();
            result = await _userManager.AddToRoleAsync(newUser, DUMMYROLENAME);

            return new RegisterUserResult { Succeeded = true };
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new AppRole("Admin"));
            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new AppRole("User"));
        }
        //public async Task<IdentityResult> Login(User user)
        //{
        //    var userExists = await _userManager.FindByEmailAsync(user.Email);
        //    if (user != null)
        //    {

        //    }
        //    return new IdentityResult();
        //}

    }
}
