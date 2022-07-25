using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MangaWebNotRazor.Data;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MangaWebNotRazor.Models;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MangaWebNotRazorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MangaWebNotRazorContext") ?? throw new InvalidOperationException("Connection string 'MangaWebNotRazorContext' not found.")));
// Add services to the container.
 builder.Services.AddIdentityCore<MangaUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<MangaWebNotRazorContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Solodkii lox XDzxcqwe"));
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = key
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
