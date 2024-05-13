using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Vendas.Manipuladores
{
    internal class ManipuladorArquivosVenda
    {
        static public void ImprimirLinhas(string path, string file)
        {
            try
            {
                StreamReader sr = new StreamReader(path + file);
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("O arquivo não pôde ser lido:");
                Console.WriteLine(e.Message);
            }
        }

        static public List<string>? BuscarLinhas(string path, string file, string texto)
        {
            StreamReader sr = new (path + file);
            string linha;
            List<string> linhasEncontradas = new ();

            while ((linha = sr.ReadLine()) != null)
            {
                if (linha.Contains(texto))
                {
                    linhasEncontradas.Add(linha);
                }
            }

            sr.Close();

            return linhasEncontradas.Count > 0 ? linhasEncontradas : null;
        }

        static public void InserirLinha(string path, string file, string texto)
        {
            StreamWriter sr = new StreamWriter(path + file);
            try
            {
                sr.WriteLine(texto);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
            sr.Close();
        }

        static public void ExcluirVendaPorId(string path, string fileVenda, string fileItemVenda, string idVenda)
        {
            string linha;
            string linhaExcluida = null;
            List<string> linhasRestantesVenda = new List<string>();
            List<string> linhasRestantesItemVenda = new List<string>();
            int contador = 0;

            StreamReader srVenda = new StreamReader(path + fileVenda);
            while ((linha = srVenda.ReadLine()) != null)
            {
                if (linha.StartsWith(idVenda))
                {
                    linhaExcluida = linha;
                }
                else
                {
                    linhasRestantesVenda.Add(linha);
                }
            }
            srVenda.Close();

            StreamReader srItemVenda = new StreamReader(path + fileItemVenda);
            while ((linha = srItemVenda.ReadLine()) != null)
            {
                if (linha.StartsWith(idVenda))
                {
                    contador++;
                }
                else
                {
                    linhasRestantesItemVenda.Add(linha);
                }
            }
            srItemVenda.Close();

            StreamWriter swVenda = new StreamWriter(path + fileVenda);
            foreach (string l in linhasRestantesVenda)
            {
                swVenda.WriteLine(l);
            }
            swVenda.Close();

            StreamWriter swItemVenda = new StreamWriter(path + fileItemVenda);
            foreach (string l in linhasRestantesItemVenda)
            {
                swItemVenda.WriteLine(l);
            }
            swItemVenda.Close();

            Console.WriteLine($"Linha excluida:\n" +
                $"{linhaExcluida}\n" +
                $"Quantidade de itens removidos no arquivo ItemVenda.dat: {contador}");
            Thread.Sleep(5000);
        }
    }
}
