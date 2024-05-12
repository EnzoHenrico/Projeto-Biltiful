namespace Projeto
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

                // Fornecedor.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoFornecedor))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoFornecedor);
                }

                // Produto.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProduto))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProduto);
                }

                // MAteria.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoMPrima))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoMPrima);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
