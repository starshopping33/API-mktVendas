using API_mktVendas.Application.Service;
using API_mktVendas.Domain.Entities;
using API_mktVendas.Domain.Interfaces;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using tech_store_api.Infrastructure.Data;
using tech_store_api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


builder.Services.AddScoped<IUsusarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<FormaPagamentoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();


// JWT
var jwt = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("AllowLocalhost");

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
