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
            int opcao;
            bool repetir = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Selecione uma opção de cadastro:\n\n" +
                              "1 - Clientes\n" +
                              "2 - Produtos\n" +
                              "3 - Fornecedor\n" +
                              "4 - Matéria Prima\n" +
                              "5 - Gerenciar Inadimplentes\n" +
                              "0 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        menuCliente();
                        break;
                    case 2:
                        menuProduto();
                        break;
                    case 3:
                        menuFornecedor();
                        break;
                    case 4:
                        menuMPrima();
                        break;
                    case 5:
                        menuInadimplentes();
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
        
        private void menuCliente()
        {
            var manipulador = new ManipuladorClientes(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoCliente);
            bool repetir = true;
            do
            {
                Console.WriteLine("\nSelecione a ação: :\n\n" +
                              "1 - Cadastrar novo cliente\n" +
                              "2 - Editar cliente\n" +
                              "3 - Exibir clientes ativos\n" +
                              "4 - Exibir clientes inativos\n" +
                              "5 - Exibir todos registros\n" +
                              "0 - Sair\n"
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

        private void menuFornecedor()
        {
            var manipulador = new ManipuladorFornecedores(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoFornecedor);
            bool repetir = true;
            do
            {
                Console.WriteLine("\nSelecione a ação: :\n\n" +
                                  "1 - Cadastrar novo fornecedor\n" +
                                  "2 - Editar fornecedor\n" +
                                  "3 - Exibir fornecedores ativos\n" +
                                  "4 - Exibir fornecedores inativos\n" +
                                  "5 - Exibir todos registros\n" +
                                  "0 - Sair\n"
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

        private void menuProduto()
        {
            var manipulador = new ManipuladorProdutos(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoProduto);
            bool repetir = true;
            do
            {
                Console.WriteLine("\nSelecione a ação: :\n\n" +
                                  "1 - Cadastrar novo produto\n" +
                                  "2 - Editar produto\n" +
                                  "3 - Exibir produtos ativos\n" +
                                  "4 - Exibir produtos inativos\n" +
                                  "5 - Exibir todos registros de produto\n" +
                                  "0 - Sair\n"
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


        private void menuMPrima()
        {
            var manipulador = new ManipuladorMPrima(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoMPrima);
            bool repetir = true;
            do
            {
                Console.WriteLine("\nSelecione a ação: :\n\n" +
                                  "1 - Cadastrar nova Matéria Prima\n" +
                                  "2 - Editar MP\n" +
                                  "3 - Exibir MPs ativas\n" +
                                  "4 - Exibir MPs inativos\n" +
                                  "5 - Exibir todos registros de MP\n" +
                                  "0 - Sair\n"
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

        private void menuInadimplentes()
        {
            var manipuladorBloqueados = new ManipuladorBloqueados(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoBloqueados);
            var manipuladorRiscos = new ManipuladorRiscos(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoRiscos);

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
