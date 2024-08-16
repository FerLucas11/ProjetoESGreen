using Microsoft.EntityFrameworkCore;
using ProjetoESGreen.Models;

namespace ProjetoESGreen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

    }
}
