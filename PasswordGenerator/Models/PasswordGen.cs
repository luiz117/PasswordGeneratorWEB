using System.ComponentModel.DataAnnotations;

namespace PasswordGenerator.Models
{
    public class PasswordGen
    {
        [Display(Name ="Size")]
        [Range(7, 25, ErrorMessage = "Can only be between 7 .. 25")]
        public int? Size { get; set; }
        public string? Password { get; set; }
    }
}
