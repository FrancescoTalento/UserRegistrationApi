using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.DTO
{
    public record CreateUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }


    }
}
