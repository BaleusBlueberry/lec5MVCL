using System.ComponentModel.DataAnnotations;

namespace lec5MVCL.Models;

public class Album
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    //Navigation Property:
    public ICollection<Song> Songs { get; set; } = [];
}