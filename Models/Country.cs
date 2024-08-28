using System.ComponentModel.DataAnnotations;

namespace lec5MVCL.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }

        public Capital? Capital { get; set; }
    }
}
