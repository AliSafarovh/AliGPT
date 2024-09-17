using System.ComponentModel.DataAnnotations;

namespace TraversalProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage="Zəhmət olmasa adınızı daxil edin")]
        public string  username { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa şifrəni daxil edin")]
        public string password { get; set; }

    }
}
