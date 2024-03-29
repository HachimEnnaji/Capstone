using System.ComponentModel.DataAnnotations;

namespace Capstone.Model
{
    public class Azienda
    {
        [Key]
        public int IdAzienda { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]

        public string Città { get; set; }
        [Required]
        public string Indirizzo { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Il CAP deve essere composto da 5 cifre")]
        public string Cap { get; set; }
        public string? Longitudine { get; set; }
        public string? Latitudine { get; set; }

        public string? Immagine { get; set; }
        public virtual List<Recensioni> Recensioni { get; set; }
        public virtual List<Servizi> Servizi { get; set; }

    }
}
