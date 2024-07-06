using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpassoCasa_Backend.Model
{
    public class Cadastro
    {
        [Key]
        public int CadastroId { get; set; }


        [StringLength(100)]
        [Required]
        public string NomeCompleto { get; set; }



        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }


        [StringLength(100)]
        [Required]
        public string Endereco { get; set; }


        [StringLength(30)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }


        [StringLength(100)]
        [Required]
        public string Senha { get; set; }



    }
}
