using Projeto.Vendas.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Vendas.Utils;

namespace Projeto.Vendas
{
    internal class MainVendas
    {
        string cpf;
        int opcao;
        double ValorTotalVenda = 0;
        ItemVenda ItemVenda = new();
        Venda venda = new();
        List<ItemVenda> carrinho = new();

        public void FormularioVenda() //ADICIONA PRODUTOS NO CARRINHO
        {
            //CPF
            int resetaCpf;
            do
            {
                Console.Write("Informe o CPF do cliente:");
                cpf = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"\nConfirma CPF? {cpf}\n" +
                    $"1 - SIM;\n" +
                    $"0 - NÃO");
                resetaCpf = int.Parse(Console.ReadLine());
            } while (resetaCpf == 0 || !Validacoes.VerificarCpf(cpf));

            //CARRINHO
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

                        Console.WriteLine($"{contador} - {nome} - PREÇO: R${double.Parse(valor)} - CODIGO: {codigoBarras}");
                    }
                }

                //SELECIONAR PRODUTO
                Console.Write("\nAdicionar produto: ");
                addProduto = int.Parse(Console.ReadLine());
                Console.Write("\nQuantidade: ");
                quantidade = int.Parse(Console.ReadLine());

                StreamReader sr1 = new(@"C:\Biltiful\Cosmetico.dat");
                string? produtoSelecionado = null;
                for (int i = 0; i < addProduto; i++) produtoSelecionado = sr1.ReadLine();
                sr1.Close();

                //ADICIONAR PRODUTO NO CARRINHO
                string CodigoBarras = produtoSelecionado.Substring(0, 13);
                double ValorVenda = double.Parse(produtoSelecionado.Substring(33, 5).Insert(3, ","), NumberStyles.Any, new CultureInfo("pt-BR"));
                char Situacao;

                carrinho.Add(new ItemVenda(
                    venda.Id,
                    CodigoBarras,
                    quantidade,
                    ValorVenda,
                    ValorVenda * quantidade));

                Console.WriteLine("Adicionar mais produtos?\n" +
                    "1 - SIM\n" +
                    "0 - NÃO");
                fimCarrinho = int.Parse(Console.ReadLine());
                if (carrinho.Count == 3) Console.WriteLine("Carrinho cheio. Para vender mais produtos faça uma nova venda!\n" +
                    "Cadastrando venda atual...");
            } while (fimCarrinho != 0);
            sr.Close();


            //CADASTRAR VENDA
            ItemVenda.CadastrarItemVenda(carrinho);
            venda.CadastrarVenda(cpf, ValorTotalVenda);
        }

        public void menu()
        {
            Console.WriteLine("--------------------------MODULO DE VENDAS--------------------------\n" +
                "1 - Realizar venda;\n" +
                "2 - Excluir venda;");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    FormularioVenda();
                    break;
                case 2:
                    break;
            }
        }
    }
}
