using Microsoft.AspNetCore.Mvc;

namespace ProjetcsSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        public AlunoController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{AlunoId}")]
        public IActionResult GetById(int AlunoId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{AlunoId}")]
        public IActionResult Put(int AlunoId)
        {
            return Ok();
        }

        [HttpDelete("{AlunoId}")]
        public IActionResult Delete(int AlunoId)
        {
            return Ok();
        }
    }
}