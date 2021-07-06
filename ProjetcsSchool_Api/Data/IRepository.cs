using System.Threading.Tasks;
using ProjetcsSchool_Api.models;

namespace ProjetcsSchool_Api.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Aluno
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessor(int ProfessorId, bool includeProfessor);
        Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor);

        //Professor
        Task<Professor[]> GetAllProfessorsAsync(bool includeAluno);
        Task<Professor> GetProfessorsAsyncById(int AlunoId, bool includeAluno);
    }
}