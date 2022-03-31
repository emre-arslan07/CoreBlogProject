using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz")]
        public string NameSurname { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Display(Name ="Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Mail Adresi")]
        [Required(ErrorMessage ="Lütfen Mail Giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }
        public bool IsAcceptPolicy { get; set; }
    }
}
