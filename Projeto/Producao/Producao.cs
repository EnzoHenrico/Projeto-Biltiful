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
        string DataProducao;
        string Produto;
        int Quantidade;
        string Diretorio = @"C:\Biltiful\";
        string ArquivoProdutos = "Cosmetico.dat";
        string ArquivoProducao = "Producao.dat";
        EditorArquivo manipularArquivoProdutos;
        EditorArquivo manipularArquivoProducao;
        public Producao()
        {
            EditorArquivo manipularArquivoProdutos = new EditorArquivo(Diretorio,ArquivoProdutos);
            EditorArquivo manipularArquivosProducao = new EditorArquivo(Diretorio, ArquivoProducao);
            
        }


        public Producao(int id, string dataproducao, string produto, int quantidade)
        {
            id = id;
            string DataProducao = dataproducao;
            produto = produto;
            quantidade = quantidade;
        }

        public bool VerificarProduto(string idComestico)
        {
            bool verificacaoCosmeticoExiste = false;
            foreach (var line in File.ReadLines(Diretorio + ArquivoProdutos))
            {
                string id = line.Substring(0, 12);
                if (id == idComestico)
                {
                    verificacaoCosmeticoExiste =  true;
                }
                //Fazer verificao com status
            }
            return verificacaoCosmeticoExiste;
        }
        public int GerarIdProducao()
        {
            string ultimaLinha = null;
            int novoId = 1;
            StreamReader sr = new StreamReader(Diretorio + ArquivoProducao);
            while (!sr.EndOfStream)
            {
                ultimaLinha = sr.ReadLine();
            }
            if(ultimaLinha != null && ultimaLinha != "99999")
            {
                int ultimoId = int.Parse(ultimaLinha.Substring(0, 4));

                if (ultimoId < 99999)
                {
                    novoId = ultimoId + 1;
                }
                else
                {
                    Console.WriteLine("Não é possível gerar mais IDs. Limite de 99999 alcançado.");
                }

            }
            return novoId;
            
        }
        //public List<Producao> CopiarArquivo()
        //{
      
        //    List<Producao> producaos = new List<Producao>();
        //    string[] coletarDados = new string[4];
        //    foreach(var line in File.ReadAllLines(Diretorio + ArquivoProducao))
        //    {
        //        coletarDados[0] = line.Substring(0,5);
        //        coletarDados[1] = line.Substring(5,8);
        //        coletarDados[2] = line.Substring(13,13);
        //        coletarDados[3] = line.Substring(26,5);
        //        string data = coletarDados[1].Substring(0, 2) + "/" + coletarDados[1].Substring(2,2) + "/" + coletarDados[1].Substring(4,4);
        //        producaos.Add(new(int.Parse(coletarDados[0]), data, coletarDados[2], int.Parse(coletarDados[3])));
        //    }
        //    return producaos;
        //}
        public void CriarProducao()
        {

            Console.WriteLine("Digite o id do cosmetico que deseja inciar a produção seguindo a regra de 13 digitos");
            string idCosmetico = Console.ReadLine();
            bool verificar = VerificarProduto(idCosmetico);
            Console.WriteLine("Informe a quantidade do produto a ser produzido");
            int quantidade = int.Parse(Console.ReadLine());

        }
        public override string? ToString()
        {
            return this.Id + this.DataProducao + this.Produto + this.Quantidade;
        } 
    }
}
