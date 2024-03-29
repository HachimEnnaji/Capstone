using System.ComponentModel.DataAnnotations;

namespace Capstone.Model
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string Ruolo { get; set; }
        public string? Email { get; set; }
        public string? Cellulare { get; set; }
        public string? Città { get; set; }
        public string? Indirizzo { get; set; }
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Il CAP deve essere composto da 5 cifre")]
        public string? Cap { get; set; }
        public string? Longitudine { get; set; }
        public string? Latitudine { get; set; }
        public bool isOnline { get; set; }
        public string? Immagine { get; set; }
        public virtual List<SelezioneServizi> SelezioneServizi { get; set; }
        public virtual List<Recensioni> Recensioni { get; set; }
    }
}
