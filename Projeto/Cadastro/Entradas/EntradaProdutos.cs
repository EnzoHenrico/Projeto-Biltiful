using Projeto.Cadastro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entradas
{
    internal class EntradaProdutos
    {
        public static Produto CadastrarProduto()
        {
            Console.WriteLine("Digite os dados para cadastrar um novo produto: \n");
            string codigo;
            bool codigoValido;
            do
            {
                Console.WriteLine("Código de barras: ");
                codigo = Console.ReadLine();
                codigoValido = Produto.ValidarCodigoDeBarras(codigo);

                if (!codigoValido)
                {
                    Console.WriteLine("Código de barras inválido, digite novamente.");
                }

            } while (!codigoValido);

            Console.WriteLine("Nome (Máximo 20 caracteres):");
            string nome = Console.ReadLine();

            Console.WriteLine("Valor de venda:");

            float valor = float.Parse(Console.ReadLine());

            return new(codigo, nome, valor);
        }
        public static void AlterarProduto(Produto produto)
        {
            int opcao;
            do
            {
                Console.WriteLine("\nSelecione qual informação deseja alterar: ");
                Console.WriteLine(produto.GerarStringParaEdicao());
                /*
                 * 1 - Nome
                 * 2 - Valor de venda
                 * 3 - Situacao
                 */
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Alteração de Nome: ");
                        string novoNome = Console.ReadLine();
                        produto.Nome = novoNome;
                        break;
                    case 2:
                        Console.WriteLine("Alterar valor de venda:");
                        float novoValor = float.Parse(Console.ReadLine());
                        produto.ValorVenda = novoValor;
                        break;
                    case 3:
                        string atual = produto.Situacao == 'A' ? "ativo" : "inativo";
                        string novo = produto.Situacao == 'A' ? "intivo" : "ativo";

                        Console.WriteLine($"O produto está {atual}, confirmar aletração para {novo}? (s) Sim / (n) Não");
                        if (Console.ReadLine().ToLower() == "s") produto.InverterSituacao();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.\n");
                        break;
                }
            } while (opcao is < 1 or > 3);
        }

    }
}
