using System.ComponentModel.DataAnnotations;

namespace TraversalProject.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage="Zəhmət olmasa adınızı daxil edin")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa soyadınızı daxil edin")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa istfifadəçi adınızı daxil edin")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa mailinizi daxil edin")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa şifrənizi daxil edin")]
		public string Password{ get; set; }
		[Required(ErrorMessage = "Zəhmət olmasa şifrənizi daxil edin")]
		[Compare("Password",ErrorMessage ="Zəhmət olmasa eyni şifrəni daxil edin")]
		public string ConfirmPassword { get; set; }
	}
}
