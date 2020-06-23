using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        #region Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);
        #endregion

        #region Professores
        Professor[] GetAllProfessores(bool IncludeProfessor = false);
        Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool IncludeProfesso);
        Professor GetProfessorById(int professorId, bool IncludeProfessor = false);
        #endregion

    }
}
