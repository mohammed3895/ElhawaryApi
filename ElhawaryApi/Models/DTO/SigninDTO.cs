using System.ComponentModel.DataAnnotations;

namespace ElhawaryApi.Models.DTO
{
    public class SigninDTO
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
