using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class MainProducao
    {
        static void Main(string[] args)
        {
            string Diretorio = @"C:\Biltiful\";
            string ArquivoProdutos = "Cosmetico.dat";
            string ArquivoProducao = "Producao.dat";
            string a;
            int opcao = 0;
            Producao p = new Producao();
            ItemProducao ip = new ItemProducao();

            void Menu() 
            {
                Console.WriteLine("==============================");
                Console.WriteLine(">>>>> MENU PRODUÇÃO <<<<<");
                Console.WriteLine("[1] - CADASTRAR PRODUÇÃO");
                Console.WriteLine("[2] - LOCALIZAR PRODUÇÃO");
                Console.WriteLine("[3] - REMOVER PRODUÇÃO");
                Console.WriteLine("[4] - NAVEGAR POR REGISTRO");
                Console.WriteLine("[5] - SAIR DO PROGRAMA");
                Console.WriteLine("==============================");
            }
            do
            {
                Menu();
                Console.WriteLine("Escolha uma opção");
                opcao = int.Parse(Console.ReadLine());
                switch(opcao)
                {
                    case 1:
                        p.CriarProducao(ip);
                        break;
                    case 2:
                        p.LocalizarProducao(ip);
                        break;
                    case 3:
                        p.RemoverProducao();
                        break;
                    case 4:
                        p.NavegarProducao();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }

            } while (true);
            }
    }
}
