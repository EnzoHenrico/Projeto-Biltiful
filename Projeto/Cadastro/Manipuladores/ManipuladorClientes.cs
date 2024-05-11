using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Cadastro.Entidades;

namespace Projeto.Cadastro.Manipuladores
{
    internal class ManipuladorClientes
    {
        private string _diretorio;
        private string _arquivo;
        private List<Cliente> _listaClientes;

        public ManipuladorClientes(string diretorio, string arquivo)
        {
            _diretorio = diretorio;
            _arquivo = arquivo;
            _listaClientes = CarregarArquivoCliente();
        }

        private List<Cliente> CarregarArquivoCliente()
        {
            List<Cliente> clientes = new ();
            try
            {
                var reader = new StreamReader(_diretorio + _arquivo);

                string? line = "";

                while (line != null)
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        clientes.Add(new Cliente(line));
                    }
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            
            return clientes;
        }
        
        public Cliente? BuscarPorCpf(string cpf)
        {
            return _listaClientes.Find(cliente => cliente.Cpf == cpf);
        }

        public void Cadastrar()
        {
            var novoCliente = EntradaClientes.CadastrarCliente();
            _listaClientes.Add(novoCliente);
        }

        public void Editar()
        {
            string id = "";
            Cliente? cliente = null;
            do
            {
                Console.Write("CPF do cliente para alteração: ");
                cliente = BuscarPorCpf(Console.ReadLine());
                
                if (cliente == null)
                {
                    Console.WriteLine("\nCPF não encontrado, tente novamente\n");
                }
            } while (cliente == null);

            EntradaClientes.AlterarCliente(_listaClientes.Find(cliente => cliente.Cpf == id));
            Salvar();
        }

        public void Salvar()
        {
            try
            {
                var writer = new StreamWriter(_diretorio + _arquivo);
                foreach (var cliente in _listaClientes)
                {
                    writer.WriteLine(cliente.FormatarParaArquivo());     
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public void ImprimirTodosClientes()
        {
            if (!_listaClientes.Any())
            {
                Console.WriteLine("\nNão há clientes cadastrados\n");
                return;
            }
            foreach (var cliente in _listaClientes)
            {
                Console.WriteLine(cliente + "\n");
            }
        }
        
        public void ImprimirClientesAtivos()
        {
            if (!_listaClientes.Any())
            {
                Console.WriteLine("\nNão há clientes cadastrados\n");
                return;
            }
            foreach (var cliente in _listaClientes)
            {
                if (cliente.Situacao == 'A')
                {
                    Console.WriteLine(cliente + "\n");
                }
            }
        }

        public void ImprimirClientesInAtivos()
        {
            if (!_listaClientes.Any())
            {
                Console.WriteLine("\nNão há clientes cadastrados\n");
                return;
            }
            foreach (var cliente in _listaClientes)
            {
                if (cliente.Situacao == 'I')
                {
                    Console.WriteLine(cliente + "\n");
                }
            }
        }
    }
}
