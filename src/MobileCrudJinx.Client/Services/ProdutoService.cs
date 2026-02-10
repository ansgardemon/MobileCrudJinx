using MobileCrudJinx.Client.DTOs;
using System.Net.Http.Json;

namespace MobileCrudJinx.Client.Services
{
    public class ProdutoService
    {
        private readonly HttpClient _http;

        public ProdutoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProdutoDto>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<ProdutoDto>>("api/produto")
                   ?? new List<ProdutoDto>();
        }

        public async Task<ProdutoDto?> GetById(int id)
        {
            return await _http.GetFromJsonAsync<ProdutoDto>($"api/produto/{id}");
        }

        public async Task Create(ProdutoDto produto)
        {
            await _http.PostAsJsonAsync("api/produto", produto);
        }

        public async Task Update(ProdutoDto produto)
        {
            await _http.PutAsJsonAsync($"api/produto/{produto.Id}", produto);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"api/produto/{id}");
        }


    }
}
