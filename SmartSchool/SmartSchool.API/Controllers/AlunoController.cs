using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
      


        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Matheus",
                Sobrenome = "Dev",
                Telefone = "40028922"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Prado",
                Sobrenome = "Dev2",
                Telefone = "1234-1234"
            },
                new Aluno()
            {
                Id = 3,
                Nome = "Lima",
                Sobrenome = "Dev3",
                Telefone = "1234-5678"
            },
        };

        // GET: api/Aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }


        // GET: api/Aluno/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            return Ok(aluno);
        }


        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            return Ok(aluno);
        }




        // POST: api/Aluno
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
