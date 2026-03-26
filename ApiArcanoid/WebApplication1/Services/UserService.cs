using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Requests;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly ContextDb _context;

        public UserService(ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
                return new BadRequestObjectResult(new { status = "Логин и пароль обязательны" });

            var exists = await _context.Users.FirstOrDefaultAsync(x => x.Login == request.Login);
            if (exists != null)
                return new BadRequestObjectResult(new { status = "Логин уже занят" });

            var user = new User
            {
                Login = request.Login,
                Password = request.Password,
                Coins = 100
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            await _context.UserSkins.AddAsync(new UserSkin
            {
                user_id = user.id_User,
                ballSkin_id = 1,
                isSelected = true
            });

            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Status = true,
                UserId = user.id_User
            });
        }

        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == request.Password);

            if (user == null)
                return new UnauthorizedObjectResult(new { status = "Неправильный логин или пароль" });

            return new OkObjectResult(new
            {
                Status = true,
                UserId = user.id_User
            });
        }

        public async Task<IActionResult> GetCoinsAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id_User == userId);
            if (user == null)
                return new NotFoundObjectResult(new { status = "User not found" });

            return new OkObjectResult(new
            {
                Coins = user.Coins
            });
        }

        public async Task<IActionResult> AddCoinsAsync(AddCoinsRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id_User == request.UserId);
            if (user == null)
                return new NotFoundObjectResult(new { status = "Пользователь не найден" });

            if (request.Amount <= 0)
                return new BadRequestObjectResult(new { status = "Сумма должна быть больше нуля" });

            user.Coins += request.Amount;
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Status = true,
                Coins = user.Coins
            });
        }

        public async Task<IActionResult> GetSelectedSkinAsync(int userId)
        {
            var selected = await _context.UserSkins
                .Include(x => x.ballSkin).Include(x => x.user)
                .FirstOrDefaultAsync(x => x.user_id == userId && x.isSelected);

            if (selected == null)
                return new NotFoundObjectResult(new { status = "Выбранный скин не найден" });

            return new OkObjectResult(new
            {
                SkinId = selected.ballSkin_id,
                Name = selected.ballSkin.Name
            });
        }

        public async Task<IActionResult> GetSkinsAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return new NotFoundObjectResult(new { status = "Пользователь не найден" });

            var skins = await _context.BallSkins.ToListAsync();
            var userSkins = await _context.UserSkins
                .Where(x => x.user_id == userId)
                .ToListAsync();

            

            return new OkObjectResult(new
            {
                Skins = skins.Select(skin =>
                {
                    var userSkin = userSkins.FirstOrDefault(x => x.ballSkin_id == skin.id_BallSkin);

                    return new
                    {
                        skinId = skin.id_BallSkin,
                        name = skin.Name,
                        price = skin.Price,
                        isPurchased = userSkin != null,
                        isSelected = userSkin != null && userSkin.isSelected
                    };
                }).ToList()
            });
        }

        public async Task<IActionResult> BuySkinAsync(BuySkinRequest request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return new NotFoundObjectResult(new { status = "Пользователь не найден" });

            var skin = await _context.BallSkins.FindAsync(request.SkinId);
            if (skin == null)
                return new NotFoundObjectResult(new { status = "Скин не найден" });

            var alreadyPurchased = await _context.UserSkins
                .FirstOrDefaultAsync(x => x.user_id == request.UserId && x.ballSkin_id == request.SkinId);

            if (alreadyPurchased != null)
                return new BadRequestObjectResult(new { status = "Скин уже куплен" });

            if (user.Coins < skin.Price)
                return new BadRequestObjectResult(new { status = "Не хватает монет" });

            user.Coins -= skin.Price;

            await _context.UserSkins.AddAsync(new UserSkin
            {
                user_id = request.UserId,
                ballSkin_id = request.SkinId,
                isSelected = false
            });

            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                Status = true,
                Coins = user.Coins
            });
        }

        public async Task<IActionResult> SelectSkinAsync(SelectSkinRequest request)
        {
            var ownedSkins = await _context.UserSkins
                .Where(x => x.user_id == request.UserId)
                .ToListAsync();

            var selectedSkin = ownedSkins.FirstOrDefault(x => x.ballSkin_id == request.SkinId);

            if (selectedSkin == null)
                return new BadRequestObjectResult(new { status = "Скина нету" });

            foreach (var item in ownedSkins)
                item.isSelected = false;

            selectedSkin.isSelected = true;

            await _context.SaveChangesAsync();

            return new OkObjectResult(new { Status = true });
        }
    }
}
