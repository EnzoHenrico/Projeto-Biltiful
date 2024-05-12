using Projeto.Cadastro.Entidades;
using Projeto.Cadastro.Entradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorMPrima
    {
        private string _diretorio;
        private string _arquivo;
        private List<MPrima> _listaMPrima;

        public ManipuladorMPrima(string diretorio, string arquivo)
        {
            _diretorio = diretorio;
            _arquivo = arquivo;
            _listaMPrima = CarregarArquivoCliente();
        }

        private List<MPrima> CarregarArquivoCliente()
        {
            List<MPrima> materia = new();
            try
            {
                var reader = new StreamReader(_diretorio + _arquivo);

                string? line = "";

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        materia.Add(new MPrima(line));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return materia;
        }

        public MPrima? BuscarPorId(string id)
        {
            return _listaMPrima.Find(materia => materia.Id == id);
        }

        public int GerarNovoId()
        {
            if (!_listaMPrima.Any())
            {
                return 1;
            }
            
            MPrima ultimoRegistro = _listaMPrima.Last();
            return int.Parse(ultimoRegistro.Id.Substring(2)) + 1;
        }

        public void Cadastrar()
        {
            var novaMateria = EntradaMPrima.CadastrarMateria(GerarNovoId());
            _listaMPrima.Add(novaMateria);
            Salvar();
        }

        public void Editar()
        {
            MPrima? materia = null;
            int opcao = 0;
            do
            {
                Console.Write("Código da Materia Prima que deseja alterar: ");
                materia = BuscarPorId(Console.ReadLine());

                if (materia == null)
                {
                    Console.WriteLine("\nCódigo não encontrado, selecione uma opção:");
                    Console.WriteLine("0 - Sair \n1 - Tentar novamente\n");
                    opcao = int.Parse(Console.ReadLine());
                }
                else
                {
                    EntradaMPrima.AlterarMateriaPrima(materia);
                }
            } while (opcao > 0);

            Salvar();
        }

        public void Salvar()
        {
            try
            {
                var writer = new StreamWriter(_diretorio + _arquivo);
                foreach (var materia in _listaMPrima)
                {
                    writer.WriteLine(materia.FormatarParaArquivo());
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public void ImprimirTodasMaterias()
        {
            if (!_listaMPrima.Any())
            {
                Console.WriteLine("\nNão há itens cadastrados\n");
                return;
            }

            Console.Clear();
            foreach (var materia in _listaMPrima)
            {
                Console.WriteLine(materia + "\n");
            }
        }

        public void ImprimirMateriasAtivos()
        {
            if (!_listaMPrima.Any())
            {
                Console.WriteLine("\nNão há itens cadastrados\n");
                return;
            }

            Console.Clear();
            foreach (var materia in _listaMPrima)
            {
                if (materia.Situacao == 'A')
                {
                    Console.WriteLine(materia + "\n");
                }
            }
        }

        public void ImprimirMateriaInativos()
        {
            if (!_listaMPrima.Any())
            {
                Console.WriteLine("\nNão há itens cadastrados\n");
                return;
            }

            Console.Clear();
            foreach (var materia in _listaMPrima)
            {
                if (materia.Situacao == 'I')
                {
                    Console.WriteLine(materia + "\n");
                }
            }
        }
    }
}
