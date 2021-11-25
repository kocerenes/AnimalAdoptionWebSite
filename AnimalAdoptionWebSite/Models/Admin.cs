using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Models
{
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ADMIN_ID { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(50, ErrorMessage = "50 karakteri aşmayınız!")]
        public string NAMESURNAME { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(50, ErrorMessage = "50 karakteri aşmayınız!")]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(50, ErrorMessage = "50 karakteri aşmayınız!")]
        public string MAIL { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        public string PASSWORD { get; set; }

        [MaxLength(35, ErrorMessage = "35 karakteri aşmayınız!")]
        [DisplayFormat(NullDisplayText = "---")]
        public string OCCUPATION { get; set; } //meslek
    }
}
