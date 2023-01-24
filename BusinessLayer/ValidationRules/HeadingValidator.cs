using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator() 
        {
            RuleFor(x => x.HeadingName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz!");
        }



    }
}
