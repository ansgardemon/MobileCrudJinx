using System.Net.Http.Json;
using MobileCrudJinx.Client.DTOs;

namespace MobileCrudJinx.Client.Services
{
    public class MovimentoService
    {
        private readonly HttpClient _http;

        public MovimentoService(HttpClient http)
        {
            _http = http;
        }

        // GET: api/movimento
        public async Task<List<MovimentoDto>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<MovimentoDto>>("api/movimento")
                   ?? new();
        }

        // GET: api/movimento/produto/5
        public async Task<List<MovimentoDto>> GetByProduto(int produtoId)
        {
            return await _http.GetFromJsonAsync<List<MovimentoDto>>($"api/movimento/produto/{produtoId}")
                   ?? new();
        }

        // POST: api/movimento
        public async Task Create(MovimentoCreateDTO dto)
        {
            var response = await _http.PostAsJsonAsync("api/movimento", dto);
            response.EnsureSuccessStatusCode();
        }
    }
}
