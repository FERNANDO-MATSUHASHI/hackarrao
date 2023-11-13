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
            List<Aluno> list = new List<Aluno>();
            list.AddRange(_gerarRelatorioService.GerarRelatorio(ead));

            if (list.Count > 0)
            {
                string corpoEmail = string.Join(Environment.NewLine, list.Select(resultado =>
                    $"email: {resultado.Email}"));
                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("79ae20b696d6d3", "c87b13bb1c2a8f"),
                    EnableSsl = true
                };
                client.Send("matsu_zf@hotmail.com", "matsu.zf@gmail.com", "Hello world", corpoEmail);
                Console.WriteLine("Sent");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro na geração do relatório", list);
            }
        }
    }
}
