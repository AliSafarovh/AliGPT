using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.DTOs.Groups;

namespace UniversityApi.Data.Validators
{
    public class GroupValidator : AbstractValidator<GroupPostDTO>
    {
        public GroupValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Qrupun adini daxil edin")
                .MaximumLength(10).WithMessage("Qrupun adi 10 simvoldan cox ola bilmez");
        }
    }
}
