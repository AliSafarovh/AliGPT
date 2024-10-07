using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlıq boş ola bilməz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Elan boş ola bilməz");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("5 dən az ola bilməz");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("20 dn az ola bilməz");
            RuleFor(x => x.Title).MaximumLength(500).WithMessage("en cox 500 xareakter olmalidir");
            RuleFor(x => x.Content).MinimumLength(50).WithMessage("50 dən az ola bilməz");
        }
    }
}
