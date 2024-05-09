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

        }
    }
}
