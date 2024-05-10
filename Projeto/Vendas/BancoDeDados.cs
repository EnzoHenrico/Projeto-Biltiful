using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Vendas
{
    public class ManipularArquivos
    {
        public void VerificarArquivo(string path, string file)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                if (!File.Exists(path + file))
                {
                    File.Delete(path + file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ImprimirLinhas(string path, string file)
        {
            VerificarArquivo(path, file);

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

        public string? BuscarLinha(string path, string file, string texto)
        {

            VerificarArquivo(path, file);

            StreamReader sr = new StreamReader(path + file);
            string linha;

            {
                while ((linha = sr.ReadLine()) != null)
                {
                    if (linha.Contains(texto))
                    {
                        return linha;
                    }
                }
            }

            sr.Close();
            return null;
        }

        public void InserirLinha(string path, string file, string texto)
        {
            VerificarArquivo(path, file);
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
    }
}
