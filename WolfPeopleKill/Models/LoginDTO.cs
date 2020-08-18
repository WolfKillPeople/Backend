using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WolfPeopleKill.Models
{
    public class LoginDTO
    {
        [Required]
        [JsonProperty("username")]
        public string userName { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
