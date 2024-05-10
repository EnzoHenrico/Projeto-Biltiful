using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorArquivos
    {
        static readonly string Diretorio = @"C:\Biutiful\";
        static readonly string ArquivoCliente = "Cliente.dat";

        public static void VerificarArquivosPadrao()
        {
            try
            {
                if (!Directory.Exists(Diretorio))
                {
                    Directory.CreateDirectory(Diretorio);
                }

                if (!File.Exists(Diretorio + ArquivoCliente))
                {
                    File.Create(Diretorio + ArquivoCliente);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
