﻿using System;
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
            StreamReader clientes = new(@"C:\BILTIFUL\Clientes.dat");
            return VerificarCadastro(clientes, cpf);
        }

        static bool VerificarCadastro(StreamReader clientes, string cpf)
        {
            string? UltimoCliente = null;
            string cliente;
            while ((cliente = clientes.ReadLine()) != null)
            {
                if (cliente.Contains(cpf))
                {
                    UltimoCliente = cliente;
                    break;
                }
            }
            if (UltimoCliente == null)
            {
                Console.WriteLine("ERRO: Cliente sem cadastro. Suspendendo operação.");
                return false;
            }
            clientes.Close();
            return VerificarInadimplente(UltimoCliente, cpf);
        }

        static bool VerificarInadimplente(string cliente, string cpf)
        {
            StreamReader inadimplentes = new(@"C:\BILTIFUL\Risco.dat");
            string inadimplente;
            while ((inadimplente = inadimplentes.ReadLine()) != null)
            {
                if (inadimplente == cpf)
                {
                    Console.WriteLine("ERRO: Cliente inadimplente. Suspendendo operação.");
                    return false;
                }
            }
            inadimplentes.Close();
            return VerificarSituacao(cliente);
        }

        static bool VerificarSituacao(string cliente)
        {
            if (cliente[87] == 'I')
            {
                Console.WriteLine("ERRO: Cliente inativo. Suspendendo operação.");
                return false;
            }
            return VerificarMaioridade(cliente);
        }

        static bool VerificarMaioridade(string cliente)
        {
            int dia = int.Parse(cliente.Substring(62, 2));
            int mes = int.Parse(cliente.Substring(64, 2));
            int ano = int.Parse(cliente.Substring(68, 4));
            DateOnly DataNascimento = new DateOnly(ano, mes, dia);

            int idade = DateTime.Now.Year - ano;
            if (DateTime.Now.DayOfYear < DataNascimento.DayOfYear) idade--;

            if (idade < 18) return false;
            else return true;
        }
    }
}
