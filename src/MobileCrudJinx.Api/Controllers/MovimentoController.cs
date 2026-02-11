using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileCrudJinx.Api.Data;
using MobileCrudJinx.Api.DTOs;
using MobileCrudJinx.Api.Models;

namespace MobileCrudJinx.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Movimento>> Get()
            => await _context.Movimentos
            .Include(m => m.Produto)
            .ToListAsync();


        // GET: api/movimento/produto/5
        [HttpGet("produto/{Id}")]
        public async Task<ActionResult<IEnumerable<Movimento>>> GetById(int Id)
        {
            var movimentos = await _context.Movimentos
                .Where(m => m.Id == Id)
                .Include(m => m.Produto)
                .ToListAsync();

            return Ok(movimentos);
        }

        // POST: api/movimento
        [HttpPost]
        public async Task<ActionResult> Post(MovimentoInputDTO dto)
        {
            var produto = await _context.Produtos.FindAsync(dto.ProdutoId);
            if (produto == null)
                return NotFound("Produto não encontrado");

            var movimento = new Movimento
            {
                ProdutoId = dto.ProdutoId,
                QuantidadeMovimento = dto.QuantidadeMovimento,
                Descricao = dto.Descricao
            };

            // Atualiza estoque
            produto.Estoque += dto.QuantidadeMovimento;

            _context.Movimentos.Add(movimento);
            await _context.SaveChangesAsync();

            return Ok(movimento);
        }
    }
}
