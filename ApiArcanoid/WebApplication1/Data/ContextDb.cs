using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ContextDb : DbContext
    {
       

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BallSkin> BallSkins { get; set; }
        public DbSet<UserSkin> UserSkins { get; set; }
    }
}
