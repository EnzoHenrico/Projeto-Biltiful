using Projeto.Cadastro.Entidades;
using Projeto.Cadastro.Manipuladores; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro
{
    internal class MainCadastro
    {
        private readonly ManipuladorClientes _manipuladorClientes = new(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoCliente);
        // ManipuladorProduto
        // ManipularMPrima
        // ManipularFornecedor

        public void Acesso()
        {
            Console.Write("Selecione uma opção de cadastro:\n" +
                              "1 - Clientes\n" +
                              "2 - Produtos\n" +
                              "3 - Fornecedor\n" +
                              "4 - Matéria Prima\n\n" +
                              "Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    menuCliente();
                    break;
                case "2":
                    menuProduto();
                    break;
                case "3":
                    menuFornecedor();
                    break;
                case "4":
                    menuMPrima();
                    break;
            }
        }
        
        private void menuCliente()
        {
            bool repetir = true;
            do
            {
                Console.WriteLine("Selecione a ação: :\n" +
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
                        _manipuladorClientes.Cadastrar();
                        break;
                    case 2:
                        _manipuladorClientes.Editar();
                        break;
                    case 3:
                        _manipuladorClientes.ImprimirClientesAtivos();
                        break;
                    case 4:
                        _manipuladorClientes.ImprimirClientesInAtivos();
                        break;
                    case 5:
                        _manipuladorClientes.ImprimirTodosClientes();
                        break;
                    case 0:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Entrada inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para voltar.");
                Console.ReadKey();
            } while (repetir);
        }

        private void menuMPrima()   
        {

        }

        private void menuProduto()  
        {

        }

        private void menuFornecedor()
        
        {

        }
    }
}
