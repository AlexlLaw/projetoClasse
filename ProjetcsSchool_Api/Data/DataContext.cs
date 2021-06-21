using Microsoft.EntityFrameworkCore;
using ProjetcsSchool_Api.models;

namespace ProjetcsSchool_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options) {}
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
} 