using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Requests;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return await _userService.RegisterAsync(request);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return await _userService.LoginAsync(request);
        }

        [HttpGet("{userId}/coins")]
        public async Task<IActionResult> GetCoins(int userId)
        {
            return await _userService.GetCoinsAsync(userId);
        }

        [HttpPost("add-coins")]
        public async Task<IActionResult> AddCoins([FromBody] AddCoinsRequest request)
        {
            return await _userService.AddCoinsAsync(request);
        }

        [HttpGet("{userId}/selected-skin")]
        public async Task<IActionResult> GetSelectedSkin(int userId)
        {
            return await _userService.GetSelectedSkinAsync(userId);
        }

        [HttpGet("{userId}/skins")]
        public async Task<IActionResult> GetSkins(int userId)
        {
            return await _userService.GetSkinsAsync(userId);
        }

        [HttpPost("buy-skin")]
        public async Task<IActionResult> BuySkin([FromBody] BuySkinRequest request)
        {
            return await _userService.BuySkinAsync(request);
        }

        [HttpPost("select-skin")]
        public async Task<IActionResult> SelectSkin([FromBody] SelectSkinRequest request)
        {
            return await _userService.SelectSkinAsync(request);
        }
    }
}