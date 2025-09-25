using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.DTO
{
    public record LoginUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
