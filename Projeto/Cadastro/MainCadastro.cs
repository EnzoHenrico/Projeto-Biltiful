using Projeto.Cadastro.Entidades;
using Projeto.Cadastro.Manipuladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManipuladorFornecedores = Projeto.Cadastro.Manipuladores.ManipuladorFornecedores;

namespace Projeto.Cadastro
{
    internal class MainCadastro
    {
        public void Acesso()
        {
            bool repetir = true;
            do
            {
                Console.Clear();
                Console.WriteLine("|----[ Módulo de cadastro ]----|\n\n" +
                                  "Selecione uma opção de cadastro:\n" +
                                  "[ 1 ] Clientes\n" +
                                  "[ 2 ] Produtos\n" +
                                  "[ 3 ] Fornecedor\n" +
                                  "[ 4 ] Matéria Prima\n" +
                                  "[ 5 ] Gerenciar Inadimplentes\n" +
                                  "[ 0 ] Sair");

                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuCliente();
                        break;
                    case 2:
                        MenuProduto();
                        break;
                    case 3:
                        MenuFornecedor();
                        break;
                    case 4:
                        MenuMPrima();
                        break;
                    case 5:
                        MenuInadimplentes();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        Console.ReadKey();
                        break;
                }
            } while (repetir);
        }

        private static void MenuCliente()
        {
            var manipulador = new ManipuladorClientes(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoCliente);
            bool repetir = true;
            do
            {
                Console.WriteLine("\n|----[ Cliente ]----|\n\n" +
                              "[ 1 ] Cadastrar novo\n" +
                              "[ 2 ] Buscar e editar \n" +
                              "[ 3 ] Exibir ativos\n" +
                              "[ 4 ] Exibir inativos\n" +
                              "[ 5 ] Exibir todos registros\n" +
                              "[ 0 ] Sair\n"
                              );

                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        manipulador.Cadastrar();
                        break;
                    case 2:
                        manipulador.Editar();
                        break;
                    case 3:
                        manipulador.ImprimirClientesAtivos();
                        break;
                    case 4:
                        manipulador.ImprimirClientesInativos();
                        break;
                    case 5:
                        manipulador.ImprimirTodosClientes();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        break;
                }
            } while (repetir);
        }

        private static void MenuFornecedor()
        {
            var manipulador = new ManipuladorFornecedores(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoFornecedor);
            bool repetir = true;
            do
            {
                Console.WriteLine("\n|----[ Fornecedor ]----|\n\n" +
                                  "[ 1 ] Cadastrar novo\n" +
                                  "[ 2 ] Buscar e editar \n" +
                                  "[ 3 ] Exibir ativos\n" +
                                  "[ 4 ] Exibir inativos\n" +
                                  "[ 5 ] Exibir todos registros\n" +
                                  "[ 0 ] Sair\n"
                );

                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        manipulador.Cadastrar();
                        break;
                    case 2:
                        manipulador.Editar();
                        break;
                    case 3:
                        manipulador.ImprimirForncedoresAtivos();
                        break;
                    case 4:
                        manipulador.ImprimirFornecedoreInativos();
                        break;
                    case 5:
                        manipulador.ImprimirTodosForncedores();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        break;
                }
            } while (repetir);
        }

        private static void MenuProduto()
        {
            var manipulador = new ManipuladorProdutos(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoProduto);
            bool repetir = true;
            do
            {
                Console.WriteLine("\n|----[ Produtos ]----|\n\n" +
                                  "[ 1 ] Cadastrar novo\n" +
                                  "[ 2 ] Buscar e editar \n" +
                                  "[ 3 ] Exibir ativos\n" +
                                  "[ 4 ] Exibir inativos\n" +
                                  "[ 5 ] Exibir todos registros\n" +
                                  "[ 0 ] Sair\n"
                );

                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        manipulador.Cadastrar();
                        break;
                    case 2:
                        manipulador.Editar();
                        break;
                    case 3:
                        manipulador.ImprimirProdutosAtivos();
                        break;
                    case 4:
                        manipulador.ImprimirProdutosInativos();
                        break;
                    case 5:
                        manipulador.ImprimirTodosProdutos();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        break;
                }
            } while (repetir);
        }

        private static void MenuMPrima()
        {
            var manipulador = new ManipuladorMPrima(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoMateria);
            bool repetir = true;
            do
            {
                Console.WriteLine("\n|----[ Matéria Prima ]----|\n\n" +
                                  "[ 1 ] Cadastrar novo\n" +
                                  "[ 2 ] Buscar e editar \n" +
                                  "[ 3 ] Exibir ativos\n" +
                                  "[ 4 ] Exibir inativos\n" +
                                  "[ 5 ] Exibir todos registros\n" +
                                  "[ 0 ] Sair\n"
                );

                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        manipulador.Cadastrar();
                        break;
                    case 2:
                        manipulador.Editar();
                        break;
                    case 3:
                        manipulador.ImprimirMateriasAtivos();
                        break;
                    case 4:
                        manipulador.ImprimirMateriaInativos();
                        break;
                    case 5:
                        manipulador.ImprimirTodasMaterias();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        break;
                }
            } while (repetir);
        }

        private static void MenuInadimplentes()
        {
            var manipuladorBloqueados = new ManipuladorBloqueados(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoBloqueado);
            var manipuladorRiscos = new ManipuladorRiscos(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoRisco);
            bool repetir = true;
            do
            {
                Console.WriteLine("\nSelecione a ação: :\n\n" +
                                  "1 - Adicionar cliente da lista de riscos\n" +
                                  "2 - Remover cliente da lista de riscos\n" +
                                  "3 - Visualizar lista de riscos\n" +
                                  "4 - Adicionar fornecedor da lista de bloqueados\n" +
                                  "5 - Remover fornecedor da lista de bloqueados\n" +
                                  "6 - Visualizar lista de bloqueados\n" +
                                  "0 - Sair\n"
                );

                Console.WriteLine("\n|----[ Inadimplentes: Clientes ]----|\n\n" +
                                  "[ 1 ] Adicionar cliente da lista de risco\n" +
                                  "[ 2 ] Remover cliente da lista de risco\n" +
                                  "[ 3 ] Visualizar lista de risco\n" +
                                  "\n|----[ Inadimplentes: Fornecedores ]----|\n\n\" +" +
                                  "[ 4 ] Adicionar fornecedor da lista de bloqueados\n" +
                                  "[ 5 ] Remover fornecedor da lista de bloqueados\n" +
                                  "[ 6 ] Visualizar lista de bloqueados\n\n" +
                                  "[ 0 ] Sair\n"
                );

                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        manipuladorRiscos.Cadastrar();
                        break;
                    case 2:
                        manipuladorRiscos.Remover();
                        break;
                    case 3:
                        manipuladorRiscos.ImprimirTodosRiscos();
                        break;
                    case 4:
                        manipuladorBloqueados.Cadastrar();
                        break;
                    case 5:
                        manipuladorBloqueados.Remover();
                        break;
                    case 6:
                        manipuladorBloqueados.ImprimirTodosBloqueados();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        break;
                }
            } while (repetir);
        }
    }
}