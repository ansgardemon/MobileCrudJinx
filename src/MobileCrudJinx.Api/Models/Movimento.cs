using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileCrudJinx.Api.Models
{
    public class Movimento
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int QuantidadeMovimento { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }




    }
}
