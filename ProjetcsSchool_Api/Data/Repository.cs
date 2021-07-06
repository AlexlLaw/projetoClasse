using System.Threading.Tasks;
using ProjetcsSchool_Api.models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjetcsSchool_Api.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //Aluno
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessor(int ProfessorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.ProfessorId == ProfessorId);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }

        //Professor
        public async Task<Professor[]> GetAllProfessorsAsync(bool includeAluno = false)
        {
              IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(a => a.Alunos);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorsAsyncByProfessor(int ProfessorId, bool includeAluno)
        {
              IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(a => a.Alunos);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(Professor => Professor.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}