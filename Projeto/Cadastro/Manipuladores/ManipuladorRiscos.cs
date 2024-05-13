using Projeto.Cadastro.Entradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorRiscos
    {
        private string _diretorio;
        private string _arquivo;
        private List<string> _listaRiscos;

        public ManipuladorRiscos(string diretorio, string arquivo)
        {
            _diretorio = diretorio;
            _arquivo = arquivo;
            _listaRiscos = CarregarArquivoRiscos();
        }

        private List<string> CarregarArquivoRiscos()
        {
            List<string> riscos = new();
            try
            {
                var reader = new StreamReader(_diretorio + _arquivo);

                string? data = "";

                while (data != null)
                {
                    data = reader.ReadLine();

                    if (data != null)
                    {
                        riscos.Add(data);
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return riscos;
        }

        public bool EstaNaLista(string identficador)
        {
            return _listaRiscos.Find(risco => risco == identficador) != null;
        }

        public void Cadastrar()
        {
            var novo = EntradaInadimplente.CadastrarRisco();
            _listaRiscos.Add(novo);
            Salvar();
        }

        public void Remover()
        {
            EntradaInadimplente.RemoverRiscoDaLista();
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                var writer = new StreamWriter(_diretorio + _arquivo);
                foreach (var identificador in _listaRiscos)
                {
                    writer.WriteLine(identificador.Replace(".", "").Replace("-", ""));
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public void ImprimirTodosRiscos()
        {
            if (!_listaRiscos.Any())
            {
                Console.WriteLine("\nNão há clientes inadimplentes\n");
                return;
            }

            Console.Clear();
            Console.WriteLine("CPFs Bloqueados: \n");
            foreach (var bloqueado in _listaRiscos)
            {
                Console.WriteLine(bloqueado + "\n");
            }
        }
    }
}
