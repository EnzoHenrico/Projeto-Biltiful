using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class ItemProducao
    {
        string Id;
        DateOnly DataProducao;
        string MateriaPrima;
        double QuantidadeMateriaPrima;
        string Diretorio = @"C:\Biltiful\";
        string ArquivoMateria = "Materia.dat";
        string ArquivoItemProducao = "ItemProducao.dat";
        EditorArquivo ManipularArquivoMateria;
        EditorArquivo ManipularArquivoItemProducao;
        public ItemProducao()
        {
            //Chamo o construtor de Editor Arquivo pra criar os arquivos se não existirem
            this.ManipularArquivoMateria = new EditorArquivo(Diretorio, ArquivoMateria);
            this.ManipularArquivoItemProducao = new EditorArquivo(Diretorio, ArquivoItemProducao);
        }

        public ItemProducao(string id, DateOnly dataProducao, string materiaPrima,double quantidadeMateriaPrima)
        {
            this.Id = id;
            this.DataProducao = dataProducao;
            this.MateriaPrima = materiaPrima;
            this.QuantidadeMateriaPrima = quantidadeMateriaPrima;
        }

        public string VerificarMateriaExiste(int codigoMP)
        {
            string nomeMateriaPrima = "";
            foreach(var line in ManipularArquivoMateria.Ler())
            {
                if (line.Substring(2, 4) == codigoMP.ToString().PadLeft(4,'0'))
                {
                    nomeMateriaPrima = line.Substring(6, 20);
                    break;
                }
            }
            return nomeMateriaPrima;
        }
        public List<ItemProducao> CopiarArquivoItemProducao()
        {
            List<ItemProducao> itensProducao = new List<ItemProducao>();
            foreach (var line in ManipularArquivoItemProducao.Ler())
            {
                if (line != "")
                {
                    string copiarIdProducao = line.Substring(0, 5);
                    string copiarDataProducao = line.Substring(5, 8);
                    string copiarIdMp = line.Substring(13, 6);
                    string copiarQtdMp = line.Substring(18, 5).Insert(3, ",");
                    string data = copiarDataProducao.Substring(0, 2) + "/" + copiarDataProducao.Substring(2, 2) + "/" + copiarDataProducao.Substring(4, 4);
                    itensProducao.Add(new ItemProducao(copiarIdProducao, DateOnly.Parse(data), copiarIdMp, double.Parse(copiarQtdMp)));
                }
            }
            return itensProducao;
        }
    }
}
