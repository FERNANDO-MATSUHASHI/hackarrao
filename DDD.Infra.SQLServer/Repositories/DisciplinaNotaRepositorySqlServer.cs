using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class DisciplinaNotaRepositorySqlServer : IDisciplinaNotasRepository
    {
        readonly SqlContext _context;
        public void DeleteDisciplinaNota(DisciplinaNota disciplinaNota)
        {
            throw new NotImplementedException();
        }

        public void DisciplinaNota(DisciplinaNota disciplinaNota)
        {
            throw new NotImplementedException();
        }

        public List<DisciplinaNota> GetDisciplinaNota()
        {
            return _context.DisciplinaNotas.ToList();
        }

        public DisciplinaNota GetDisiciplinaNotaById(int id)
        {
            return _context.DisciplinaNotas.Find(id);
        }

        public void UpdateDisciplinaNota(DisciplinaNota disciplinaNota)
        {
            throw new NotImplementedException();
        }
    }
}
