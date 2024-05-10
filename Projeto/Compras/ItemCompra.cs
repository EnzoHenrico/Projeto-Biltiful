using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Compras
{
    internal class ItemCompra
    {
        int Id { get; set; }
        DateOnly DataCompra { get; set; }
        int MateriaPrima { get; set; }
        int Quantidade { get; set; }
        int ValorUnitario { get; set; }
        int TotalItem { get; set; }

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
    }
}
