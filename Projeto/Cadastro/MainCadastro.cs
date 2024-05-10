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
        private ManipuladorClientes ManipuladorClientes;
        // ManipuladorProduto
        // ManipularMPrima
        // ManipularFornecedor

        public MainCadastro()
        {
            
        }

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
            string diretorio = @"C:\Biltiful\";
            string arquivo = "Cliente.dat";
            ManipuladorClientes manipulador = new(diretorio, arquivo);

            Console.Write("Selecione a ação: :\n" +
                          "1 - Cadastrar novo cliente\n" +
                          "2 - Buscar clientes ativos\n" +
                          "3 - Editar cliente\n\n" +
                          "Opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    // cadastrar
                    break;
                case "2":
                    // Buscar
                    break;
                case "3":
                    // Editar
                    break;
            }
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
