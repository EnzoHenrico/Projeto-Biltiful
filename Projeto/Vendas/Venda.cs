using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Vendas.Manipuladores;
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
            StreamReader sr = new(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoVenda);
            int UltimoId = 0;
            string linha;
            while ((linha = sr.ReadLine()) != null) UltimoId = int.Parse(linha.Take(5).ToArray());
            sr.Close();
            if (UltimoId == 0) { return 1; }
            return ++UltimoId;
        }

        public void CadastrarVenda(string cpf, double valorTotal)
        {
            try
            {
                StreamWriter sw = new(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoVenda, true);
                int valorTotalEmCentavos = (int)(valorTotal * 100);
                string linha = $"{this.Id.ToString().PadLeft(5, '0')}" +
                    $"{DateTime.Now.ToString("ddMMyyyy")}" +
                    $"{cpf}" +
                    $"{valorTotalEmCentavos.ToString().PadLeft(7, '0')}"; // Usa o valor total em centavos
                sw.WriteLine(linha);
                sw.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
