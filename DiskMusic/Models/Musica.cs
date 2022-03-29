using System.ComponentModel.DataAnnotations;

namespace DiskMusic.Models
{
    public class Musica
    {
        [Key]
        public Guid MusicaId { get; set; }
        public Guid AlbumId { get; set; }

        [Required]
        [Display(Name = " Nome da Música")]
        [StringLength(20, ErrorMessage = "Ultrapassou o limite de caracteres...")]
        public string MusicaNome { get; set; }

        public virtual Album Album { get; set; }

    }
}
