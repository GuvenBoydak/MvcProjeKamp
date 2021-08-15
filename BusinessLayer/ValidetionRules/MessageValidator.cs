using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidetionRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresi Boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmı boş geçemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En az 3 Karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 Karakterden fazla deger girmeyiniz");
        }

    }
}
