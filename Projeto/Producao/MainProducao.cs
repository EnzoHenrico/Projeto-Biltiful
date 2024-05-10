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

        Producao p = new Producao();
            bool a;
            int b;
            a = p.VerificarProduto("1010");
            b = p.GerarIdProducao();
            Console.WriteLine(b);
            List<Producao> copia = new();
           
        }
        
            

            
        
    }
}
