using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class ItemProducao
    {
        string id;
        DateOnly DataProducao;
        string MateriaPrima;
        int QuantidadeMateriaPrima;

        public ItemProducao(){}

        public ItemProducao(string id, DateOnly dataProducao, string materiaPrima, int quantidadeMateriaPrima)
        {
            this.id = id;
            DataProducao = dataProducao;
            MateriaPrima = materiaPrima;
            QuantidadeMateriaPrima = quantidadeMateriaPrima;
        }
    }
}
