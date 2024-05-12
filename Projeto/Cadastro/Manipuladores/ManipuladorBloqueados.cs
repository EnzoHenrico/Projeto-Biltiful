using Projeto.Cadastro.Entidades;
using Projeto.Cadastro.Entradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorBloqueados
    {
        private string _diretorio;
        private string _arquivo;
        private List<string> _listaBloqueados;

        public ManipuladorBloqueados(string diretorio, string arquivo)
        {
            _diretorio = diretorio;
            _arquivo = arquivo;
            _listaBloqueados = CarregarArquivoBloqueados();
        }

        private List<string> CarregarArquivoBloqueados()
        {
            List<string> bloqueados = new();
            try
            {
                var reader = new StreamReader(_diretorio + _arquivo);

                string? data = "";

                while (data != null)
                {
                    data = reader.ReadLine();

                    if (data != null)
                    {
                        bloqueados.Add(data);
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return bloqueados;
        }

        public bool EstaNaLista(string identficador)
        {
            return _listaBloqueados.Find(bloqueado => bloqueado == identficador) != null;
        }

        public void Cadastrar()
        {
            var novo = EntradaInadimplente.CadastrarBloqueado();
            _listaBloqueados.Add(novo);
            Salvar();
        }

        public void Remover()
        {
            EntradaInadimplente.RemoverBloqueadoDaLista();
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                var writer = new StreamWriter(_diretorio + _arquivo);
                foreach (var identificador in _listaBloqueados)
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

        public void ImprimirTodosBloqueados()
        {
            if (!_listaBloqueados.Any())
            {
                Console.WriteLine("\nNão há fornecedores inadimplentes\n");
                return;
            }

            Console.Clear();
            Console.WriteLine("CNPJs Bloqueados: \n");
            foreach (var bloqueado in _listaBloqueados)
            {
                Console.WriteLine(bloqueado + "\n");
            }
        }
    }
}
