using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Model
{
    public class SelezioneServizi
    {
        [Key]
        public int IdSelezioneServizio { get; set; }

        [Required]
        public string TipoServizio { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public TimeSpan Ora { get; set; }
        [Required]
        [ForeignKey("IdUser")]
        public int IdUser_Fk { get; set; }
        [Required]
        [ForeignKey("IdServizio")]
        public int IdServizio_Fk { get; set; }

        public virtual User User { get; set; }
        public virtual Servizi Servizi { get; set; }
    }
}
