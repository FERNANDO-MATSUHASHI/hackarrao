using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Service
{
    public class SelecionarAlunosService
    {
        private readonly SqlContext _dbContext;

        public SelecionarAlunosService(SqlContext sqlContext)
        {
            _dbContext = sqlContext;
        }
        public void SuaConsulta()
        {
            var resultadoConsulta = (
                from boletim in _dbContext.Boletins
                join disciplina in _dbContext.Disciplinas on boletim.DisciplinaId equals disciplina.DisciplinaId
                join disciplinaNota in _dbContext.DisciplinaNotas on disciplina.DisciplinaId equals disciplinaNota.IdDisciplina
                join user in _dbContext.Users on boletim.AlunoId equals user.UserId
                select new
                {
                    AlunoNome = user.Nome,
                    AlunoEmail = user.Email,
                    DisciplinaNome = disciplina.Nome,
                    DisciplinaNota = disciplinaNota.Nota
                }
            ).ToList();

        }



    }
}
