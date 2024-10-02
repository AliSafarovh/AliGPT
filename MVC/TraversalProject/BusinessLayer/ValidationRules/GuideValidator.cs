using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Zəhmət Olmasa Tur Rəhbərinin adını daxil edin");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Zəhmət Olmasa Tur Rəhbərinin açıqlamasını daxil edin");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Zəhmət Olmasa Tur Rəhbəri şəkil əlavə edin ");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Zəhmət Olmasa 30 xarakterdən çox simvol əlavə etməyin");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("Zəhmət Olmasa ən az 8 xarakterli simvol əlavə edin");
        }
    }
}
