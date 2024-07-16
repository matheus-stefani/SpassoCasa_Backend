using System.ComponentModel.DataAnnotations;

namespace SpassoCasa_Backend.Model.JWT.DTO
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "É preciso informar o Nome de Usuario")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "É preciso informar o Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "É preciso informar a Senha")]
        public string? Password { get; set; }


    }
}
