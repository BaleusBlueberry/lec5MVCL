using lec5MVCL.Models;

namespace lec5MVCL.ViewModels
{
    public class SongAlbomsViewModel
    {
        public Song Song { get; set; } = new Song() { Title = string.Empty };
        public List<Album> Albums { get; set; } = [];
    }
}
