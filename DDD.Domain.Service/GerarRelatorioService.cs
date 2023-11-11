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
        readonly SqlContext _context;
        readonly BoletimService _boletimService;
        readonly IAlunoRepository _alunoRepository;

        public GerarRelatorioService(SqlContext context, IAlunoRepository alunoRepository, BoletimService boletimService)
        {
            _alunoRepository = alunoRepository;
            _boletimService = boletimService;
            _context = context;
        }
        public List<BoletimPersistence> GerarRelatorio(bool ead)
        {
            List<BoletimPersistence> list = new List<BoletimPersistence>();

            var boletins = _context.Boletins.Where(boletim => boletim.Nota >= 8).ToList();

            foreach (var item in boletins)
            {
                BoletimPersistence boletimPersistence = new BoletimPersistence
                {
                    AlunoId = item.AlunoId,
                    DisciplinaId = item.DisciplinaId,
                    Nota = item.Nota
                };

                list.Add(boletimPersistence);
            }

            return list;
        }


        //public List<BoletimPersistence> GerarRelatorio(bool ead)
        //{
        //    //Boletim boletim = new Boletim();
        //    ////var aluno = _alunoRepository.GetAlunoById(idAluno);
        //    ////var disciplinasMatriculadas = _matriculaRepository.GetMatriculasPorAluno(aluno);
        //    //BoletimPersistence boletimPersistence = new BoletimPersistence();
        //    //List<BoletimPersistence> list = new List<BoletimPersistence>();
        //    //foreach (var item in )
        //    //{
        //    //    if (item.Nota >= 8)
        //    //    {
        //    //        boletimPersistence.AlunoId = item.AlunoId;
        //    //        boletimPersistence.DisciplinaId = item.DisciplinaId;
        //    //        boletimPersistence.Nota = item.Nota;
        //    //        list.Add(boletimPersistence);
        //    //    }
        //    //}
        //    //return list;



        //    return (from boletim in _context.Boletins
        //                      where boletim.Nota >= 8
        //                      select boletim).ToList();


        //    //return (from Boletim in _context.Boletins
        //    //        join tipoViatura in _context.Tipo_Viaturas on viatura.Tipo_ViaturaId equals tipoViatura.Id
        //    //        select new Viatura
        //    //        {
        //    //            sigla = viatura.sigla,
        //    //            obs_vtr = viatura.obs_vtr,
        //    //            Tipo_Viatura = new Tipo_Viatura
        //    //            {
        //    //                marca = tipoViatura.marca,
        //    //                modelo = tipoViatura.modelo,
        //    //                placa = tipoViatura.placa,
        //    //                descricao = tipoViatura.descricao
        //    //            }
        //    //        }).ToList();
        //}
    }
}
