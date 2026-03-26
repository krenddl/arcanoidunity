using Microsoft.AspNetCore.Mvc;
using WebApplication1.Requests;

namespace WebApplication1.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> RegisterAsync(RegisterRequest request);
        Task<IActionResult> LoginAsync(LoginRequest request);
        Task<IActionResult> GetCoinsAsync(int userId);
        Task<IActionResult> AddCoinsAsync(AddCoinsRequest request);
        Task<IActionResult> GetSelectedSkinAsync(int userId);
        Task<IActionResult> GetSkinsAsync(int userId);
        Task<IActionResult> BuySkinAsync(BuySkinRequest request);
        Task<IActionResult> SelectSkinAsync(SelectSkinRequest request);
    }
}
