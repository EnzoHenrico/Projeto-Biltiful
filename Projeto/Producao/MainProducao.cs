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
            Producao p = new Producao();
            

            //a = p.VerificarProduto("1010");
            //b = p.GerarIdProducao();
            //Console.WriteLine(b);
            //List<Producao> copia = new();
            //copia = p.CopiarArquivo();
            //Producao p1 = new Producao(10, DateOnly.Parse("10/05/2024"), "7891111111111", 10);
            //copia.Add(p1);
            //p.FormatarProArquivo(copia);
            //void LocalizarProducao()
            // {
            //     Producao p = new Producao();
            //     List<Producao> copia = new();
            //     copia = p.CopiarArquivo();
            //     Console.WriteLine("Digite o id da produção que deseja localizar");
            //     int idProducao =  int.Parse(Console.ReadLine());
            //     foreach(var objeto in copia)
            //     {
            //         if (objeto.GetId() == idProducao )
            //         {
            //             Console.WriteLine(objeto.ToString());
            //         }
            //     }

            // }
            // LocalizarProducao();
            ItemProducao ip = new ItemProducao();
            List<ItemProducao> l;

            l = ip.CopiarArquivoItemProducao();
        }
    }
}
