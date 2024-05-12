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
            TotalItem = Math.Round(totalItem, 2);

            Console.WriteLine($"Produto {Produto} adicionado ao carrinho com sucesso!\n" +
                $"Quantidade: {Quantidade}\n" +
                $"Valor unitário: R${ValorUnitario}\n" +
                $"Valor total: R${TotalItem}");
            Thread.Sleep(3000);
        }

        public void CadastrarItemVenda(List<ItemVenda> carrinho)
        {
            try
            {
                StreamWriter sw = new(@"C:\Biltiful\ItemVenda.dat", true);
                foreach (var produto in carrinho)
                {
                    string linha = $"{produto.Id.ToString().PadLeft(5, '0')}" +
                    $"{produto.Produto}" +
                    $"{produto.Quantidade.ToString().PadLeft(3, '0')}" +
                    $"{(Math.Round(produto.ValorUnitario * 100)).ToString().PadLeft(5, '0')}" +
                    $"{(Math.Round(produto.TotalItem * 100)).ToString().PadLeft(6, '0')}";
                    sw.WriteLine(linha);
                }
                sw.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
