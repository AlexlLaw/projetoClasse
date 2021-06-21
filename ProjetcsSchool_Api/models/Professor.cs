using System.Collections.Generic;

namespace ProjetcsSchool_Api.models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}