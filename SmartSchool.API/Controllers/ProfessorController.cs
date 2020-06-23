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
        private readonly SmartContext _context;
        private readonly IRepository _repo;

        public ProfessorController(SmartContext context,
                                    IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if(professor == null)
            {
                return BadRequest("Professor não encontrado");
            }
            return Ok(professor);
        }

        [HttpGet("byname")]
        public IActionResult GetByName(string name)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome == name);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }
            return Ok("Professor encontado" + professor);
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
            var professorT = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(professorT == null)
            {
                return BadRequest("Professor não encontrado");
            }
            professor.Id = id;
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProfessor(int id)
        {
            var professorT = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professorT == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _context.Remove(professorT);
            _context.SaveChanges();
            return Ok("Deletado com sucesso:");
        }

        [HttpPatch("{id}")]
        public IActionResult patchProfessor(int id, Professor professor)
        {
            var professorT = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professorT == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _context.Update(professor);
            _context.SaveChanges();
            return Ok("Alterações realizadas:");
        }
    }
}