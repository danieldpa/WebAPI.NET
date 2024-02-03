using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI.Models;

namespace WebAPI.DataContext
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//sempre usando para conexao com DB
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; } //Cria a tabela
    }
}
