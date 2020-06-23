using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DateFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }

        public Professor(int id, string nome, int registro)
        {
            Id = id;
            Nome = nome;
            Registro = registro;
        }

        public Professor()
        {
        }
    }
}
