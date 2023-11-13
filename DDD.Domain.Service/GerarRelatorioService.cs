using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interfaces;
using DDD.Domain.SecretariaContext;

namespace DDD.Domain.Service
{
    public class GerarRelatorioService
    {
        readonly IGerarRelatorioRepository _gerarRelatorioRepositorySqlServer;

        public GerarRelatorioService(IGerarRelatorioRepository gerarRelatorioRepository)
        {
            _gerarRelatorioRepositorySqlServer = gerarRelatorioRepository;
        }
        public List<Aluno> GerarRelatorio(bool ead)
        {
            List<BoletimPersistence> list = new List<BoletimPersistence>();

            var boletins = _gerarRelatorioRepositorySqlServer.VerifBoletin(ead);

            return boletins;

            //foreach (var item in boletins)
            //{
            //    BoletimPersistence boletimPersistence = new BoletimPersistence
            //    {
            //        AlunoId = item.AlunoId,
            //        DisciplinaId = item.DisciplinaId,
            //        Nota = item.Nota
            //    };

            //    list.Add(boletimPersistence);
            //}

            //return list;
        }
    }
}
