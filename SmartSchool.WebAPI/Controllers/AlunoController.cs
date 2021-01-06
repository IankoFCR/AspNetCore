using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não Encontrado");

            return Ok(aluno);
        }
        
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoo = _repo.GetAlunoById(id);
            if (alunoo == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoo = _repo.GetAlunoById(id);
            if (alunoo == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Aluno não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges()) return Ok("Aluno deletado");
            
            return BadRequest("Aluno não cadastrado");
        }
    }
}