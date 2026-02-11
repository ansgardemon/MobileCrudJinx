using MobileCrudJinx.Client.DTOs;

public class MovimentoDto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int QuantidadeMovimento { get; set; }

    public int ProdutoId { get; set; }

    public ProdutoDto Produto { get; set; }
}
