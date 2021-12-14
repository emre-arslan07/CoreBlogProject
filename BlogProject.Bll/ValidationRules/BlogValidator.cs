using BlogProject.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Bll.ValidationRules
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı boş bırakılamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş bırakılamaz");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen en fazla 150 karakter girişi yapınız");
            RuleFor(x => x.BlogTitle).MinimumLength(4).WithMessage("Lütfen en az 4 karakter girişi yapınız");
        }
    }
}
