using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanını  Boş Geçemezsiniz!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazarın Hakkında Bir Şeyler Yazmalısınız!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz!");
            RuleFor(x => x.WriterAbout).MinimumLength(20).WithMessage("Lütfen En Az 20 Karakter Giriniz!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Gririşi Yapmayınız!");
        }
    }
}
