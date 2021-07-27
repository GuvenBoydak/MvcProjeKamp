using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidetionRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı boş geçilemez");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı en az 2 karakter olmalı");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar Soyadı En fazla 50 karakter olmalı");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar EMail boş geçilemez");
            RuleFor(x => x.WriterAbout).MinimumLength(10).WithMessage("Yazar Hakkında en az 10 karakter olmalı");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Yazar Hakkında En fazla 100 karakter olmalı");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı boş geçilemez");
            //RuleFor(x => x.WriterName).Must(ContainsA).WithMessage("Yazar Adı a Harfı içermelidir");
        }

        private bool ContainsA(string arg)
        {
            bool result = arg.Contains("a");
            return result;
        }


    }
}
