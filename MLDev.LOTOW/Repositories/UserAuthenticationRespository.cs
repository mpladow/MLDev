using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MLDev.LOTOW.Constants;
using MLDev.LOTOW.DTOs;
using MLDev.LOTOW.Models.Authentication;
using MLDev.LOTOW.Repositories.Interfaces;
using MLDev.LOTOW.Services;
using MLDev.LOTOW.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MLDev.LOTOW.Repositories
{
    public class UserAuthenticationRespository : IUserAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IJWTokenService _jwtService;
        public UserAuthenticationRespository(
            IMapper mapper, 
            UserManager<User> userManager, 
            RoleManager<AppRole> roleManager,
            IClaimsService claimsService,
            IJWTokenService jWTokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _claimsService = claimsService;
            _jwtService = jWTokenService;
             
        }

        public async Task<RegisterUserResult> RegisterUserAsync(UserRegistrationDto userForRegistration)
        {
            var DUMMYROLENAME = Roles.User;
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
        ////TODO: move to roles service
        //public async void UpdateUser(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        var result = await _userManager.AddToRoleAsync(user, Roles.Admin);
        //    }
        //}


        public async Task<UserLoginResultDto> LoginAsync(UserLoginDto user)
        {
            var userFound = await _userManager.FindByEmailAsync(user.Email);
            if(userFound  != null && await _userManager.CheckPasswordAsync(userFound, user.Password))
            {
                // get user claims
                var userClaims = await _claimsService.GetUserClaimsAsync(userFound);
                // generate jwt token
                var token = _jwtService.GetJwtSecurityToken(userClaims);

                return new UserLoginResultDto
                {
                    Succeeded = true,
                    Token = new TokenDto
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    }
                };
            }
            return new UserLoginResultDto
            {
                Succeeded = false,
                Message = "The Email and password combination was invalid"
            };

        }

        //public async Task<IdentityResult> Login(User user)
        //{
        //    var userExists = await _userManager.FindByEmailAsync(user.Email);
        //    if (user != null)
        //    {

        //    }
        //    return new IdentityResult();
        //}

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new AppRole("Admin"));
            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new AppRole("User"));
        }

    }
}
