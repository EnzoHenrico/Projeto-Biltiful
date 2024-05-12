using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entidades
{
    internal class Produto
    {
        public string CodigoBarras { get; }
        public string Nome { get; set; }
        public float ValorVenda { get; set; }
        public DateOnly UltimaVenda { get; private set; }
        public DateOnly DataCadastro { get; }
        public char Situacao { get; private set; }

        public Produto(
            string codigoBarras,
            string nome,
            float valorVenda
            )
        {
            CodigoBarras = codigoBarras;
            Nome = nome;
            ValorVenda = valorVenda;
            UltimaVenda = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public Produto(string registro)
        {
            CodigoBarras = registro.Substring(0, 13);
            Nome = registro.Substring(13, 20);
            ValorVenda = float.Parse(registro.Substring(33, 3)) + (float.Parse(registro.Substring(36, 2)) / 100);
            UltimaVenda = DateOnly.ParseExact(registro.Substring(38, 8), "ddMMyyyy");
            DataCadastro = DateOnly.ParseExact(registro.Substring(46, 8), "ddMMyyyy"); ;
            Situacao = registro[54];
        }

        public override string ToString()
        {
            return $"| {CodigoBarras} / {Nome.TrimEnd()} -> R${ValorVenda:0.00} - Última venda: {UltimaVenda} - Cadastro: {DataCadastro} - Situacao: {Situacao} ";
        }

        public string FormatarParaArquivo()
        {
            string dadosDoArquivo = String.Empty;

            dadosDoArquivo += CodigoBarras;
            dadosDoArquivo += Nome.ToUpper().PadRight(20);
            dadosDoArquivo += $"{ValorVenda}".Replace(".", "").Replace(",", "").PadLeft(5, '0');
            dadosDoArquivo += $"{UltimaVenda.Day:00}{UltimaVenda.Month:00}{UltimaVenda.Year}";
            dadosDoArquivo += $"{DataCadastro.Day:00}{DataCadastro.Month:00}{DataCadastro.Year}";
            dadosDoArquivo += Situacao;

            return dadosDoArquivo;
        }

        public static bool ValidarCodigoDeBarras(string codigo)
        {
            return codigo.Substring(0, 3) == "789";
        }

        public string GerarStringParaEdicao()
        {
            string situacao = Situacao == 'A' ? "Ativo" : "Inativo";
            return $"1 - Nome: {Nome}\n" +
                   $"2 - Valor de venda: R$ {ValorVenda:0.00}\n" +
                   $"3 - Situação: {situacao}\n";
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
            UltimaVenda = ultimaVenda;
        }
    }
}
