using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorArquivos
    {
        public static void VerificarArquivosPadrao()
        {
            try
            {
                // Diretorio padrão
                if (!Directory.Exists(DicionarioStrings.Diretorio))
                {
                    Directory.CreateDirectory(DicionarioStrings.Diretorio);
                }

                // Cliente.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoCliente))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoCliente);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
