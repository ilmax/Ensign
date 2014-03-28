using System.ComponentModel.DataAnnotations;

namespace EnsignLib.Examples.SimpleCustomBacking.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
    }
}