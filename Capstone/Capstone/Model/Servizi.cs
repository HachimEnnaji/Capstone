using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Model
{
    public class Servizi
    {
        [Key]
        public int IdServizio { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public double Prezzo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Immagine { get; set; }
        [Required]
        [ForeignKey("IdAzienda")]
        public int IdAzienda_Fk { get; set; }

        public virtual Azienda Azienda { get; set; }
        public virtual List<SelezioneServizi> SelezioneServizi { get; set; }
        public virtual List<Slot> Slot { get; set; }

    }
}
