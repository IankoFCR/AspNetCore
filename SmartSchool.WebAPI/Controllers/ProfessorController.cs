using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges()) return Ok(professor);

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorr = _repo.GetProfessorById(id);
            if (professorr == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok(professor);

            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorr = _repo.GetProfessorById(id);
            if (professorr == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok(professor);

            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok("Professor deletado");

            return BadRequest("Professor não deletado");
        }
    }
}