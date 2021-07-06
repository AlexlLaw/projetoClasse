using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetcsSchool_Api.models;

namespace ProjetcsSchool_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base (options) {}
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
                    .HasData(
                        new List<Professor>() {
                            new Professor() {
                                Id =  1,
                                Nome = "Àlex"
                            },
                             new Professor() {
                                Id =  2,
                                Nome = "Eduardo"
                            },
                             new Professor() {
                                Id =  3,
                                Nome = "David"
                            }
                        }
                    );

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>() {
                        new Aluno() {
                            Id =  1,
                            Nome = "Lucas",
                            Sobrenome = "",
                            DataNascimento = "11/04/1998",
                            ProfessorId = 1
                        },
                            new Aluno() {
                            Id =  2,
                            Nome = "Jhonatan",
                            Sobrenome = "",
                            DataNascimento = "05/03/1997",
                            ProfessorId = 1
                        },
                            new Aluno() {
                            Id =  3,
                            Nome = "Alan",
                            Sobrenome = "Juan",
                            DataNascimento = "23/02/2001",
                            ProfessorId = 2
                        }
                    }
                );
        }
    }
} 