using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MobileCrudJinx.Client;
using MobileCrudJinx.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7101/") });

builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<MovimentoService>();

await builder.Build().RunAsync();
