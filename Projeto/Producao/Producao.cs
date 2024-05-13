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
        float Quantidade;
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
        public Producao(int id, DateOnly dataproducao, string produto, float quantidade)
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
                string qtditensCopia = line.Substring(26, 5).Insert(3,",");
                string data = dataCopia.Substring(0, 2) + "/" + dataCopia.Substring(2, 2) + "/" + dataCopia.Substring(4, 4);
                producaos.Add(new Producao(int.Parse(idCopia), DateOnly.Parse(data), codprodutoCopia, float.Parse(qtditensCopia)));
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
        }
        public void LocalizarProducao(ItemProducao IP)
        {
            int idProducao = 0;
            List<Producao> copia = CopiarArquivo();
            try
            {
                Console.WriteLine("Digite o ID da produção que deseja localizar");
                idProducao = int.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Tipo digitado invalído!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return;
            }
            bool existe = false;
            foreach (var objeto in copia)
            {
                if (objeto.GetId() == idProducao)
                {
                    Console.WriteLine(objeto.ToString());
                    existe = true;
                }
            }
            if (existe == true)
            {
                IP.LocalizarItemProducao(idProducao);
            }
            else
            {
                Console.WriteLine("Produção não localizada na base de dados!");
            }

        }
        public void RemoverProducao()
        {
            int idProducao = 0;
            List<Producao> producaoRemover;
            producaoRemover = CopiarArquivo();
            try
            {
                Console.WriteLine("Digite o Id da produção que deseja remover: ");
                idProducao = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Erro! Valor inválido.");
                return;
            }
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
                salvarArquivo = $"{objeto.Id.ToString().PadLeft(5, '0')}{objeto.DataProducao.ToString("ddMMyyyy")}{objeto.Produto}{objeto.Quantidade.ToString("000.00").Remove(3,1)}";
                sw.WriteLine(salvarArquivo);
                
            } sw.Close();
        }
        public float RetornarQuantidadeProducao()
        {
            float quantidadeProduto = 0 ;
            do
            {
                try
                {
                    Console.WriteLine("Digite a quantidade do produto (Maximo de 999,99");
                    quantidadeProduto = float.Parse(Console.ReadLine());

                    if (quantidadeProduto <= 0 || quantidadeProduto > 999.99)
                    {
                        Console.WriteLine("Quantidade inválida!");

                    }
                }
                catch
                {
                    Console.WriteLine("ERRO! Por favor digite um valor válido!");
                }

            
            } while (quantidadeProduto <= 0 || quantidadeProduto > 999.99);
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

        public void MenuNavegacao()
        {
            Console.WriteLine("==============================");
            Console.WriteLine(">>>>> MENU NAVEGACAO <<<<<");
            Console.WriteLine("[1] Navegar para o primeiro");
            Console.WriteLine("[2] Navegar para o ultimo");
            Console.WriteLine("[3] Navegar para o próximo");
            Console.WriteLine("[4] Navegar para o anterior");
            Console.WriteLine("[5] Sair");
            Console.WriteLine("==============================");


        }
        public void NavegarProducao()
        {
            int indiceAtual = 0;
            int opcao = 0;
            List<Producao> producaos = CopiarArquivo();
            do
            {
                MenuNavegacao();
                try
                {

                Console.WriteLine("Digite a opção:");
                opcao = int.Parse(Console.ReadLine());
                }
                catch
                {

                    Console.WriteLine("Erro! Valor digitado incorreto.");
                    return;
                }
                switch (opcao)
                {
                    case 1:
                       
                        Console.WriteLine(producaos.First().ToString());
                        break;
                    case 2:
                        Console.WriteLine(producaos.Last().ToString()) ;
                        break;
                    case 3:

                        indiceAtual = (indiceAtual + 1) % producaos.Count;
                        Console.WriteLine(producaos[indiceAtual].ToString());
                        break;
                    case 4:
                        indiceAtual = (indiceAtual - 1) % producaos.Count;
                        Console.WriteLine(producaos[indiceAtual].ToString());
                        break;
                     
                }
                Console.WriteLine("Pressione enter para continuar");
                Console.ReadLine();
                Console.Clear();

            } while (opcao != 5);
        }
        public override string? ToString()
        {
            return "Id da produção: " + this.Id + "\nData da produção: "  + this.DataProducao + "\nCodigo do produto: " + this.Produto + "\nQuantidade: " + this.Quantidade;
        } 
    }
}
