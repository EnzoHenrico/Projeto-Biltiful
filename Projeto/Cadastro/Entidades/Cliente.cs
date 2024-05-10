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
