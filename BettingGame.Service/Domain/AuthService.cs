using BettingGame.Core;
using BettingGame.Core.Exceptions.Auth;
using BettingGame.Core.Models.Domain;
using BettingGame.Core.Models.Transfer.Auth;
using BettingGame.Core.Options;
using BettingGame.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BettingGame.Service.Domain
{
    public class AuthService : IAuthService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICryptoService _cryptoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IOptions<JwtOptions> jwtOptions, IUnitOfWork unitOfWork, ICryptoService cryptoService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _cryptoService = cryptoService;
            _httpContextAccessor = httpContextAccessor;

            _jwtOptions = jwtOptions.Value;
        }

        public async Task<User> GetCurrentUser()
        {
            // Authorize the user via the "NameIdentifier" claim
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            User user = await _unitOfWork.UserRepository.GetUserById(int.Parse(userId));

            return user;
        }

        public async Task<(User user, string token)> Authenticate()
        {
            User user = await GetCurrentUser();

            // Extract the access token from the authorization header
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            string token = authorizationHeader.Split(' ').Last();

            return (user, token);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _unitOfWork.UserRepository.EmailExists(email);
        }

        public async Task<(User user, string token)> Login(LoginDto credentials)
        {
            // Look for a user account with given email address
            User user = await _unitOfWork.UserRepository.GetUserByEmail(credentials.Email);

            if (user == null)
            {
                throw new InvalidEmailException();
            }

            // Verify that the password is correct
            bool passwordsCorrect = _cryptoService.VerifyPassword(user.PasswordHash, user.PasswordSalt, credentials.Password);

            if (!passwordsCorrect)
            {
                throw new InvalidPasswordException();
            }

            // Generate jwt access token
            string token = _cryptoService.GenerateToken(user, _jwtOptions.Secret);
            
            return (user, token);
        }

        public async Task Register(RegisterDto credentials)
        {
            User user = new User
            {
                Email = credentials.Email,
                Username = credentials.Username,
            };

            // Generate salt + password hash
            byte[] salt = _cryptoService.GenerateSalt();
            byte[] hash = _cryptoService.HashPassword(credentials.Password, salt);

            user.PasswordSalt = salt;
            user.PasswordHash = hash;
            user.CreatedAt = DateTime.Now;

            // Save user to database
            await _unitOfWork.UserRepository.AddUser(user);
            await _unitOfWork.Commit();
        }
    }
}
