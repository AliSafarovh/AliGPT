using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.DTOs.Student;

namespace UniversityApi.Data.Validators
{
   public class StudentValidator : AbstractValidator<StudentPostDTO>
    {
        public StudentValidator() 
        {
            // image/png,image/jpeg,image/svg,image/webp
            RuleFor(x => x.File)
                .Must(f => f == null || f.ContentType.Contains("image"))
                .WithMessage("Fayl sekil formatinda olmalidir")
                .Must(f => f == null || f.Length / 1024 <= 200)
                .WithMessage("Faylin olcusu 200kb-den cox olmamalidir");
        }
    }
}
