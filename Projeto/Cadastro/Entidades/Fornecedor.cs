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
            return Cnpj + "\n" +
                   RazaoSocial + "\n" +
                   DataAbertura + "\n" +
                   UltimaCompra + "\n" +
                   DataCadastro + "\n" +
                   Situacao + "\n";
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
            return $"1 - Razão Social: {RazaoSocial}\n" +
                   $"2 - Data de Abertura: {DataAbertura}\n" +
                   $"2 - Situação {situacao}\n";
        }

        public static bool VerificarCnpj(string cnpj)
        {
            // Calcular validade dos dígitos verificadores
            int digitoVerificador1 = int.Parse(cnpj[9].ToString());
            int digitoVerificador2 = int.Parse(cnpj[10].ToString());

            // Digito 1 
            // Multiplicar os primeiros 9 digitos, da direita pra esquerda por 2++
            int multiplicador = 2, acumulador = 0;
            for (int i = cnpj.Length - 3; i >= 0; i--)
            {
                acumulador += int.Parse(cnpj[i].ToString()) * multiplicador;
                multiplicador++;
            }

            // Quando o resto da divisão por 11 for menor que 2, dígito tem que ser igual a 0
            int resto = acumulador % 11;
            if (resto < 2 && digitoVerificador1 != 0)
            {
                return false;
            }

            // Caso contratio, então o dígito verificador deve ser igual a (11 - resto)
            if (resto >= 2 && digitoVerificador1 != (11 - resto))
            {
                return false;
            }

            // Digito 2
            // Multiplicar os primeiros 9 digitos + o primeiro digito verificador, da direita pra esquerda por 2++
            multiplicador = 2;
            acumulador = 0;
            for (int i = cnpj.Length - 2; i >= 0; i--)
            {
                acumulador += int.Parse(cnpj[i].ToString()) * multiplicador;
                multiplicador++;
            }

            // Quando o resto da divisão por 11 for menor que 2, dígito tem que ser igual a 0
            resto = acumulador % 11;
            if (resto < 2 && digitoVerificador2 != 0)
            {
                return false;
            }

            // Caso contratio, então o dígito verificador deve ser igual a (11 - resto)
            if (resto >= 2 && digitoVerificador2 != (11 - resto))
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
