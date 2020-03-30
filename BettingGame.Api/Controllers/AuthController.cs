using AutoMapper;
using BettingGame.Core.Exceptions.Auth;
using BettingGame.Core.Models.Domain;
using BettingGame.Core.Models.Transfer.Auth;
using BettingGame.Core.Models.ViewModel;
using BettingGame.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BettingGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpGet("EmailExists")]
        public async Task<ActionResult<bool>> EmailExists([FromQuery] EmailExistsQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool emailExists = await _authService.EmailExists(query.Email);

            return Ok(emailExists);
        }

        [Authorize]
        [HttpGet("Authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthenticatedUser>> Authenticate()
        {
            (User user, string token) = await _authService.Authenticate();

            AuthenticatedUser authenticatedUser = _mapper.Map<User, AuthenticatedUser>(user, options =>
            {
                options.Items.Add("Token", token);
            });

            return Ok(authenticatedUser);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthenticatedUser>> Login([FromBody] LoginDto credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                (User user, string token) = await _authService.Login(credentials);

                AuthenticatedUser authenticatedUser = _mapper.Map<User, AuthenticatedUser>(user, options =>
                {
                    options.Items.Add("Token", token);
                });

                return Ok(authenticatedUser);
            }
            catch (InvalidCredentialsException exception)
            {
                ModelState.AddModelError(exception.ModelStateKey, exception.Message);
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] RegisterDto credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authService.Register(credentials);

            return NoContent();
        }
    }
}
