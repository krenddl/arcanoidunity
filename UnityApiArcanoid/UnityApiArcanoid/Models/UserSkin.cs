using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnityApiArcanoid.Models
{
    public class UserSkin
    {
        [Key]
        public int id_UserSkin { get; set; }
        [ForeignKey("user")]
        public int user_id { get; set; }
        public User user;
        [ForeignKey("ballSkin")]
        public int ballSkin_id { get; set; }
        public BallSkin ballSkin { get; set; }
        public bool isSelected { get; set; }


    }
}
