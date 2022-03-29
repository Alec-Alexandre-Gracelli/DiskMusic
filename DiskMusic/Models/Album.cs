using System.ComponentModel.DataAnnotations;

namespace DiskMusic.Models
{
    public class Album
    {
        public Guid AlbumId { get; set; }
        [Required]
        [Display(Name = " Nome do Álbum")]
        [StringLength(20, ErrorMessage ="Ultrapassou o limite de caracteres...")]
        public string AlbumNome { get; set; }

        [Required]
        [Display(Name = " Nome da Banda")]
        [StringLength(50, ErrorMessage = "Ultrapassou o limite de caracteres...")]
        public string BandaNome { get; set; }  
        
        [Display(Name = " Imagem do Álbum")]
        public string AlbumImagem { get; set; }

        [Display(Name = " Ano do Lançamento")]
        public short Anolancamento { get; set; }

        [Display(Name = " É Favorito?")]
        public bool EhFavorito { get; set; }

        public ICollection<Musica> Musicas { get; set;}
    }
}
