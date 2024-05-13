using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Vendas.Utils
{
    public class Validacoes
    {
        public static bool VerificarCpf(string cpf)
        {
            StreamReader clientes = new(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoCliente);
            return VerificarCadastro(clientes, cpf);
        }

        static bool VerificarCadastro(StreamReader clientes, string cpf)
        {
            string? UltimoCliente = null;
            string cliente;
            while ((cliente = clientes.ReadLine()) != null)
            {
                string cpfCliente = cliente.Substring(0, 11);
                if (cpfCliente == cpf)
                {
                    UltimoCliente = cliente;
                    break;
                }
            }
            if (UltimoCliente == null)
            {
                Console.WriteLine("ERRO: Cliente sem cadastro. Suspendendo operação...");
                Thread.Sleep(3000);
                return false;
            }
            clientes.Close();
            return VerificarInadimplente(UltimoCliente, cpf);
        }

        static bool VerificarInadimplente(string cliente, string cpf)
        {
            StreamReader inadimplentes = new(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoRisco);
            string inadimplente;
            while ((inadimplente = inadimplentes.ReadLine()) != null)
            {
                if (inadimplente == cpf)
                {
                    Console.WriteLine("ERRO: Cliente inadimplente. Suspendendo operação...");
                    Thread.Sleep(3000);
                    return false;
                }
            }
            inadimplentes.Close();
            return VerificarSituacao(cliente);
        }

        static bool VerificarSituacao(string cliente)
        {
            if (cliente[86] == 'I')
            {
                Console.WriteLine(cliente[86]);
                Console.WriteLine("ERRO: Cliente inativo. Suspendendo operação...");
                Thread.Sleep(3000);
                return false;
            }
            return VerificarMaioridade(cliente);
        }

        static bool VerificarMaioridade(string cliente)
        {
            Console.WriteLine(cliente);
            int dia = int.Parse(cliente.Substring(61, 2));
            int mes = int.Parse(cliente.Substring(63, 2));
            int ano = int.Parse(cliente.Substring(65, 4));
            DateOnly DataNascimento = new DateOnly(ano, mes, dia);

            int idade = DateTime.Now.Year - ano;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear) idade--;

            if (idade < 18)
            {
                Console.WriteLine("ERRO: Cliente menor de idade. Suspendendo operação...");
                Thread.Sleep(3000);
                return false;
            }
            else return true;
        }
    }
}
