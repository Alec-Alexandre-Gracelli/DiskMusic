using System.ComponentModel.DataAnnotations;

namespace DiskMusic.ViewModel
{
    public class DetailsViewModel
    {
        public Guid MusicaId { get; set; }

        [Display(Name = " Nome da Música")]
        [StringLength(20, ErrorMessage = "Ultrapassou o limite de caracteres...")]
        public string MusicaNome { get; set; }

        [Display(Name = " Nome do Álbum")]
        [StringLength(20, ErrorMessage = "Ultrapassou o limite de caracteres...")]
        public string AlbumNome { get; set; }
    }
}
