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

                // Cosmetico.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProduto))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProduto);
                }

                // Materia.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoMateria))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoMateria);
                }

                // Risco.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoRisco))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoRisco);
                }

                // BLoqueado.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoBloqueado))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoBloqueado);
                }

                // Venda.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoVenda))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoVenda);
                }

                // ItemVenda.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoItemVenda))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoItemVenda);
                }

                // Compra.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoCompra))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoCompra);
                }

                // ItemCompra.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoItemCompra))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoItemCompra);
                }

                // Producao.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProducao))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoProducao);
                }

                // ItemProducao.dat
                if (!File.Exists(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoItemProducao))
                {
                    File.Create(DicionarioStrings.Diretorio + DicionarioStrings.ArquivoItemProducao);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
