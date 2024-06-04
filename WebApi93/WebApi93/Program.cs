using Microsoft.EntityFrameworkCore;
using WebApi93.Context;
using WebApi93.Service.IServices;
using WebApi93.Service.Services;

var builder = WebApplication.CreateBuilder(args);
//configuracion de cors
builder.Services.AddCors( options =>
    {
    //builder => builder.With.Origins ("localhost:5173")
    options.AddPolicy("MyAllowSpecificOrigins",
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()//ajusta esto segun tus necesidades 
        );
}
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddTransient<IUsuarioServices , Usuarioservices>();
builder.Services.AddTransient<IAutorServices, AutorServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

