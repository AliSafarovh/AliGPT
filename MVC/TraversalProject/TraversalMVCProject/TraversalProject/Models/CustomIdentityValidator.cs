using Microsoft.AspNetCore.Identity;

namespace TraversalProject.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Şifrə uzunluğu ən az {length} xarakter olmalıdır"
			};

		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = $"Ən az 1 kiçik hərf olmalıdır"
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = $"Ən az 1 böyük hərf olmalıdır"
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Şifrənizdə ən azı bir rəqəm olmalıdır ('0'-'9')."
			};
		}
	}
}
