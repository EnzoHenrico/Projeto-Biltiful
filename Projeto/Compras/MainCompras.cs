using System.Xml;

namespace Projeto.Compras
{
    public class MainCompras
    {
        static List<Compra> compras = new List<Compra>();
        static List<ItemCompra> itensLista = new List<ItemCompra>();
        static string pasta = @"C:\Biltiful\";
        static string arquivo = "Compra.dat";
        static string arquivoItem = "ItemCompra.dat";
        static int identificadorCompra = 0;
        static void ChecarExistenciaArquivo()
        {
            if (!File.Exists(pasta + arquivo))
                File.Create(pasta + arquivo);
            if (!File.Exists(pasta + arquivoItem))
                File.Create(pasta + arquivoItem);
        }
        static void SavarLista()
        {
            StreamWriter sw = new StreamWriter(pasta + arquivo);
            foreach (Compra item in compras)
                sw.WriteLine(item.Formatar());
            sw.Close();
            StreamWriter sw2 = new StreamWriter(pasta + arquivoItem);
            foreach (ItemCompra item in itensLista)
                sw2.WriteLine(item.Formatar());
            sw2.Close();
        }

        #region Compra        
        static List<Compra> CarregarLista()
        {
            List<Compra> listaCarregada = new List<Compra>();
            foreach (var linha in File.ReadAllLines(pasta + arquivo))
                listaCarregada.Add(PegarCompra(linha));
            return listaCarregada;
        }
        static Compra PegarCompra(string linha)
        {
            string id = linha.Substring(0, 5).Trim();
            string dataDia = linha.Substring(5, 2).Trim();
            string dataMes = linha.Substring(7, 2).Trim();
            string dataAno = linha.Substring(9, 4).Trim();
            string fornecedor = linha.Substring(13, 14).Trim();
            string valorTotal = linha.Substring(27, 7).Trim();
            identificadorCompra = int.Parse(id);

            return new Compra(int.Parse(id), DateOnly.Parse(dataDia + "/" + dataMes + "/" + dataAno), fornecedor, int.Parse(valorTotal));
        }
        static bool VerificarFornecedor(string cnpj)
        {
            string arquivoFornecedor = "Fornecedor.dat";
            string arquivoBloqueado = "Bloqueado.dat";
            bool existe = false;
            foreach (var linha in File.ReadAllLines(pasta + arquivoFornecedor))
            {

                if (cnpj == linha.Substring(0, 14).Trim())
                {
                    existe = true;
                    foreach (var item in File.ReadLines(pasta + arquivoBloqueado))
                    {
                        if (cnpj == item)
                        {
                            Console.WriteLine("CNPJ bloqueado!");
                            existe = false;
                        }
                    }
                }
            }
            return existe;
        }
        static bool VerificarMateriaPrima(string mp)
        {
            string arquivoMateriaPrima = "Materia.dat";

            bool existe = false;
            foreach (var linha in File.ReadAllLines(pasta + arquivoMateriaPrima))
            {
                if (mp == linha.Substring(0, 6).Trim())
                    existe = true;
            }
            return existe;
        }
        static void CadastroCompra()
        {
            identificadorCompra++;
            int id = identificadorCompra, tamanho = 0, op = 0, ValorTotal = 0;
            string fornecedor;
            DateTime dataAtual = DateTime.Today;
            DateOnly dataCompra = new DateOnly(dataAtual.Year, dataAtual.Month, dataAtual.Day);

            Console.WriteLine("Digite o CNPJ do Fornecedor:");
            do
            {
                fornecedor = Console.ReadLine();
                if (!VerificarFornecedor(fornecedor))
                    Console.WriteLine("Fornecedor não existe!\nDigite o CNPJ novamente:");
            } while (!VerificarFornecedor(fornecedor));
            Console.WriteLine("Escolha os itens Compra:");

            List<ItemCompra> itensCompra = new List<ItemCompra>();
            do
            {
                ItemCompra item = CadastroItem(id, dataCompra);
                if (item != null)
                {
                    ValorTotal += item.PegarTotalItem();
                    if (ValorTotal <= 9999999)
                    {
                        tamanho++;
                        itensCompra.Add(item);
                        Console.WriteLine("Para parar de adicionar digite 0, ou digite qualquer outro número para continuar!");
                        op = int.Parse(Console.ReadLine());
                    }
                    else
                        Console.WriteLine("O valor máximo foi excedido! Faça uma nova compra com um valor abaixo do permitido!");
                }
                else
                    Console.WriteLine("Tente novamente;");

            } while (tamanho < 3 && op != 0);

            foreach (var item in itensCompra)
                itensLista.Add(item);
            compras.Add(new Compra(id, dataCompra, fornecedor, ValorTotal));
        }
        static void ListarCompra()
        {
            foreach (Compra item in compras)
            {
                Console.WriteLine(item.ToString());
                ListarItensCompra(item.PegarId());
            }
        }
        static void AcharCompra(int id)
        {
            Compra compra = compras.Find(p => p.PegarId() == id);
            Console.WriteLine(compra.ToString());
            ListarItensCompra(compra.PegarId());
        }
        static void ExcluirCompra(int id)
        {
            Compra compra = compras.Find(p => p.PegarId() == id);
            compras.Remove(compra);
            itensLista.RemoveAll(p => p.PegarId() == id);
        }
        #endregion

