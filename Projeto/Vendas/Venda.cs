using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Vendas.Utils;
using Projeto.Vendas;

namespace Projeto.Vendas
{
    internal class Venda
    {
        public int Id { get; private set; }
        public DateOnly DataVenda { get; set; }
        public string Cliente {get; set;}
        public float ValorTotal {get; set;}

        public Venda() { }

        public Venda(DateOnly dataVenda, string cliente, float valorTotal)
        {
            Id = NovoId();
            DataVenda = dataVenda;
            Cliente = cliente;
            ValorTotal = valorTotal;
        }

        private int NovoId()
        {
            StreamReader sr = new (@"C:\BILTIFUL\Venda.dat");
            int UltimoId = 0;
            string linha;
            while ((linha = sr.ReadLine()) != null) UltimoId = int.Parse(linha.Take(5).ToArray());
            return UltimoId++;
        }

        public void CadastrarVenda(string cpf)
        {
            if (Validacoes.VerificarCpf(cpf))
            {
                //CRIAR LINHA DE VENDA AQUI!!!!

                //ManipularArquivos.InserirLinha(@"C:\BILTIFUL\", "Venda.dat", );
            }
        }

        public void ImprimirVenda(Venda v)
        {

        }
    }
}
