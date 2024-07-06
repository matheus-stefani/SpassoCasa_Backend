using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpassoCasa_Backend.Model
{
    public class Produtos
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }


        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }

        
        public decimal Preco { get; set; }

        [Required]
        [StringLength(50)]
        public string EspecAntiDerrapante { get; set; }



        [Required]
        [StringLength(50)]
        public string EspecAntiCoeficiente { get; set; }




        [Required]
        [StringLength(300)]
        public string URLImagem { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
