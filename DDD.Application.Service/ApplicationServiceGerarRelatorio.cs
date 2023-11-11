using DDD.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.SecretariaContext;

namespace DDD.Application.Service
{
    public class ApplicationServiceGerarRelatorio
    {
        readonly GerarRelatorioService _gerarRelatorioService;

        public ApplicationServiceGerarRelatorio(GerarRelatorioService gerarRelatorioService)
        {
            _gerarRelatorioService = gerarRelatorioService;
        }

        public void GerarRelatorio(bool ead)
        {
            List<BoletimPersistence> list = new List<BoletimPersistence>();
            list.AddRange(_gerarRelatorioService.GerarRelatorio(ead));

            if (list.Count > 0)
            {
                string corpoEmail = string.Join(Environment.NewLine, list.Select(resultado =>
                    $"ID do Aluno: {resultado.AlunoId}, ID da Disciplina: {resultado.DisciplinaId}, Notas: {resultado.Nota}"));
                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("3e0bcc8ed258f2", "4d152f9fae7bc6"),
                    EnableSsl = true
                };
                client.Send("matsu_zf@hotmail.com", "matsu.zf@gmail.com", "Hello world", corpoEmail);
                Console.WriteLine("Sent");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro na geração do relatório ou nenhum relatório gerado.");
            }

            //_gerarRelatorioService.GerarRelatorio(ead);
            //if (emails)
            //{
            //    var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            //    {
            //        Credentials = new NetworkCredential("3e0bcc8ed258f2", "4d152f9fae7bc6"),
            //        EnableSsl = true
            //    };
            //    client.Send("matsu_zf@hotmail.com", "matsu.zf@gmail.com", "Hello world", emails);
            //    Console.WriteLine("Sent");
            //    Console.ReadLine();
            //}
        }
    }
}
