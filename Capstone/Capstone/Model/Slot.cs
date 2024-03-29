using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Model
{
    public class Slot
    {
        [Key]
        public int IdSlot { get; set; }
        [Required]
        public string fasciaOraria { get; set; }
        [NotMapped]
        public int MaxPrenotazioni { get; set; } = 10;
        public int numPrenotazioni { get; set; } = 0;

        [Required]
        [ForeignKey("IdServizio")]
        public int IdServizio_Fk { get; set; }
        [Required]
        [ForeignKey("IdGiorno")]
        public int Giorno_FK { get; set; }

        public virtual Servizi Servizi { get; set; }
        public virtual Giorno GiornoCorrente { get; set; }
    }
}
