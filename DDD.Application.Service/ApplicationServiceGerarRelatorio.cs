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

        List<BoletimPersistence> listaBoletins = _selecionarAlunosService.SelecionarAlunos(ead);

        if (listaBoletins.Count > 0)
        {
            var alunosComNota8OuMaior = listaBoletins
                .Where(resultado => resultado.Nota >= 8)
                .Select(resultado =>
                    $"ID do Aluno: {resultado.AlunoId}, ID da Disciplina: {resultado.DisciplinaId}, Notas: {resultado.Nota}");

            if (alunosComNota8OuMaior.Any())
            {
                string corpoEmail = string.Join(Environment.NewLine, alunosComNota8OuMaior);

        // Lógica para envio de e-mails
        EnviarEmail(corpoEmail);

        Console.WriteLine("E-mails enviados com sucesso.");
            }
            else
            {
                Console.WriteLine("Nenhum aluno encontrado com nota maior ou igual a 8.");
            }
        }
        else
{
    Console.WriteLine("Erro na geração do relatório ou nenhum relatório gerado.");
}
    }

    private void EnviarEmail(string corpoEmail)
{
    // Lógica para enviar e-mail, similar ao que você já tem
    var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
    {
        Credentials = new NetworkCredential("3e0bcc8ed258f2", "4d152f9fae7bc6"),
        EnableSsl = true
    };

    // Substitua os endereços de e-mail pelos reais
    client.Send("remetente@example.com", "destinatario@example.com", "Assunto do E-mail", corpoEmail);
}
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
