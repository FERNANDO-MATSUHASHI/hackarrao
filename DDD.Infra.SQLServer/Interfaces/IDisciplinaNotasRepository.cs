using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IDisciplinaNotasRepository
    {
        public List<DisciplinaNota> GetDisciplinaNota();
        public DisciplinaNota GetDisiciplinaNotaById(int id);
        public void DisciplinaNota(DisciplinaNota disciplinaNota);
        public void UpdateDisciplinaNota(DisciplinaNota disciplinaNota);
        public void DeleteDisciplinaNota(DisciplinaNota disciplinaNota);
    }
}
