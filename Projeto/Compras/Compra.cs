using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Compras
{
    internal class Compra
    {
        int Id;
        DateOnly DataCompra;
        string Fornecedor;
        int ValorTotal; 

        public Compra()
        { }
        public Compra(int id, DateOnly dataCompra, string fornecedor, int valorTotal)
        {
            Id = id;
            DataCompra = dataCompra;
            Fornecedor = fornecedor;
            ValorTotal = valorTotal;
        }

        public int PegarId()
        {
            return Id;
        }
        public DateOnly MudarData()
        {
            return DataCompra;
        }
        public string MudarFornecedor()
        {
            return Fornecedor;
        }
        public int MudarValorTotal()
        {
            return ValorTotal;
        }
        public override string ToString()
        {
            return "Id - " + Id + "\nData da Compra - " + DataCompra + "\nFornecedor - " + Fornecedor + "\nValor Total - " + ValorTotal;
        }
        public string Formatar()
        {
            return Id.ToString("D5") + DataCompra.ToString("ddMMyyyy") + Fornecedor + ValorTotal.ToString("D7");
        }
    }
}
