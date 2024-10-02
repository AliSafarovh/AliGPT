using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş ola bilməz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş ola bilməz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş ola bilməz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Ən az 5 uzunluqda olmalıdır");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Ən çox 20 uzunluqda olmalıdır");
            RuleFor(x => x.Password).NotEmpty().WithMessage("şifrəni daxil edin");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("şifrəni təkrar daxil edin");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifrələr uyğun deyil");
        }
    }
}
