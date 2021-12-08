using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Models
{
    public class Animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ANIMAL_ID { get; set; }

        //her hayvanın bir türü olur
        [ForeignKey("Kind")]
        public byte KIND_ID { get; set; }
        [Display(Name = "Tür Adı")]
        public Kind Kind { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        [Display(Name = "İsim")]
        public string NAME { get; set; }

        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        [DisplayFormat(NullDisplayText = "Bilinmiyor")]
        [Display(Name = "Cins")]
        public string GENUS { get; set; }

        [DisplayFormat(NullDisplayText = "Bilinmiyor")]
        [Display(Name = "Yaş")]
        public byte AGE { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(20, ErrorMessage = "20 karakteri aşmayınız!")]
        [Display(Name = "Şehir")]
        public string CITY { get; set; }

        [Display(Name = "Fotoğraf")]
        public string PHOTO { get; set; }

        [Display(Name = "Mevcut Durumu")]
        public bool STATUS { get; set; } = true; //sahiplenilen canlıların durumu false olacak

        public ICollection<Adoption> Adoptions { get; set; }
    }
}
