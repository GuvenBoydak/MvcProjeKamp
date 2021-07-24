using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidetionRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama kısmı boş geçemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adi en az 3 karakter olmalı");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori Adi En fazla 50 karakter olmalı");
        }

    }
}
