using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class GerarRelatorioRepositorySqlServer : IGerarRelatorioRepository
    {
        readonly SqlContext _context;

        public GerarRelatorioRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }
        public List<Aluno> VerifBoletin(bool ead)
        {
            try
            {

                var boletinsAprovados = _context.Boletins.Where(boletim => boletim.Nota >= 8).ToList();
                var disciplinaEad = _context.Disciplinas.Where(x => x.Ead).ToList();

                var list = new List<Aluno>();



                foreach (var boletim in boletinsAprovados)
                {
                    foreach (var disciplina in disciplinaEad)
                    {
                        if (boletim.DisciplinaId == disciplina.DisciplinaId)
                        {
                            var alunoEmail = _context.Alunos.Where(y => y.UserId == boletim.AlunoId).ToList();
                            foreach (var item in alunoEmail)
                            {
                                Aluno aluno = new Aluno
                                {
                                    UserId = item.UserId,
                                    Nome = item.Nome,
                                    Sobrenome = item.Sobrenome,
                                    Email = item.Email,
                                    Login = item.Login,
                                    Senha = item.Senha,
                                    DataCadastro = item.DataCadastro,
                                    Ativo = item.Ativo
                                };

                                list.Add(aluno);
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return new List<Aluno>();
                //log exception
            }
        }
    }
}
