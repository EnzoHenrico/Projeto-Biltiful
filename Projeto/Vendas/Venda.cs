using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Vendas.Utils;

namespace Projeto.Vendas
{
    internal class Venda
    {
        public int Id { get; private set; }
        public DateOnly DataVenda { get; set; }
        public string Cliente { get; set; }
        public float ValorTotal { get; set; }

        public Venda() { Id = NovoId(); }

        private int NovoId()
        {
            StreamReader sr = new(@"C:\Biltiful\Venda.dat");
            int UltimoId = 0;
            string linha;
            while ((linha = sr.ReadLine()) != null) UltimoId = int.Parse(linha.Take(5).ToArray());
            sr.Close();
            return UltimoId++;
        }

        public void CadastrarVenda(string cpf, double valorTotal)
        {
            try
            {
                StreamWriter sr = new(@"C:\Biltiful\Venda.dat");
                string linha = $"{this.Id.ToString().PadLeft(5, '0')}" +
                    $"{DateTime.Now.ToString("ddMMyyyy")}" +
                    $"{cpf}" +
                    $"{valorTotal.ToString().Replace(".", "").PadLeft(7, '0')}";
                Console.WriteLine("venda: " + linha);
                sr.WriteLine(linha);
                sr.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
