using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class Producao
    {
        int Id;
        DateOnly DataProducao;
        string Produto;
        int Quantidade;
        string Diretorio = @"C:\Biltiful\";
        string ArquivoProdutos = "Cosmetico.dat";
        string ArquivoProducao = "Producao.dat";
        EditorArquivo manipularArquivoProdutos;
        EditorArquivo manipularArquivoProducao;
        public Producao()
        {
             this.manipularArquivoProdutos = new EditorArquivo(Diretorio, ArquivoProdutos);
             this.manipularArquivoProducao = new EditorArquivo(Diretorio, ArquivoProducao);
        }
        public Producao(int id, DateOnly dataproducao, string produto, int quantidade)
        {
            this.Id = id;
            this.DataProducao = dataproducao;
            this.Produto = produto;
            this.Quantidade = quantidade;
        }

       public  List<Producao> CopiarArquivo()
        {
            List<Producao> producaos = new List<Producao>();
            foreach (var line in manipularArquivoProducao.Ler()) 
            {
                if (line != "")
                {
                string idCopia = line.Substring(0, 5);
                string dataCopia = line.Substring(5, 8);
                string codprodutoCopia = line.Substring(13, 13);
                string qtditensCopia = line.Substring(26, 5);
                string data = dataCopia.Substring(0, 2) + "/" + dataCopia.Substring(2, 2) + "/" + dataCopia.Substring(4, 4);
                producaos.Add(new Producao(int.Parse(idCopia), DateOnly.Parse(data), codprodutoCopia, int.Parse(qtditensCopia)));
                }
            }
            return producaos;
        }
        
        public int GetId()
        {
            return this.Id;
        }
        public bool VerificarProduto(string idComestico)
        {
            bool verificacaoCosmeticoExiste = false;
            foreach (var line in File.ReadLines(Diretorio + ArquivoProdutos))
            {
                string id = line.Substring(0, 13);
                if (id == idComestico)
                {
                    string name = line.Substring(13, 20);
                    verificacaoCosmeticoExiste =  true;
                }
            }
            return verificacaoCosmeticoExiste;
        }
        public int GerarIdProducao(List<Producao> listaCopiada)
        {
            if (listaCopiada.Count == 0)
            {
                return 1;
            }
            else
            {
                Producao ultimaLinha = listaCopiada.Last();
                return ultimaLinha.Id + 1;
            }
            //string ultimaLinha = null;
            //int novoId = 1;
            //StreamReader sr = new StreamReader(Diretorio + ArquivoProducao);
            //while (!sr.EndOfStream)
            //{
            //    ultimaLinha = sr.ReadLine();
            //}
            //if(ultimaLinha != null && ultimaLinha != "99999")
            //{
            //    int ultimoId = int.Parse(ultimaLinha.Substring(0, 4));

            //    if (ultimoId < 99999)
            //    {
            //        novoId = ultimoId + 1;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Não é possível gerar mais IDs. Limite de 99999 alcançado.");
            //    }

            //}
            //return novoId;

        }
        public void LocalizarProducao(ItemProducao IP)
        {
            List<Producao> copia = CopiarArquivo();
            Console.WriteLine("Digite o ID da produção que deseja localizar");
            int idProducao = int.Parse(Console.ReadLine());
            foreach (var objeto in copia)
            {
                if (objeto.GetId() == idProducao)
                {
                    Console.WriteLine(objeto.ToString());
                }
            }
            IP.LocalizarItemProducao(idProducao);

        }

        public void RemoverProducao()
        {
            List<Producao> producaoRemover;
            producaoRemover = CopiarArquivo();
            Console.WriteLine("Digite o Id da produção que deseja remover: ");
            int idProducao = int.Parse(Console.ReadLine());
            bool existe = false;
            foreach (Producao item in producaoRemover)
            {
                if (item.Id == idProducao)
                {
                    existe = true;
                }
            }
            if (existe)
            {
                producaoRemover.RemoveAll(item => item.Id == idProducao);
                FormatarProArquivo(producaoRemover);
                ItemProducao ip = new ItemProducao();
                ip.RemoverItemProducao(idProducao);
                Console.WriteLine("Removido com sucesso");
            }
            else
            {
                Console.WriteLine("O Id fornecido não existe no arquivo");
            }



        }
        public void FormatarProArquivo(List<Producao> producaoLista)
        {
            StreamWriter sw = new StreamWriter(Diretorio + ArquivoProducao);
            foreach (var objeto in producaoLista)
            {
                string salvarArquivo = "";
                salvarArquivo = $"{objeto.Id.ToString().PadLeft(5, '0')}{objeto.DataProducao.ToString("ddMMyyyy")}{objeto.Produto.ToString().PadRight(13, ' ')}{objeto.Quantidade.ToString().PadLeft(5, '0')}";
                sw.WriteLine(salvarArquivo);
                
            } sw.Close();
        }
        public int RetornarQuantidadeProducao()
        {
            int quantidadeProduto = 0 ;
            do
            {
                try
                {
                    Console.WriteLine("Informe a quantidade do produto a ser produzido (Máximo de 999 unidades):");
                    quantidadeProduto = int.Parse(Console.ReadLine());

                    if (quantidadeProduto > 0 && quantidadeProduto < 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida. Por favor, insira um valor entre 0 e 999.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: entrada inválida. Por favor, insira um número inteiro.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Deseja tentar novamente? (S/N)");
                string resposta = Console.ReadLine().ToUpper();
                if (resposta[0] != 'S')
                {
                    break;
                }
            } while (true);
            return quantidadeProduto;
        }
        public void CriarProducao(ItemProducao IP)
        {
            string idCosmetico = "";
            bool verificando = false;
            List<ItemProducao> backupArquivoItemProducao = IP.CopiarArquivoItemProducao();
            List<ItemProducao> NovoItemProducao;
            List<Producao> copiaProducao = CopiarArquivo();
            List<Producao> novaProducao = CopiarArquivo();
            do
            {
                try
                {
                    Console.WriteLine("Digite o codigo de barras do cosmético que deseja inciar a produção seguindo a regra de 13 digitos");
                    idCosmetico = Console.ReadLine();
                    verificando = VerificarProduto(idCosmetico);
                    if(verificando == false)
                    {
                        Console.WriteLine("Cosmético não encontrado na base da dados.");
                    }
                }
                catch
                {
                    Console.WriteLine("ERRO! Por favor digite um Codigo de Barras válido.");
                }
            } while (VerificarProduto(idCosmetico) == false);
            int id = GerarIdProducao(copiaProducao);
            novaProducao.Add(new(id, DateOnly.FromDateTime(DateTime.Now), idCosmetico, RetornarQuantidadeProducao()));
            NovoItemProducao = IP.CriarItemProducao(id.ToString().PadLeft(5, '0'));
            if (backupArquivoItemProducao.Count() < NovoItemProducao.Count && copiaProducao.Count < novaProducao.Count())
            {
                IP.FormatarProArquivo(NovoItemProducao);
                FormatarProArquivo(novaProducao);
                Console.WriteLine("Produção registrada com sucesso");
            }
            else
            {
                Console.WriteLine("Não foi possivel registrar a produção");
            }
        }
        public override string? ToString()
        {
            return "Id da produção: " + this.Id + "\nData da produção: "  + this.DataProducao + "\nCodigo do produto: " + this.Produto + "\nQuantidade: " + this.Quantidade;
        } 
    }
}
