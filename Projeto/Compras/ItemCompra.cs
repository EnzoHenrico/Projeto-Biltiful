using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Compras
{
    internal class ItemCompra
    {
        int Id;
        DateOnly DataCompra;
        int MateriaPrima;
        int Quantidade;
        int ValorUnitario;
        int TotalItem;

        public ItemCompra()
        {
        }

        public ItemCompra(int id, DateOnly dataCompra, int materiaPrima, int quantidade, int valorUnitario, int totalItem)
        {
            Id = id;
            DataCompra = dataCompra;
            MateriaPrima = materiaPrima;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;
        }
        public int PegarTotalItem()
        {
            return TotalItem;
        }
    }
}
