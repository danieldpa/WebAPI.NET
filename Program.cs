using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI.DataContext;
using WebAPI.Service.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => { //Conectando o banco 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarcoConnection")); //builder.Configuration acesso o arquivo appsettings
});

// Adiciona o serviço CORS com uma política específica
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configura o uso do CORS com a política definida
app.UseCors("AllowAngularDevOrigin");

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
