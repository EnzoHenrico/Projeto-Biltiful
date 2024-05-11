using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Vendas
{
    internal class ItemVenda
    {
        public int Id { get; set; }
        public string? Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double TotalItem { get; set; }

        public ItemVenda() { }

        public ItemVenda(int id, string? produto, int quantidade, double valorUnitario, double totalItem)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;

            Console.WriteLine($"Produto {Produto} adicionado com sucesso!\n" +
                $"Quantidade: {Quantidade}\n" +
                $"Valor unitário: {ValorUnitario}\n" +
                $"Valor total: {TotalItem}");
        }
    }
}
