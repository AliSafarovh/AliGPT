using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void  Validate(IValidator validator,object entity) //IValidator tipinden validator (mes:Product tipinden )
            //object entity(istenilen tipden enity)
        {
            var context = new ValidationContext<object>(entity); //gonderilen entitini contextde beraber et

            var result = validator.Validate(context); //ve hemin contexti validatorda yoxla
            if (!result.IsValid)//eger dogrulama serti odenmese
            {
                throw new ValidationException(result.Errors); //xeta mesajini gonder
            }
        }
    }
}
