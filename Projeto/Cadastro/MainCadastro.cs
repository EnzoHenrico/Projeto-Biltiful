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

        //public MainCadastro()
        //{

        //}

        public static void Acesso()
        {
            Console.WriteLine("Selecione uma opção de cadastro: \n1- Clientes\n");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("ok");
                    break;
            }
        }

        public void menu()
        {

        }
        
        public void menuCliente()  
        {

        }

        public void menuMPrima()   
        {

        }

        public void menuProduto()  
        {

        }

        public void menuFornecedor()
        
        {

        }
    }
}
