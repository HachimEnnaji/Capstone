using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Model
{
    public class Recensioni
    {
        [Key]
        public int IdRecensione { get; set; }
        [Required]
        public string Testo { get; set; }
        [Required]
        [Range(1, 5)]
        public int Voto { get; set; }
        [Required]
        [ForeignKey("IdUser")]
        public int IdUser_Fk { get; set; }
        [Required]
        [ForeignKey("IdAzienda")]
        public int IdAzienda_Fk { get; set; }

        public virtual User User { get; set; }
        public virtual Azienda Azienda { get; set; }
    }
}
