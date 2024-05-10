using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Vendas
{
    internal class MainVendas
    {
        string path = @"C:\BILTIFUL\";
        int opcao;
        Venda venda;

        void menu()
        {
            Console.WriteLine("--------------------------MODULO DE VENDAS--------------------------\n" +
                "1 - Realizar venda;\n" +
                "2 - ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("");
                    break;
            }
        }
    }
}
