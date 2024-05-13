using Projeto.Cadastro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entradas
{
    internal class EntradaInadimplente
    {
        public static string CadastrarBloqueado()
        {
            Console.WriteLine("Digite o CNPJ do fornecedor: ");
            string identificador = Console.ReadLine();

            return identificador;
        }

        public static string CadastrarRisco()
        {
            Console.WriteLine("Digite o CPF do cliente: ");
            string identificador = Console.ReadLine();
            
            return identificador;
        }

        public static string RemoverBloqueadoDaLista()
        {
            Console.WriteLine("Digite o CNPJ do fornecedor: ");
            string identificador = Console.ReadLine();
            
            return identificador;
        }
        
        public static string RemoverRiscoDaLista()
        {
            Console.WriteLine("Digite o CPF do cliente: ");
            string identificador = Console.ReadLine();
            
            return identificador;
        }

    }
}
