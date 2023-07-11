using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PruebaTecnicaAPI.Core.Application.Dtos.Account;
using PruebaTecnicaAPI.Core.Application.Services;
using PruebaTecnicaAPI.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly JWTSettings _jwtSettings;

        public AccountService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager
        /*IOptions<JWTSettings> jwtSettings*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest req)
        {
            AuthenticationResponse res = new();

            var user = await _userManager.FindByEmailAsync(req.Email);
            if (user == null)
            {
                res.HasError = true;
                res.Error = $"No Accounts registered with {req.Email}.";
                return res;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, req.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                res.HasError = true;
                res.Error = $"Invalid Credentials for {req.Email}.";
                return res;
            }
            if (!user.EmailConfirmed)
            {
                res.HasError = true;
                res.Error = $"Account no confirmed for {req.Email}";
                return res;
            }

            //JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);

            res.Id = user.Id;
            //res.FirstName = user.FirstName;
            //res.LastName = user.LastName;
            res.Email = user.Email;
            res.UserName = user.UserName;
            var listRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            res.Roles = listRoles.ToList();
            res.IsVerified = user.EmailConfirmed;
            //res.TypeUser = user.TypeUser;
            //res.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            //var refreshToken = GenerateRefreshToken();
            //res.RefreshToken = refreshToken.Token;

            return res;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
