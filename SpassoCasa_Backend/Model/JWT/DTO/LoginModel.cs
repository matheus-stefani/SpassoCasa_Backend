using System.ComponentModel.DataAnnotations;

namespace SpassoCasa_Backend.Model.JWT.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "É preciso informar o Nome de Usuario")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "É preciso informar a senha")]
        public string? Password { get; set; }
    }
}
