using Projeto.Cadastro;
using Projeto.Cadastro.Manipuladores;
using Projeto.Compras;
using Projeto.Producao;
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

            // Instancia dos inicializadores de cada módulo
            var cadastro = new MainCadastro();
            var compras = new MainCompras();
            var vendas = new MainVendas();
            var producao = new MainProducao();

            bool repetir = true;
            do
            {
                Console.Clear();
                Console.WriteLine("+-------------------------------------+");
                Console.WriteLine("|         Biltiful Cosméticos         |");
                Console.WriteLine("+-------------------------------------+");
                Console.WriteLine("\nSeleciona o módulo que deseja acessar:");
                Console.WriteLine("[ 1 ] Cadastro");
                Console.WriteLine("[ 2 ] Vendas");
                Console.WriteLine("[ 3 ] Compras");
                Console.WriteLine("[ 4 ] Produção");
                Console.WriteLine("[ 0 ] Fechar");

                Console.Write("\nOpção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        cadastro.Acesso();
                        break;
                    case 2:
                        vendas.Acesso();
                        break;
                    case 3:
                        compras.Acesso();
                        break;
                    case 4:
                        producao.Acesso();
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
