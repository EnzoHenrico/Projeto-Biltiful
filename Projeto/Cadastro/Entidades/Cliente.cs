using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entidades
{
    internal class Cliente
    {
        readonly string Cpf;
        string Nome;
        DateOnly DataNascimento;
        char Sexo;
        DateOnly UltimaCompra;
        DateOnly DataCadastro;
        char Situacao;

        public Cliente(
            string cpf,
            string nome, 
            DateOnly dataNascimento, 
            char sexo
            )
        {
            Cpf = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            UltimaCompra = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public Cliente(string dadosDoArquivo)
        {
            Cpf = dadosDoArquivo.Substring(0, 11);
            Nome = dadosDoArquivo.Substring(11, 50);
            DataNascimento = DateOnly.ParseExact(dadosDoArquivo.Substring(61, 8), "ddMMyyyy"); ;
            Sexo = dadosDoArquivo[69];
            UltimaCompra = DateOnly.ParseExact(dadosDoArquivo.Substring(70, 8), "ddMMyyyy");
            DataCadastro = DateOnly.ParseExact(dadosDoArquivo.Substring(78, 8), "ddMMyyyy"); ;
            Situacao = dadosDoArquivo[86];
        }

        public override string ToString()
        {
            return Cpf + "\n" +
                   Nome + "\n" +
                   DataNascimento + "\n" +
                   Sexo + "\n" +
                   UltimaCompra + "\n" +
                   DataCadastro + "\n" +
                   Situacao + "\n";
        }

        public static bool VerificarCpf(string cpf)
        {
            return true;
        }

        public string FormatarParaArquivo()
        {
            string dadosDoArquivo = String.Empty;
            
            dadosDoArquivo += Cpf;
            dadosDoArquivo += Nome.PadRight(50);
            dadosDoArquivo += $"{DataNascimento.Day:00}{DataNascimento.Month:00}{DataNascimento.Year}";
            dadosDoArquivo += Sexo;
            dadosDoArquivo += $"{UltimaCompra.Day:00}{UltimaCompra.Month:00}{UltimaCompra.Year}";
            dadosDoArquivo += $"{DataCadastro.Day:00}{DataCadastro.Month:00}{DataCadastro.Year}";
            dadosDoArquivo += Situacao;

            return dadosDoArquivo;
        }
    }
}
