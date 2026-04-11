using HA_Ossooll.Data.DTOs;
using HA_Ossooll.Data.Models;
using HA_Ossooll.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HA_Ossooll.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // ================= REGISTER =================
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            var email = model.Email.Trim().ToLower();   // ✅ مهم
            var username = model.Username.Trim();
            var firstName = model.FirstName.Trim();
            var lastName = model.LastName.Trim();
            var password = model.Password;

            if (await _userManager.FindByEmailAsync(email) != null)
                return new AuthModel { Message = "Email already exists ❌" };

            if (await _userManager.FindByNameAsync(username) != null)
                return new AuthModel { Message = "Username already exists ❌" };

            var user = new ApplicationUser
            {
                Email = email,
                UserName = username,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthModel { Message = errors };
            }

            return new AuthModel
            {
                IsAuthenticated = true,
                Email = user.Email,
                Username = user.UserName,
                Message = "User registered successfully ✅"
            };
        }

        // ================= LOGIN =================
        public async Task<AuthModel> LoginAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var email = model.Email.Trim().ToLower();   // ✅ الحل الرئيسي هنا
            var password = model.Password;

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                authModel.Message = "User not found ❌";
                return authModel;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                authModel.Message = "Password is incorrect ❌";
                return authModel;
            }

            var jwtToken = CreateJwtToken(user);

            authModel.IsAuthenticated = true;
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.Message = "Login successful ✅";
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.ExpiresOn = jwtToken.ValidTo;

            return authModel;
        }

        // ================= JWT =================
        private JwtSecurityToken CreateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(
                    double.Parse(_configuration["JWT:DurationInDays"]!)
                ),
                signingCredentials: creds
            );

            return jwtToken;
        }
    }
}