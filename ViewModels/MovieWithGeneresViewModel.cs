using lec5MVCL.Models;

namespace lec5MVCL.ViewModels
{
    public class MovieWithGeneresViewModel
    {
        public Movie Movie { get; set; } = new Movie() { Title = string.Empty };

        public List<SelectGenre> Genres { get; set; } = [];


    }

    public class SelectGenre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
