using DiskMusic.Data;
using DiskMusic.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ImobAdmin.Extensions
{
    public class DropDown
    {

        public static async Task<List<SelectListGenerica>> RetornaAlbuns(ApplicationDbContext _context)
        {
            return await _context.Albuns
                .OrderBy(o => o.AlbumNome)
                .Select(s => new SelectListGenerica
                {
                    ID = s.AlbumId,
                    Nome = s.AlbumNome,

                }).ToListAsync();
        }

        public static async Task<List<SelectListGenerica>> RetornaMusicas(ApplicationDbContext _context)
        {
            return await _context.Musicas
                .OrderBy(o => o.Album.AlbumNome)
                .OrderBy(o => o.MusicaNome)
                .Select(s => new SelectListGenerica
                {
                    ID = s.MusicaId,
                    Nome = $"{s.Album.AlbumNome} - {s.MusicaNome}",

                }).ToListAsync();



        }
    }
}
