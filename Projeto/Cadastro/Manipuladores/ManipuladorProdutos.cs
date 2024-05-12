using Projeto.Cadastro.Entidades;
using Projeto.Cadastro.Entradas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorProdutos
    {
        private string _diretorio;
        private string _arquivo;
        private List<Produto> _listaProdutos;

        public ManipuladorProdutos(string diretorio, string arquivo)
        {
            _diretorio = diretorio;
            _arquivo = arquivo;
            _listaProdutos = CarregarArquivoCliente();
        }

        private List<Produto> CarregarArquivoCliente()
        {
            List<Produto> produtos = new();
            try
            {
                var reader = new StreamReader(_diretorio + _arquivo);

                string? line = "";

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        produtos.Add(new Produto(line));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return produtos;
        }

        public Produto? BuscarPorCodigoDeBarras(string codigo)
        {
            return _listaProdutos.Find(produto => produto.CodigoBarras == codigo);
        }

        public void Cadastrar()
        {
            var novoProduto = EntradaProdutos.CadastrarProduto();
            _listaProdutos.Add(novoProduto);
            Salvar();
        }

        public void Editar()
        {
            Produto? produto = null;
            int opcao = 0;
            do
            {
                Console.Write("Código de barrasdo produto que deseja alterar: ");
                produto = BuscarPorCodigoDeBarras(Console.ReadLine());

                if (produto == null)
                {
                    Console.WriteLine("\nCodigo de barras não encontrado, selecione uma opção:");
                    Console.WriteLine("0 - Sair \n1 - Tentar novamente\n");
                    opcao = int.Parse(Console.ReadLine());
                }
                else
                {
                    EntradaProdutos.AlterarProduto(produto);
                }
            } while (opcao > 0);

            Salvar();
        }

        public void Salvar()
        {
            try
            {
                var writer = new StreamWriter(_diretorio + _arquivo);
                foreach (var produto in _listaProdutos)
                {
                    writer.WriteLine(produto.FormatarParaArquivo());
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public void ImprimirTodosProdutos()
        {
            if (!_listaProdutos.Any())
            {
                Console.WriteLine("\nNão há produtos cadastrados\n");
                return;
            }

            Console.Clear();
            foreach (var produto in _listaProdutos)
            {
                Console.WriteLine(produto + "\n");
            }
        }

        public void ImprimirProdutosAtivos()
        {
            if (!_listaProdutos.Any())
            {
                Console.WriteLine("\nNão há produtos cadastrados\n");
                return;
            }

            Console.Clear();
            foreach (var produto in _listaProdutos)
            {
                if (produto.Situacao == 'A')
                {
                    Console.WriteLine(produto + "\n");
                }
            }
        }

        public void ImprimirProdutosInativos()
        {
            if (!_listaProdutos.Any())
            {
                Console.WriteLine("\nNão há produtos cadastrados\n");
                return;
            }

            Console.Clear();
            foreach (var produto in _listaProdutos)
            {
                if (produto.Situacao == 'I')
                {
                    Console.WriteLine(produto + "\n");
                }
            }
        }
    }
}
