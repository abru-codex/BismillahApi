using System.ComponentModel.DataAnnotations;

namespace AbruApi.Dto.AuthDto
{
    public class RegisterationRequestDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string UserName { get; set; }
        public string? Email { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
