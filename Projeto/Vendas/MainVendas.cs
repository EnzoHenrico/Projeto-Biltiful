using Projeto.Vendas.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Vendas
{
    internal class MainVendas
    {
        string path = @"C:\Biltiful\";
        int opcao;
        ItemVenda ItemVenda = new();
        List<ItemVenda> carrinho;

        public void FormularioVenda() //ADICIONA PRODUTOS NO CARRINHO
        {
            //CPF
            int resetCpf = 0;
            string cpf;
            Venda venda = new();
            do
            {
                Console.Write("Informe o CPF do cliente:");
                cpf = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"\nConfirma CPF? {cpf}\n" +
                    $"1 - SIM;\n" +
                    $"0 - NÃO");
                resetCpf = int.Parse(Console.ReadLine());
            } while (resetCpf != 0);

            StreamReader sr = new(@"C:\Biltiful\Cosmetico.dat");
            int fimCarrinho = 0;
            do
            {
                string? linha = null;
                int contador = 0, addProduto = 0, quantidade = 0;

                //MOSTRAR PRODUTOS NA TELA
                Console.WriteLine("------------PRODUTOS------------");
                while ((linha = sr.ReadLine()) != null)
                {
                    contador++;
                    string nome, valor, codigoBarras;
                    if (linha[54] == 'A')
                    {
                        nome = linha.Substring(13, 20);
                        valor = linha.Substring(33, 5).Insert(3, ",");
                        codigoBarras = linha.Substring(0, 13);

                        Console.WriteLine($"{contador} - {nome} - PREÇO: {valor} - CODIGO: {codigoBarras}");
                    }
                }

                //ADICIONAR PRODUTO NO CARRINHO
                contador = 0;
                linha = null;
                Console.Write("\nAdicionar produto: ");
                addProduto = int.Parse(Console.ReadLine());
                Console.Write("\nQuantidade: ");
                quantidade = int.Parse(Console.ReadLine());


                while ((linha =  sr.ReadLine()) != null)
                {
                    string CodigoBarras;
                    double ValorVenda = 0;
                    char Situacao;
                    contador++;
                    if (contador == addProduto)
                    {
                        CodigoBarras = linha.Substring(0, 13);
                        ValorVenda = double.Parse(linha.Substring(33, 5).Insert(3, ","), NumberStyles.Any, new CultureInfo("pt-BR"));

                        carrinho.Add(new ItemVenda(
                            venda.Id,
                            CodigoBarras,
                            quantidade,
                            ValorVenda,
                            ValorVenda * quantidade));
                    }
                }
            } while (fimCarrinho != 0);
            sr.Close();
        }

        void menu()
        {
            Console.WriteLine("--------------------------MODULO DE VENDAS--------------------------\n" +
                "1 - Realizar venda;\n" +
                "2 - ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    
                    break;
            }
        }
    }
}
