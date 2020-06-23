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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController( IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if(professor == null)
            {
                return BadRequest("Professor não encontrado");
            }
            return Ok(professor);
        }


        [HttpPost]
        public IActionResult PostProfessor(Professor professor)
        {

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult putProfessor(int id, Professor professor)
        {
            var professorT = _repo.GetProfessorById(id, false);
            if (professorT == null)
            {
                return BadRequest("Professor não encontrado");
            }
            //professor.Id = id;
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProfessor(int id)
        {
            var professorT = _repo.GetProfessorById(id, true);
            if (professorT == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _repo.Delete(professorT);
            if (_repo.SaveChanges())
            {
                return Ok("Deletado com sucesso:");
            }
            return BadRequest("Professor nao deletado");
        }

        [HttpPatch("{id}")]
        public IActionResult patchProfessor(int id, Professor professor)
        {
            var professorT = _repo.GetProfessorById(id, true);
            if (professorT == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor nao Atualizado");
        }
    }
}