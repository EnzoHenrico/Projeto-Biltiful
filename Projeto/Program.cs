using Projeto.Cadastro;
using Projeto.Vendas;
using Projeto.Vendas.Manipuladores;

namespace Projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "Clientes.dat");
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "Cosmetico.dat");
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "Fornecedor.dat");
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "ItemVenda.dat");
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "Materia.dat");
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "Risco.dat");
            ManipularArquivos.VerificarArquivo(@"C:\Biltiful\", "Venda.dat");

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
                    new MainVendas().menu();
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
