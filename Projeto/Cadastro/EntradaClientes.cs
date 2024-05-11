using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Cadastro.Entidades;
using Projeto.Cadastro.Manipuladores;

namespace Projeto.Cadastro
{
    internal class EntradaClientes
    {
        public static Cliente CadastrarCliente()
        {
            Console.WriteLine("Digite os dados para cadastrar um novo cliente: \n");
            
            Console.WriteLine("CPF:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            
            Console.WriteLine("Data de nascimento (dd/mm/aaaa):");
            string nascimento = Console.ReadLine().Replace("/", "");
            int dia = int.Parse(nascimento.Substring(0, 2));
            int mes = int.Parse(nascimento.Substring(2, 2));
            int ano = int.Parse(nascimento.Substring(4, 4));

            DateOnly dataNascimento = new DateOnly(ano, mes, dia);
            
            Console.WriteLine("Sexo:");
            char sexo = char.Parse(Console.ReadLine());

            return new(cpf, nome, dataNascimento, sexo);
        }

        public static void AlterarCliente(Cliente cliente)
        {
            int opcao;
            do
            {
                Console.WriteLine("\nSelecione qual informação deseja alterar: ");
                Console.WriteLine(cliente.GerarStringParaEdicao());
                /*
                 * 1 - Nome
                 * 2 - Data de nascimento
                 * 3 - Sexo
                 * 4 - Situacao
                 */
                 opcao = int.Parse(Console.ReadLine());

                 switch (opcao)
                 {
                     case 1:
                         Console.Write("Alteração nome: ");
                         string novoNome = Console.ReadLine();
                         cliente.Nome = novoNome;
                         break;
                     case 2:
                        Console.WriteLine("Alterar data de nascimento (dd/mm/aaaa):");
                        string nascimento = Console.ReadLine().Replace("/", "");
                        int dia = int.Parse(nascimento.Substring(0, 2));
                        int mes = int.Parse(nascimento.Substring(2, 2));
                        int ano = int.Parse(nascimento.Substring(4, 4));

                        cliente.DataNascimento = new DateOnly(ano, mes, dia);
                        break;
                     case 3:
                        Console.Write("Alteração de Sexo: "); 
                        cliente.Sexo = Console.ReadLine()[0];
                        break;
                     case 4:
                         string atual = cliente.Situacao == 'A' ? "ativo" : "inativo"; 
                         string novo = cliente.Situacao == 'A' ? "intivo" : "ativo";

                         Console.WriteLine($"O cliente está {atual}, confirmar aletração para {novo}? (s) Sim / (n) Não"); 
                         if (Console.ReadLine().ToLower() == "s") cliente.InverterSituacao();
                         break;
                    default:
                         Console.WriteLine("\nOpção inválida, tente novamente.\n");
                         break;
                }

            } while (opcao is < 1 or > 3);
        }
    }
}
