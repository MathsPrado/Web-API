﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            AlunoId = alunoId;
            DisciplinaId = disciplinaId;
        }

        public AlunoDisciplina(){}

        public DateTime DateInicio { get; set; } = DateTime.Now;
        public DateTime? DateFim { get; set; }
        public int? Nota { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
