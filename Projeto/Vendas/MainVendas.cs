using Projeto.Vendas.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Vendas.Utils;
using Projeto.Vendas.Manipuladores;
using System.Data;

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
                Console.Clear();
                Console.Write("Informe o CPF do cliente:");
                cpf = Console.ReadLine();
                Console.WriteLine($"\nConfirma CPF? {cpf}\n" +
                    $"[ 1 ] Sim\n" +
                    $"[ 2 ] Corrigir\n" +
                    $"[ 0 ] Voltar");
                resetaCpf = int.Parse(Console.ReadLine());
                if (resetaCpf == 0) break;
            } while (resetaCpf != 1 || !Validacoes.VerificarCpf(cpf));
            if (resetaCpf == 0) return;

            //CARRINHO
            int fimCarrinho = 0;
            do
            {
                Console.Clear();
                string? linha = null;
                int contador = 0, addProduto = 0, quantidade = 0;

                do
                {
                    Console.Clear();
                    StreamReader sr = new(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProduto);
                    Console.WriteLine("|----[ Produtos ]----|");
                    //MOSTRAR PRODUTOS NA TELA
                    while ((linha = sr.ReadLine()) != null)
                    {
                        contador++;
                        string nome, valor, codigoBarras;
                        if (linha[54] == 'A')
                        {
                            nome = linha.Substring(13, 20);
                            valor = linha.Substring(33, 5).Insert(3, ",");
                            codigoBarras = linha.Substring(0, 13);

                            Console.WriteLine($"{contador} - {nome} - PREÇO: R${double.Parse(valor, new CultureInfo("pt-BR"))} - CODIGO: {codigoBarras}");
                        }
                    }

                    //SELECIONAR PRODUTO
                    Console.Write("\nAdicionar produto: ");
                    addProduto = int.Parse(Console.ReadLine());
                    Console.Write("\nQuantidade: ");
                    quantidade = int.Parse(Console.ReadLine());
                    if (quantidade > 999)
                    {
                        Console.WriteLine("ERRO: A quantidade deve ser menor que 999.");
                        Thread.Sleep(3000);
                    };
                    sr.Close();
                } while (quantidade > 999);

                StreamReader sr1 = new(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProduto);
                string? produtoSelecionado = null;
                for (int i = 0; i < addProduto; i++) produtoSelecionado = sr1.ReadLine();
                sr1.Close();

                //ADICIONAR PRODUTO NO CARRINHO
                string CodigoBarras = produtoSelecionado.Substring(0, 13);
                double ValorVenda = double.Parse(produtoSelecionado.Substring(33, 5).Insert(3, ","), NumberStyles.Any, new CultureInfo("pt-BR"));
                ValorTotalVenda += ValorVenda * quantidade;
                char Situacao = produtoSelecionado[54];

                if (ValorTotalVenda < 99999.99)
                {
                    if (Situacao == 'A')
                    {
                        carrinho.Add(new ItemVenda(
                            venda.Id,
                            CodigoBarras,
                            quantidade,
                            ValorVenda,
                            ValorTotalVenda));
                    }
                    else
                    {
                        Console.WriteLine("ERRO: Produto INATIVO.");
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    Console.WriteLine("ERRO: Valor da venda ultrapassa o limite máximo de 99999,99.\n" +
                        "Divida em duas vendas diferentes!");
                    Thread.Sleep(3000);
                }

                if (carrinho.Count < 3)
                {
                    Console.Clear();
                    Console.WriteLine("Adicionar mais produtos?\n" +
                        "[ 1 ] Sim\n" +
                        "[ 0 ] Não");
                    fimCarrinho = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Carrinho cheio. Para vender mais produtos faça uma nova venda!\n" +
                    "Cadastrando venda atual...");
                    Thread.Sleep(3000);
                    fimCarrinho = 0;
                }
            } while (fimCarrinho != 0);


            //CADASTRAR VENDA
            if (carrinho.Count > 0)
            {
                ItemVenda.CadastrarItemVenda(carrinho);
                venda.CadastrarVenda(cpf, ValorTotalVenda);
                Console.WriteLine("Venda cadastrada com SUCESSO!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Carrinho vazio. Abortando processo de venda!");
                Thread.Sleep(3000);
            }
        }

        public void BuscarVendas()
        {
            int resetar = 0;
            do
            {
                Console.Clear();
                int contador = 0;
                Console.WriteLine("Digite algo que deseja pesquisar nas vendas cadastradas.\n" +
                    "Pode ser CPF do cliente, ID da venda ou a data da venda sem barras.");
                string texto = Console.ReadLine();

                List<string>? Vendas = ManipuladorArquivosVenda.BuscarLinhas(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoVenda, texto);

                if (Vendas != null)
                {
                    Console.WriteLine($"Vendas encontradas com a busca: {texto}...");

                    foreach (string venda in Vendas)
                    {
                        string id = venda.Substring(0, 5);
                        string data = DateTime.ParseExact(venda.Substring(5, 8), "ddMMyyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                        string cpf = venda.Substring(13, 11);
                        double valorTotal = Math.Round(double.Parse(venda.Substring(24, 7)) / 100, 2);
                        string itens = "", linha = "";

                        contador++;
                        //BUSCAR ITEMVENDA RELACIONADO A LINHA ESPECIFICA
                        try
                        {
                            List<string>? ItensRelacionados = ManipuladorArquivosVenda.BuscarLinhas(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoItemVenda, id);
                            foreach (var item in ItensRelacionados)
                            {
                                string código = item.Substring(5, 13);
                                int quantidade = int.Parse(item.Substring(18, 3));
                                double valorUnitario = double.Parse(item.Substring(21, 5)) / 100;
                                itens += $"Código: {código} - Quantidade: {quantidade} - Valor unitario: R${valorUnitario}\n - Valor total: R${Math.Round(quantidade * valorUnitario, 2)}\n";
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"\nERRO: {e.Message}\n");
                        }
                        finally
                        {
                            //CRIAR A LINHA DA VENDA COM OS ITENS RELACIONADOS ENCONTRADOS
                            linha = $"\n{contador} - ID: {id} - Data: {data} - CPF: {cpf} - Valor total: R${valorTotal}\n" +
                                $"Produtos relacionados:\n" +
                                $"{itens}\n";
                            Console.WriteLine(linha);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nenhuma venda encontrada com a busca informada...\n");
                }

                Console.WriteLine("Deseja efetuar uma nova busca?\n" +
                    "[ 1 ] Sim\n" +
                    "[ 0 ] Não");
                resetar = int.Parse(Console.ReadLine());
            } while (resetar != 0);
        }

        public void ExcluirVenda()
        {
            Console.Write("Informe o ID da venda que deseja excluir:");
            string id = Console.ReadLine().PadLeft(5, '0');
            ManipuladorArquivosVenda.ExcluirVendaPorId(DicionarioStrings.Diretorio, DicionarioStrings.ArquivoVenda, DicionarioStrings.ArquivoItemVenda, id);
        }

        public void Acesso()
        {
            Console.Clear();
            Console.WriteLine("|----[ Módulo de Vendas ]----|\n\n" + 
                              "Selecione uma opção para continuar:\n" +
                              "[ 1 ] Realizar venda\n" + 
                              "[ 2 ] Buscar venda\n" + 
                              "[ 3 ] Excluir venda\n" + 
                              "[ 0 ] Voltar");

            Console.Write("\nOpção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    FormularioVenda();
                    break;
                case 2:
                    BuscarVendas();
                    break;
                case 3:
                    ExcluirVenda();
                    break;
                default:
                    break;
            }
        }
    }
}
