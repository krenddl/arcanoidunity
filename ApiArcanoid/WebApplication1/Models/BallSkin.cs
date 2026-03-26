using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class BallSkin
    {
        [Key]
        public int id_BallSkin { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [JsonIgnore]
        public ICollection<UserSkin> userSkins { get; set; }
    }
}