        #region ItemCompra        
        static List<ItemCompra> CarregarListaItemCompra()
        {
            List<ItemCompra> listaCarregada = new List<ItemCompra>();
            foreach (var linha in File.ReadAllLines(pasta + arquivoItem))
                listaCarregada.Add(PegarItemCompra(linha));
            return listaCarregada;
        }
        static ItemCompra PegarItemCompra(string linha)
        {
            string id = linha.Substring(0, 5).Trim();
            string dataDia = linha.Substring(5, 2).Trim();
            string dataMes = linha.Substring(7, 2).Trim();
            string dataAno = linha.Substring(9, 4).Trim();
            string materiaPrima = linha.Substring(13, 6).Trim();
            string quantidade = linha.Substring(19, 5).Trim();
            string valorUnitario = linha.Substring(24, 5).Trim();
            string totalItem = linha.Substring(29, 6).Trim();

            return new ItemCompra(int.Parse(id), DateOnly.Parse(dataDia + "/" + dataMes + "/" + dataAno), materiaPrima, int.Parse(quantidade), int.Parse(valorUnitario), int.Parse(totalItem));
        }
        static ItemCompra CadastroItem(int id, DateOnly dataCompra)
        {
            int quantidade = 0, valorUnitario = 0, totalItem = 0;
            string materiaPrima;

            Console.WriteLine("Digite o ID da matéria Prima só com números:");
            materiaPrima = Console.ReadLine();

            if (VerificarMateriaPrima("MP" + materiaPrima))
            {
                do
                {
                    Console.WriteLine("Digite a quantidade:");
                    quantidade = int.Parse(Console.ReadLine());
                    if (quantidade > 99999 || quantidade < 1)
                        Console.WriteLine("Digite um número válido!");
                } while (quantidade > 99999 || quantidade < 1);
                do
                {
                    Console.WriteLine("Digite o preço de compra:");
                    valorUnitario = int.Parse(Console.ReadLine());
                    if (quantidade > 99999 || quantidade < 1)
                        Console.WriteLine("Digite um número válido!");
                } while (valorUnitario > 99999 || valorUnitario < 0);
                totalItem = valorUnitario * quantidade;
                if (totalItem > 999999)
                    Console.WriteLine("Valor ultrapassou o preço máximo! Refaça a compra com uma quantidade menor de produtos para não ultrapassar o preço limite.");

                return new ItemCompra(id, dataCompra, "MP" + materiaPrima, quantidade, valorUnitario, totalItem);
            }
            else
            {
                Console.WriteLine("Materia Prima não existe!\nCadastre-a antes de comprar!");
                return null;

            }
        }
        static void ListarItensCompra(int id)
        {
            Console.WriteLine("Itens:");
            foreach (ItemCompra itensCompra in itensLista)
                if (itensCompra.PegarId() == id)
                    Console.WriteLine(itensCompra.ToString() + "\n");
        }
        #endregion

        public static void Acesso()
        {
            int op = 0;
            ChecarExistenciaArquivo();
            compras = CarregarLista();
            itensLista = CarregarListaItemCompra();
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Cadastre uma compra;\n" +
                              "2 - Liste as Compras\n" +
                              "3 - Exclua uma Compra" +
                              "0 - Para sair");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine("CADASTRE UMA COMPRA:");
                    CadastroCompra();
                    break;
                case 2:
                    Console.WriteLine("ESCOLHA A OPÇÃO DE LISTAGEM:\n" +
                                      "1 - Escolher uma compra por ID;\n" +
                                      "2 - Ver primeira Compra;\n" +
                                      "3 - Ver ultima Compra\n" +
                                      "4 - Ver TODAS as Compras;\n" +
                                      "0 - Sair");
                    int op2 = int.Parse(Console.ReadLine());
                    switch (op2)
                    {
                        case 1:
                            Console.WriteLine("Digite o Id da compra:");
                            AcharCompra(int.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            AcharCompra(compras.First().PegarId());
                            break;
                        case 3:
                            AcharCompra(compras.Last().PegarId());
                            break;
                        case 4:
                            ListarCompra();
                            break;
                        case 0:
                            return;
                        default:
                            break;
                    }    
                    break;
                case 3:
                    Console.WriteLine("EXCLUA UMA COMPRA:");
                    Console.WriteLine("Digite o ID da compra:");
                    ExcluirCompra(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Compra excluida com sucesso!");
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Digite uma opção válida!");
                    break;
            }
            SavarLista();
        }
    }
}
