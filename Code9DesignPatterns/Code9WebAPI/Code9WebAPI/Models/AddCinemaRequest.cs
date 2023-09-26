using System.ComponentModel.DataAnnotations;

namespace Code9WebAPI.Models
{
    public class AddCinemaRequest
    {
        [Required]
        [MinLength(3)]
        [StringLength(15, ErrorMessage = "The cinema name cannot exceed 15 characters. ")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int NumberOfAuditoriums { get; set; }
    }
}
