using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        string pegaResposta();
        void add();
        void Delete();
        bool SaveChanges();

    }
}
