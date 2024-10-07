using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
             RuleFor(x => x.Description).NotEmpty().WithMessage("Aciqlama Bolmesini Bos Buraxa Bilmezsiniz...");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Sekil Yukleyin");

        }
    }
}
