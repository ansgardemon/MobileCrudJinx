using MobileCrudJinx.Api.Models;

namespace MobileCrudJinx.Api.DTOs
{
    public class MovimentoInputDTO
    {

        public string Descricao { get; set; }
        public int QuantidadeMovimento { get; set; }
        public int ProdutoId { get; set; }



    }
}
