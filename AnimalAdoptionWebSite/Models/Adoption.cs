using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Models
{
    public class Adoption
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ADOPTION_ID { get; set; }

        //her sahiplenmenin bir adet üyesi olur
        [ForeignKey("Member")]
        public int MEMBER_ID { get; set; }
        public Member Member { get; set; }
        //her sahiplenemde bir animal bulunur.
        [ForeignKey("Animal")]
        public int ANIMAL_ID { get; set; }
        public Animal Animal { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [DataType(DataType.Date)]
        public DateTime DATE { get; set; }
    }
}
