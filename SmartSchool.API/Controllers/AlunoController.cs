using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }      


        // GET: api/Aluno
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }


        // GET: api/Aluno/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if(aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            return Ok(aluno);
        }


        // POST: api/Aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno nao cadastrado");
        }


        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoB = _repo.GetAlunoById(id);
            if (alunoB == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno nao atualizado");
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _repo.Delete(aluno);
            if(_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }
            return Ok("Successfully deleted");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var alunoB = _repo.GetAlunoById(id);
            if (alunoB == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno nao atualizado");
        }
    }
}
