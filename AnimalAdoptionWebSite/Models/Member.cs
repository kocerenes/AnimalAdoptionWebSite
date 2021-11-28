using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Models
{
    public class Member
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MEMBER_ID { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(50, ErrorMessage = "50 karakteri aşmayınız!")]
        [Display(Name = "Ad Soyad")]
        public string NAMESURNAME { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(50, ErrorMessage = "50 karakteri aşmayınız!")]
        [Display(Name = "Mail")]
        public string MAIL { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        [Display(Name = "Şifre")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [Range(18, 50, ErrorMessage = "Üyelerin yaş aralığı 18-50 olmalıdır!")]
        [Display(Name = "Yaş")]
        public byte AGE { get; set; }

        [MaxLength(11, ErrorMessage = "11 karakteri aşmayınız!")]
        [DisplayFormat(NullDisplayText = "---")]
        [Display(Name = "Telefon No")]
        public string PHONENUMBER { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(120, ErrorMessage = "120 karakteri aşmayınız!")]
        [Display(Name = "Adres")]
        public string ADDRESS { get; set; }

        [MaxLength(200, ErrorMessage = "200 karakteri aşmayınız!")]
        [DisplayFormat(NullDisplayText = "---")]
        [Display(Name = "Hakkında")]
        public string ABOUT { get; set; }

        //üyeler birden fazla sahiplenme yapabilir
        public ICollection<Adoption> Adoptions { get; set; }
    }
}
