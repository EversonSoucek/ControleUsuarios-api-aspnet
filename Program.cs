using CadastroUsuario.infrastructure.data;
using CadastroUsuario.infrastructure.data.repositories.implementations;
using CadastroUsuario.infrastructure.data.repositories.interfaces;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin", builder =>
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddDbContext<Context>(options =>
{
    options.UseMySql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_STRING"), new MySqlServerVersion(new Version(8, 0, 32)));
});

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowMyOrigin");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


