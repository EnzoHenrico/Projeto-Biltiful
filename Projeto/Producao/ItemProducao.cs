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
                    itensProducao.Add(new ItemProducao(copiarIdProducao, DateOnly.Parse(data), copiarIdMp, float.Parse(copiarQtdMp)));
                }
            }
            return itensProducao;
        }
        public void FormatarProArquivo(List<ItemProducao> itensProducao)
        {
            StreamWriter sw = new StreamWriter(Diretorio + ArquivoItemProducao);
            foreach (var objeto in itensProducao)
            {
                string salvarArquivo = "";
                //string idFormatada = objeto.Id.PadLeft(5, '0');
                //string DataFormatada = objeto.DataProducao.ToString("ddMMyyyy");
                //string MPFormatada = "MP" + objeto.MateriaPrima.ToString().PadLeft(4,'0');
                ////salvarArquivo += objeto.Id.PadLeft(5, '0');
                ////salvarArquivo += objeto.DataProducao.ToString("ddMMyyyy");
                //salvarArquivo += "MP" + objeto.MateriaPrima.ToString().PadLeft(4, '0').Substring(2, 4);
                //salvarArquivo += objeto.QuantidadeMateriaPrima.ToString("000.00").Remove(3, 1);
                salvarArquivo = $"{objeto.Id.PadLeft(5, '0')}{objeto.DataProducao.ToString("ddMMyyyy")}{objeto.MateriaPrima}{objeto.QuantidadeMateriaPrima.ToString("000.00").Remove(3, 1)}";
                sw.WriteLine(salvarArquivo);

            }
            sw.Close();
        }
        public bool VerificarMateriaAtiva(string nome)
        {
            bool status = false;
            foreach (var linha in ManipularArquivoMateria.Ler())
            {
                if (linha.Substring(6,20) == nome && linha.Substring(42,1) == "A")
                {
                    status = true;
                }
            }
            return status;
        }

        public ItemProducao[] PedirMateriaPrima(string idProducao)
        {
            int numeroMateriaPrima = 0 ;
            
            do
            {
                try
                {
                    Console.WriteLine("Quantas matérias primas são necessárias?");
                    numeroMateriaPrima = int.Parse(Console.ReadLine());
                    if(numeroMateriaPrima < 2)
                    {
                        Console.WriteLine("O número de materias primas deve ser pelo menos 2. Tente novamente");
                    }
                }
                catch
                {
                    Console.WriteLine("ERRO! Por favor digite um valor válido");
                }

            } while (numeroMateriaPrima < 2);
            ItemProducao[] backup = new ItemProducao[numeroMateriaPrima];
            int contador = 0;
            while(contador <  numeroMateriaPrima) 
            {
                int id = 0 ;
                Console.WriteLine("Digite o ID da materia prima");
                try
                {
                    id = int.Parse(Console.ReadLine());
                } catch
                {
                    Console.WriteLine("ERRO! Por favor digite um valor válido para ID");
                }
                if (VerificarMateriaExiste(id) != "")
                {
                    if (VerificarMateriaAtiva(VerificarMateriaExiste(id)))
                    {
                        string nome = getNomeMP(id);
                        Console.WriteLine($"Digite a quantidade de {nome} que usara.  ");
                        double quantidade = float.Parse(Console.ReadLine());
                        ItemProducao item = new(idProducao, DateOnly.FromDateTime(DateTime.Now), "MP" + id.ToString().PadLeft(4, '0'), quantidade);
                        backup[contador] = item;
                        contador++;
                    }
                    else
                    {
                        Console.WriteLine("Matéria prima inativa.");
                    }
                }
                else
                {
                    Console.WriteLine("Materia prima não encontrada na base de dados.");
                }
            }
            return backup;
        }
        public string getNomeMP(int idProducao)
        {
            string nome = "";
            foreach (var linha in ManipularArquivoMateria.Ler())
            {
                if(linha.Substring(2,4) == idProducao.ToString().PadLeft(4,'0'))
                {
                    nome =  linha.Substring(6, 20);
                }
            }
            return nome;
        }
        public void LocalizarItemProducao(int idProducao)
        {
            foreach(var linha in ManipularArquivoItemProducao.Ler())
            {
                if (linha.Substring(0, 5) == idProducao.ToString().PadLeft(5,'0'))
                {
                    Console.WriteLine("Materia prima utilizada : " + linha.Substring();
                }

            }
        }
        public List<ItemProducao> CriarItemProducao(string idProducao)
        {
            List<ItemProducao> arquivoCopiado;
            ItemProducao[] objetos = PedirMateriaPrima(idProducao);
            arquivoCopiado = CopiarArquivoItemProducao();
            for (int i = 0; i < objetos.Length; i++)
            {
                arquivoCopiado.Add(objetos[i]);
            }
            return arquivoCopiado;
            
        }

        public void RemoverItemProducao(int idProducao)
        {
            List<ItemProducao> itemRemover;
            itemRemover = CopiarArquivoItemProducao();
           
            bool existe = false;
            foreach(ItemProducao item in itemRemover)
            {
                if (item.Id == idProducao.ToString().PadLeft(5, '0'));
                {
                    existe = true;
                }
            }
            if (existe)
            {
                itemRemover.RemoveAll(item => item.Id == idProducao.ToString().PadLeft(5,'0'));
                FormatarProArquivo(itemRemover);
                Console.WriteLine("Removido com sucesso");
            }
            else
            {
                Console.WriteLine("O id fornecido não existe no arquivo");
            }    
        }

        public override string? ToString()
        {
            return "\nMateria Prima Utilizada: " + this.MateriaPrima + "\nQuantidade Utilizada: " + this.QuantidadeMateriaPrima;
        }
    }
}
