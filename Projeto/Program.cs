using Projeto.Cadastro;
using Projeto.Cadastro.Manipuladores;

namespace Projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Biutiful Cosméticos\n");
            
            Console.WriteLine("Qual módulo deseja acessar?\n");
            Console.WriteLine("1 - Cadastro");
            Console.WriteLine("2 - Vendas");
            Console.WriteLine("3 - Compras");
            Console.WriteLine("4 - Produção");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    new MainCadastro().Acesso();
                    break;
                case "2":
                    // TODO: MainVendas.Acesso();
                    break;
                case "3":
                    // TODO: MainCompras.Acesso();
                    break;
                case "4":
                    // TODO: MainProducao.Acesso();
                    break;

            }
        }
    }
}
