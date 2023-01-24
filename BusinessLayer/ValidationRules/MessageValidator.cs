using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezsiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Açıklamasını Boş Geçemezsiniz!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriğini Boş Geçemezsiniz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Giriniz!");
            RuleFor(x => x.Subject).MaximumLength(30).WithMessage("Lütfen 150 Karakterden Fazla Değer Gririşi Yapmayınız!");
        }

    }
}
