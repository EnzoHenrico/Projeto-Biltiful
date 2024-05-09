using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class Producao
    {
         int Id;
        DateOnly DataProducao;
        string Produto;
        int Quantidade;
        

        public Producao()
        {
        }

        public Producao(int id, DateOnly dataProducao, string produto, int quantidade)
        {
            Id = id;
            DataProducao = dataProducao;
            Produto = produto;
            Quantidade = quantidade;
        }

        public bool VerificarProduto(string p, string f)
        {
            StreamReader sr = new StreamReader(p + f);

            Console.WriteLine("Digite o id do produto que deseja iniciar a produção:");
            string idProducao = Console.ReadLine();
            foreach(string line in sr.ReadLine(p+f))
            {

            }

        }
    }
}
