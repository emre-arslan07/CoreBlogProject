using BlogProject.Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogProject.Bll.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar ad soyad kısmı boş geçilemez!!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterPasswordConfirm).NotEmpty().WithMessage("Şifre tekrar boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");

            RuleFor(x => x.WriterPassword).Equal(x => x.WriterPasswordConfirm).WithMessage("Şifreler eşleşmiyor");
            RuleFor(x => x.WriterPassword).Must(IsValid).WithMessage("Parolanız en az 8 karakter,en az bir harf ve bir sayı içermelidir");
        }

        private bool IsValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
                return regex.IsMatch(arg);
            }
            catch
            {
               return false;
            }
        }
    }
}
