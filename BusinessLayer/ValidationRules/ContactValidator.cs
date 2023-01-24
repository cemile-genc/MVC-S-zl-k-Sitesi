using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {

            public ContactValidator()
            {
                RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz!");
                RuleFor(x => x.UserMail).NotEmpty().WithMessage("Kullanıcı E-Mail Açıklamasını Boş Geçemezsiniz!");
                RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Açıklamasını Boş Geçemezsiniz!");
                RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz!");
                RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz!");
                RuleFor(x => x.Subject).MinimumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz!");
                RuleFor(x => x.Message).MaximumLength(30).WithMessage("Lütfen 30 Karakterden Fazla Değer Gririşi Yapmayınız!");
            }
       
    }
}
