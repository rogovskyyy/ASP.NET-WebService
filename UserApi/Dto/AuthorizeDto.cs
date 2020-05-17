using System.ComponentModel.DataAnnotations;

namespace UserApi.Dto
{
    public class AuthorizeDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}