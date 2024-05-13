using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entidades
{
    internal class MPrima
    {
        public string Id { get; }
        public string Nome { get; set; }
        public DateOnly UltimaCompra { get; private set; }
        public DateOnly DataCadastro { get; }
        public char Situacao { get; private set; }

        public MPrima(
            string id,
            string nome
            )
        {
            Id = id;
            Nome = nome;
            UltimaCompra = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public MPrima(string registro)
        {
            Id = registro.Substring(0, 6);
            Nome = registro.Substring(6, 20);
            UltimaCompra = DateOnly.ParseExact(registro.Substring(26, 8), "ddMMyyyy");
            DataCadastro = DateOnly.ParseExact(registro.Substring(34, 8), "ddMMyyyy"); ;
            Situacao = registro[42];
        }

        public override string ToString()
        {
            return $"| {Id} / {Nome.TrimEnd()}-> Ultima compra: {UltimaCompra} - Data do Cadastro: {DataCadastro} Situacao: {Situacao}";

        }

        public static string FormatarId(int idNumerico)
        {
            return "MP" + idNumerico.ToString().PadLeft(4, '0');
        }

        public string FormatarParaArquivo()
        {
            string dadosDoArquivo = String.Empty;

            dadosDoArquivo += Id;
            dadosDoArquivo += Nome.ToUpper().PadRight(20);
            dadosDoArquivo += $"{UltimaCompra.Day:00}{UltimaCompra.Month:00}{UltimaCompra.Year}";
            dadosDoArquivo += $"{DataCadastro.Day:00}{DataCadastro.Month:00}{DataCadastro.Year}";
            dadosDoArquivo += Situacao;

            return dadosDoArquivo;
        }

        public string GerarStringParaEdicao()
        {
            string situacao = Situacao == 'A' ? "Ativo" : "Inativo";
            return $"1 - Nome: {Nome}\n" +
                   $"2 - Situação: {situacao}\n";
        }

        public void InverterSituacao()
        {
            if (Situacao == 'A')
            {
                Situacao = 'I';
            }
            else
            {
                Situacao = 'A';
            }
        }

        public void AtualizarDataVenda(DateOnly ultimaVenda)
        {
            UltimaCompra = ultimaVenda;
        }
    }
}
