using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetcsSchool_Api.Data;
using ProjetcsSchool_Api.models;

namespace ProjetcsSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllProfessorsAsync(true);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar com banco de dados");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetById(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetProfessorsAsyncById(ProfessorId, false);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar com banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
               _repo.Add(model);
               if (await _repo.SaveChangesAsync()) {
                   return Created($"/api/professor/{model.Id}", model);
               }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar com banco de dados");
            }

             return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorsAsyncById(ProfessorId, false);

                if (professor == null) {
                    return NotFound();
                } 

               _repo.Update(model);
               if (await _repo.SaveChangesAsync()) {
                   return Created($"/api/professor/{model.Id}", model);
               }
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar com banco de dados");
            }

             return BadRequest();
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> delete(int ProfessorId)
        {
            try
            {
               var professor = await _repo.GetProfessorsAsyncById(ProfessorId, false);

                if (professor == null) {
                    return NotFound();
                } 

               _repo.Delete(professor);
               if (await _repo.SaveChangesAsync()) {
                   return Ok();
               }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar com banco de dados");
            }
             return BadRequest();
        }
    }
}