using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidetionRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Konu Adı en az 2 karakter olmalı");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu Adı En fazla 50 karakter olmalı");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kulanıcı Adı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kulanıcı Adı en az 3 karakter olmalı");

        }
    }
}