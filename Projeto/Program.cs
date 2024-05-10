using Projeto.Cadastro;

namespace Projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Biutiful Cosméticos\n");
            
            Console.WriteLine("Qual módulo deseja acessar?");
            Console.WriteLine("1 - Cadastro\n");
            Console.WriteLine("2 - Vendas\n");
            Console.WriteLine("3 - Compras\n");
            Console.WriteLine("4 - Produção\n");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    // TODO: MainCadastro.Acesso();
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
