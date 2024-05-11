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

            void Menu() 
            {
                Console.WriteLine("[1] - CADASTRAR PRODUÇÃO");
                Console.WriteLine("[2] - LOCALIZAR PRODUÇÃO");
                Console.WriteLine("[3] - REMOVER PRODUÇÃO");
                Console.WriteLine("[4] - SAIR DO PROGRAMA");

            }

            do
            {
                Menu();
                Console.WriteLine("Escolha uma opção");
                opcao = int.Parse(Console.ReadLine());
                switch(opcao)
                {
                    case 1:
                        p.CriarProducao();
                        break;
                    case 2:
                        p.LocalizarProducao();
                        break;
                    case 3:
                        p.RemoverItemProducao();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }


            } while (true);
            //a = p.VerificarProduto("1010");
            //b = p.GerarIdProducao();
            //Console.WriteLine(b);
            //List<Producao> copia = new();
            //copia = p.CopiarArquivo();
            //Producao p1 = new Producao(10, DateOnly.Parse("10/05/2024"), "7891111111111", 10);
            //copia.Add(p1);
            //p.FormatarProArquivo(copia);
            

                //}
                //LocalizarProducao();

                //p.CriarProducao();

                //List<ItemProducao> l;


                //ip.CriarItemProducao("1");
                //l = ip.CopiarArquivoItemProducao();
                //double teste = float.Parse(Console.ReadLine());
                //l.Add(new("10",DateOnly.Parse("11/05/2024"),"MP0001",teste));
                //ip.FormatarProArquivo(l);
            }
    }
}
