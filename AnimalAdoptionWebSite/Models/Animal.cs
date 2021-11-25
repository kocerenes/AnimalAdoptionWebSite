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
        public Kind Kind { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        public string NAME { get; set; }

        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        [DisplayFormat(NullDisplayText = "Bilinmiyor")]
        public string GENUS { get; set; }

        [DisplayFormat(NullDisplayText = "Bilinmiyor")]
        public byte AGE { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(20, ErrorMessage = "20 karakteri aşmayınız!")]
        public string CITY { get; set; }

        public bool STATUS { get; set; } = true; //sahiplenilen canlıların durumu false olacak

        public ICollection<Adoption> Adoptions { get; set; }
    }
}
