using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionWebSite.Models
{
    public class Kind
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte KIND_ID { get; set; }

        [Required(ErrorMessage = "Bu alanı doldurmak zorunlu!")]
        [MaxLength(25, ErrorMessage = "25 karakteri aşmayınız!")]
        public string TYPE_NAME { get; set; }

        //bir tür birden fazla hayvana ait olabilir.
        public ICollection<Animal> Animals { get; set; }
    }
}
