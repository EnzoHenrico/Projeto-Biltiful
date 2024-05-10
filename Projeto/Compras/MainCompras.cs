using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Compras
{
    public class MainCompras
    {
        static List<Compra> compras = new List<Compra>();
        static string pasta = @"C:\Biltiful\";
        static string arquivo = "Compra.dat";
        static string arquivoItem = "itemCompra.dat";
        static int identificadorCompra = 0;
        static void ChecarExistenciaArquivo()
        {
            if (!File.Exists(pasta + arquivo))
                File.Create(pasta + arquivo);
        }
        #region Compra        
        static List<Compra> CarregarLista()
        {
            List<Compra> listaCarregada = new List<Compra>();
            foreach (var linha in File.ReadAllLines(pasta + arquivo))
                listaCarregada.Add(PegarCompra(linha));
            return listaCarregada;
        }
        static Compra PegarCompra(string line)
        {
            char[] data = new char[34];
            string id = null;
            string dataCompra = null;
            string fornecedor = null;
            string valorTotal = null;
            int i = 0;
            for (int j = 0; j < 5; j++)
            {
                id += data[i];
                i++;
            }
            for (int j = 0; j < 8; j++)
            {
                dataCompra += data[i];
                i++;
            }
            for (int j = 0; j < 14; j++)
            {
                fornecedor += data[i];
                i++;
            }
            for (int j = 0; j < 8; j++)
            {
                valorTotal += data[i];
                i++;
            }
            return new Compra(int.Parse(id), DateOnly.Parse(dataCompra), fornecedor, int.Parse(valorTotal));
        }
        static void SavarLista()
        {
            StreamWriter sw = new StreamWriter(pasta + arquivo);
            foreach (Compra item in compras)
                sw.WriteLine(item.ToString());
            sw.Close();
        }
        static bool VerificarFornecedor(string cnpj)
        {
            string arquivoFornecedor = "Fornecedor.dat";
            string arquivoBloqueado = "Bloqueado.dat";
            bool existe = false;
            foreach (var line in File.ReadAllLines(pasta + arquivoFornecedor))
            {
                if (cnpj == line)
                    existe = true;
                foreach (var item in File.ReadLines(pasta + arquivoBloqueado))
                {
                    if (cnpj == item)
                        existe = false;
                }
            }
            return existe;
        }
        static ItemCompra CadastroItem()
        {
            int identificadorItemCompra = identificadorCompra, materiaPrima, quantidade, valorUnitario, totalItem;
            DateOnly dataCompra;

            do
            {
                materiaPrima = int.Parse(Console.ReadLine());
            } while (materiaPrima > 99999);
            do
            {
                quantidade = int.Parse(Console.ReadLine());
            } while (quantidade > 99999);
            do
            {
                valorUnitario = int.Parse(Console.ReadLine());
            } while (valorUnitario > 99999);
            do
            {
                totalItem = valorUnitario * quantidade;
            } while (totalItem > 999999);
            ItemCompra itemCompra = new ItemCompra(identificadorItemCompra, dataCompra, materiaPrima, quantidade, valorUnitario, totalItem);
            return itemCompra;
        }
        static void CadastroCompra()
        {
            identificadorCompra++;
            int id = identificadorCompra, tamanho = 0, op = 0, ValorTotal = 0;
            Console.WriteLine("Digite o CNPJ do Fornecedor:");
            string fornecedor;
            DateOnly dataCompra = new DateOnly();
            do
            {
                fornecedor = Console.ReadLine();
                if (!VerificarFornecedor(fornecedor))
                    Console.WriteLine("Fornecedor não existe!\nDigite o CNPJ novamente:");
            } while (!VerificarFornecedor(fornecedor));
            do
            {
                List<ItemCompra> itensCompra = new List<ItemCompra>();
                ItemCompra item = CadastroItem();
                ValorTotal += item.PegarTotalItem();
                tamanho++;
            } while (tamanho > 0 && (tamanho < 3 || op != 0));

            Compra criarCompra = new Compra(id, dataCompra, fornecedor, ValorTotal);
        }
        #endregion

        #region ItemCompra        
        static List<Compra> CarregarListaItemCompra()
        {
            List<Compra> listaCarregada = new List<Compra>();
            foreach (var linha in File.ReadAllLines(pasta + arquivoItem))
                listaCarregada.Add(PegarItemCompra(linha));
            return listaCarregada;
        }
        //static Compra PegarItemCompra(string line)
        //{
        //    char[] data = new char[39];
        //    string id = null;
        //    string dataCompra = null;
        //    string materiaPrima = null;
        //    string quantidade = null;
        //    string valorUnitario = null;
        //    string totalItem = null;
        //    int i = 0;
        //    for (int j = 0; j < 10; j++)
        //    {
        //        id += data[i];
        //        i++;
        //    }
        //    for (int j = 0; j < 18; j++)
        //    {
        //        dataCompra += data[i];
        //        i++;
        //    }
        //    for (int j = 0; j < 22; j++)
        //    {
        //        materiaPrima += data[i];
        //        i++;
        //    }
        //    for (int j = 0; j < 27; j++)
        //    {
        //        quantidade += data[i];
        //        i++;
        //    }
        //    for (int j = 0; j < 32; j++)
        //    {
        //        valorUnitario += data[i];
        //        i++;
        //    }
        //    for (int j = 0; j < 38; j++)
        //    {
        //        totalItem += data[i];
        //        i++;
        //    }
        //    return new ItemCompra(int.Parse(id), DateOnly.Parse(dataCompra), int.Parse(materiaPrima), int.Parse(quantidade), int.Parse(valorUnitario), int.Parse(totalItem));
        //}
        //static void SavarLista()
        //{
        //    StreamWriter sw = new StreamWriter(pasta + arquivo);
        //    foreach (Compra item in compras)
        //        sw.WriteLine(item.ToString());
        //    sw.Close();
        //}
        //static bool VerificarFornecedor(string cnpj)
        //{
        //    string arquivoFornecedor = "Fornecedor.dat";
        //    string arquivoBloqueado = "Bloqueado.dat";
        //    bool existe = false;
        //    foreach (var line in File.ReadAllLines(pasta + arquivoFornecedor))
        //    {
        //        if (cnpj == line)
        //            existe = true;
        //        foreach (var item in File.ReadLines(pasta + arquivoBloqueado))
        //        {
        //            if (cnpj == item)
        //                existe = false;
        //        }
        //    }
        //    return existe;
        //}
        //static ItemCompra CadastroItem()
        //{
        //    int identificadorItemCompra = identificadorCompra, materiaPrima, quantidade, valorUnitario, totalItem;
        //    DateOnly dataCompra;

        //    do
        //    {
        //        materiaPrima = int.Parse(Console.ReadLine());
        //    } while (materiaPrima > 99999);
        //    do
        //    {
        //        quantidade = int.Parse(Console.ReadLine());
        //    } while (quantidade > 99999);
        //    do
        //    {
        //        valorUnitario = int.Parse(Console.ReadLine());
        //    } while (valorUnitario > 99999);
        //    do
        //    {
        //        totalItem = valorUnitario * quantidade;
        //    } while (totalItem > 999999);
        //    ItemCompra itemCompra = new ItemCompra(identificadorItemCompra, dataCompra, materiaPrima, quantidade, valorUnitario, totalItem);
        //    return itemCompra;
        //}
        //static void CadastroCompra()
        //{
        //    identificadorCompra++;
        //    int id = identificadorCompra, tamanho = 0, op = 0, ValorTotal = 0;
        //    Console.WriteLine("Digite o CNPJ do Fornecedor:");
        //    string fornecedor;
        //    DateOnly dataCompra = new DateOnly();
        //    do
        //    {
        //        fornecedor = Console.ReadLine();
        //        if (!VerificarFornecedor(fornecedor))
        //            Console.WriteLine("Fornecedor não existe!\nDigite o CNPJ novamente:");
        //    } while (!VerificarFornecedor(fornecedor));
        //    do
        //    {
        //        List<ItemCompra> itensCompra = new List<ItemCompra>();
        //        ItemCompra item = CadastroItem();
        //        ValorTotal += item.PegarTotalItem();
        //        tamanho++;
        //    } while (tamanho > 0 && (tamanho < 3 || op != 0));

        //    Compra criarCompra = new Compra(id, dataCompra, fornecedor, ValorTotal);
        //}
        #endregion

        public static void Acesso()
        {
            ChecarExistenciaArquivo();
            Console.WriteLine("Digite a opção desejada:\n");
            int op = 0;
            switch (op)
            {
                case 1:
                    CadastroCompra();
                    break;
                case 2:

                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}
