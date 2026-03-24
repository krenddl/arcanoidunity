using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnityApiArcanoid.Models
{
    public class User
    {
        [Key]
        public int id_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        [JsonIgnore]
        public ICollection<UserSkin> userSkins { get; set; }
    }
}
