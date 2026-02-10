using Microsoft.EntityFrameworkCore;
using MobileCrudJinx.Api.Data;

var builder = WebApplication.CreateBuilder(args);



//Controller da API
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DefaultConnection")
             ?? "Data Source=Jinx.db";

    options.UseSqlite(cs);
});

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("pwa", p =>
        p.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod());
});


var app = builder.Build();




// Configure the HTTP request pipeline. Swagger.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization(); <-- Não precisa por enquanto
app.UseCors("pwa");
app.MapControllers();
app.Run();
