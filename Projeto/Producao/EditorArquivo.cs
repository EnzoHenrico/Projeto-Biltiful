using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class EditorArquivo
    {
        public string CaminhoDiretorio { get; set; }
        public string CaminhoArquivo { get; set; }
        public EditorArquivo(string c, string a)
        {
            CaminhoDiretorio = c;
            CaminhoArquivo = a;
            if (!Directory.Exists(CaminhoDiretorio))
                Directory.CreateDirectory(CaminhoDiretorio);
            if (!File.Exists(CaminhoDiretorio + CaminhoArquivo))
            {
                var aux = File.Create(CaminhoDiretorio + CaminhoArquivo);
                aux.Close();
            }
        }
        public List<string> Ler()
        {
            List<string> conteudo = new();
            foreach (string line in File.ReadAllLines(CaminhoDiretorio + CaminhoArquivo))
                conteudo.Add(line);
            return conteudo;
        }
        public void Escrever(List<string> conteudo)
        {
            File.WriteAllLines(CaminhoDiretorio + CaminhoArquivo, conteudo);
        }
    }
}

