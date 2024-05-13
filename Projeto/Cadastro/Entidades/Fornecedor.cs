using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entidades
{
    internal class Fornecedor
    {
        public string Cnpj { get; }
        public string RazaoSocial { get; set; }
        public DateOnly DataAbertura { get; set; }
        public DateOnly UltimaCompra { get; private set; }
        public DateOnly DataCadastro { get; }
        public char Situacao { get; private set; }

        public Fornecedor(
            string cnpj,
            string razaoSocial,
            DateOnly dataAbertura
            )
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            DataAbertura = dataAbertura;
            UltimaCompra = DateOnly.FromDateTime(DateTime.Now);
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public Fornecedor(string registro)
        {
            Cnpj = registro.Substring(0, 14);
            RazaoSocial = registro.Substring(14, 50);
            DataAbertura = DateOnly.ParseExact(registro.Substring(64, 8), "ddMMyyyy"); ;
            UltimaCompra = DateOnly.ParseExact(registro.Substring(72, 8), "ddMMyyyy");
            DataCadastro = DateOnly.ParseExact(registro.Substring(80, 8), "ddMMyyyy"); ;
            Situacao = registro[88];
        }

        public override string ToString()
        {
            return $"| {Cnpj} / {RazaoSocial.TrimEnd()} -> Abertura: {DataAbertura} - Cadastro: {DataCadastro} - Situacao: {Situacao} ";

        }

        public string FormatarParaArquivo()
        {
            string dadosDoArquivo = String.Empty;

            dadosDoArquivo += Cnpj;
            dadosDoArquivo += RazaoSocial.ToUpper().PadRight(50);
            dadosDoArquivo += $"{DataAbertura.Day:00}{DataAbertura.Month:00}{DataAbertura.Year}";
            dadosDoArquivo += $"{UltimaCompra.Day:00}{UltimaCompra.Month:00}{UltimaCompra.Year}";
            dadosDoArquivo += $"{DataCadastro.Day:00}{DataCadastro.Month:00}{DataCadastro.Year}";
            dadosDoArquivo += Situacao;

            return dadosDoArquivo;
        }

        public string GerarStringParaEdicao()
        {
            string situacao = Situacao == 'A' ? "Ativo" : "Inativo";
            return $"[ 1 ] Razão Social: {RazaoSocial}\n" +
                   $"[ 2 ] Data de Abertura: {DataAbertura}\n" +
                   $"[ 3 ] Situação: {situacao}\n";
        }

        public static bool VerificarCnpj(string cnpj)
        {
            // Verificar condição de existência
            if (cnpj.Length != 14)
            {
                return false;
            }

            int digitoVerificador1 = int.Parse(cnpj[12].ToString());
            int digitoVerificador2 = int.Parse(cnpj[13].ToString());

            // Primeiro dígito verificador
            int acumulador = 0;
            int[] mascaraDeValidacao = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 12; i++)
            {
                acumulador += int.Parse(cnpj[i].ToString()) * mascaraDeValidacao[i];
            }

            // Condições exclusivas do digito 1
            int resto = acumulador % 11;
            if (resto < 2 && digitoVerificador1 != 0)
            {
                return false;
            }
            if (resto > 2 && digitoVerificador1 != (11 - resto))
            {
                return false;
            }

            // Segundo dígito verificador
            acumulador = 0;
            int[] peso2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 13; i++)
            {
                acumulador += int.Parse(cnpj[i].ToString()) * peso2[i];
            }

            // Condições exclusivas do digito 2
            resto = acumulador % 11;
            if (resto < 2 && digitoVerificador2 != 0)
            {
                return false;
            }

            if (resto > 2 && digitoVerificador2 != (11 - resto))
            {
                return false;
            }

            return true;
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

        public void AtualizarDataCompra(DateOnly ultimaCompra)
        {
            UltimaCompra = ultimaCompra;
        }
    }
}
