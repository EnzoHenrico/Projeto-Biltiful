using Projeto.Cadastro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorFornecedores
    {
        private string _diretorio;
        private string _arquivo;
        private List<Fornecedor> _listaFornecedores;

        public ManipuladorFornecedores(string diretorio, string arquivo)
        {
            _diretorio = diretorio;
            _arquivo = arquivo;
            _listaFornecedores = CarregarArquivoFornecedor();
        }

        private List<Fornecedor> CarregarArquivoFornecedor()
        {
            List<Fornecedor> fornecedores = new();
            try
            {
                var reader = new StreamReader(_diretorio + _arquivo);

                string? line = "";

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        fornecedores.Add(new Fornecedor(line));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return fornecedores;
        }

        public Fornecedor? BuscarPorCnpj(string cnpj)
        {
            return _listaFornecedores.Find(fornecedor => fornecedor.Cnpj == cnpj);
        }

        public void Cadastrar()
        {
            var novoFornecedor = EntradaFornecedores.CadastrarFornecedor();
            _listaFornecedores.Add(novoFornecedor);
            Salvar();
        }

        public void Editar()
        {
            int opcao = 0;
            Fornecedor? fornecedor = null;
            do
            {
                Console.Write("CNPJ do forncedor para alteração: ");
                fornecedor = BuscarPorCnpj(Console.ReadLine());

                if (fornecedor == null)
                {
                    Console.WriteLine("\nCNPJ não econtrado, selecione uma opção:");
                    Console.WriteLine("0 - Sair \n1 - Tentar novamente\n");
                    opcao = int.Parse(Console.ReadLine());
                }
            } while (opcao > 0);

            EntradaFornecedores.AlterarFornecedor(fornecedor);
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                var writer = new StreamWriter(_diretorio + _arquivo);
                foreach (var forncedor in _listaFornecedores)
                {
                    writer.WriteLine(forncedor.FormatarParaArquivo());
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public void ImprimirTodosForncedores()
        {
            if (!_listaFornecedores.Any())
            {
                Console.WriteLine("\nNão há forncedores cadastrados\n");
                return;
            }
            foreach (var forncedor in _listaFornecedores)
            {
                Console.WriteLine(forncedor + "\n");
            }
        }

        public void ImprimirForncedoresAtivos()
        {
            if (!_listaFornecedores.Any())
            {
                Console.WriteLine("\nNão há forncedores ativos cadastrados\n");
                return;
            }
            foreach (var fornecedores in _listaFornecedores)
            {
                if (fornecedores.Situacao == 'A')
                {
                    Console.WriteLine(fornecedores + "\n");
                }
            }
        }

        public void ImprimirFornecedoreInativos()
        {
            if (!_listaFornecedores.Any())
            {
                Console.WriteLine("\nNão há fornecedores inativos cadastrados\n");
                return;
            }
            foreach (var fornecedores in _listaFornecedores)
            {
                if (fornecedores.Situacao == 'I')
                {
                    Console.WriteLine(fornecedores + "\n");
                }
            }
        }
    }
}
