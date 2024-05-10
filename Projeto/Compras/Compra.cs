using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Compras
{
    internal class Compra
    {
        int Id { get; set; }
        DateOnly DataCompra { get; set; }
        string Fornecedor { get; set; }
        int ValorTotal { get; set; }

        public Compra()
        {           
        }

        public Compra(int id, DateOnly dataCompra, string fornecedor, int valorTotal)
        {
            Id = id;
            DataCompra = dataCompra;
            Fornecedor = fornecedor;
            ValorTotal = valorTotal;
        }
    }
}
