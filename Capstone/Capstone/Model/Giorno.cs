using System.ComponentModel.DataAnnotations;

namespace Capstone.Model
{
    public class Giorno
    {
        [Key]
        public int IdGiorno { get; set; }
        public DateTime GiornoCorrente { get; set; }
        public virtual List<Slot> Slots { get; set; }
    }
}
