using Projeto.Cadastro;
using Projeto.Cadastro.Manipuladores;
using Projeto.Compras;
using Projeto.Vendas;
using Projeto.Vendas.Manipuladores;

namespace Projeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Classe responsavel por validar a existencia ou permissao para manipular arquivos
            ManipuladorArquivos.VerificarArquivosPadrao();
            var cadastro = new MainCadastro();
            var vendas = new MainVendas();

            int opcao;
            bool repetir = true;
            do
            {
                Console.Clear();
                Console.WriteLine("*** Biltiful Cosméticos ***\n");
                Console.WriteLine("Qual módulo deseja acessar?\n");
                Console.WriteLine("1 - Cadastro");
                Console.WriteLine("2 - Vendas");
                Console.WriteLine("3 - Compras");
                Console.WriteLine("4 - Produção");
                Console.WriteLine("0 - Fechar");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        cadastro.Acesso();
                        break;
                    case 2:
                        vendas.menu();
                        break;
                    case 3:
                        MainCompras.Acesso();
                        break;
                    case 4:
                        // TODO: MainProducao.Acesso();
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
