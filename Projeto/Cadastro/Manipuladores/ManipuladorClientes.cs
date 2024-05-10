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
        private string Diretorio;
        private string Arquivo;
        private List<Cliente> ListaClientes;

        public ManipuladorClientes(string diretorio, string arquivo)
        {
            Diretorio = diretorio;
            Arquivo = arquivo;
            ListaClientes = CarregarArquivoCliente();
        }

        private List<Cliente> CarregarArquivoCliente()
        {
            var clientes = new List<Cliente>();
            var reader = new StreamReader(Diretorio + Arquivo);
            
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

            return clientes;
        }
        
        public Cliente? BuscarPorCpf(string cpf)
        {
            return ListaClientes.Find(cliente => cliente.GetCpf() == cpf);
        }

        public void Cadastrar()
        {

        }

        public void Editar()
        {

        }

        public void Salvar()
        {

        }
    }
}
