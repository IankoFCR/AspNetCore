using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Gomes",
                Telefone = "12345678"
            },
            new Aluno() {
                Id = 2,
                Nome = "Koan",
                Sobrenome = "Santori",
                Telefone = "24145678"
            },
            new Aluno() {
                Id = 3,
                Nome = "Luana",
                Sobrenome = "Radaunsgi",
                Telefone = "12356378"
            }
        };
        public AlunoController() {}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não Encontrado");

            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByIdNome(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome == nome);
            if (aluno == null) return BadRequest("Aluno não Encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}