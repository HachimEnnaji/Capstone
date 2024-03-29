using System.ComponentModel.DataAnnotations;

namespace Capstone.DTO.UserDTO
{
    public class RegistrationDTO
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
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

    }
}
