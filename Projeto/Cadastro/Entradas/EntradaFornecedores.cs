using Projeto.Cadastro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cadastro.Entradas
{
    internal class EntradaFornecedores
    {
        public static Fornecedor CadastrarFornecedor()
        {
            Console.WriteLine("Digite os dados para cadastrar um novo fornecedor: \n");
            string cnpj;
            bool cnpjValido;
            do
            {
                Console.WriteLine("CNPJ (Apenas números):");
                cnpj = Console.ReadLine();
                cnpjValido = Fornecedor.VerificarCnpj(cnpj);

                if (!cnpjValido)
                {
                    Console.WriteLine("\nCNPJ inválido, digite novamente um valor válido.\n");
                }

            } while (!cnpjValido);

            Console.WriteLine("Razão social (Máximo 50 caracteres):");
            string razaoSocial = Console.ReadLine();

            Console.WriteLine("Data de abetura (dd/mm/aaaa):");
            string abetura = Console.ReadLine().Replace("/", "");
            int dia = int.Parse(abetura.Substring(0, 2));
            int mes = int.Parse(abetura.Substring(2, 2));
            int ano = int.Parse(abetura.Substring(4, 4));

            DateOnly dataAbertura = new DateOnly(ano, mes, dia);

            return new(cnpj, razaoSocial, dataAbertura);
        }

        public static void AlterarFornecedor(Fornecedor fornecedor)
        {
            int opcao;
            do
            {
                Console.WriteLine("\nSelecione qual informação deseja alterar: ");
                Console.WriteLine(fornecedor.GerarStringParaEdicao());
                /*
                 * 1 - RazaoSocial
                 * 2 - Data de Abertura
                 * 3 - Situacao
                 */
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Alteração de Razão social: ");
                        string novoNome = Console.ReadLine();
                        fornecedor.RazaoSocial = novoNome;
                        break;
                    case 2:
                        Console.WriteLine("Alterar data de abertura (dd/mm/aaaa):");
                        string abertura = Console.ReadLine().Replace("/", "");
                        int dia = int.Parse(abertura.Substring(0, 2));
                        int mes = int.Parse(abertura.Substring(2, 2));
                        int ano = int.Parse(abertura.Substring(4, 4));

                        fornecedor.DataAbertura = new DateOnly(ano, mes, dia);
                        break;
                    case 3:
                        string atual = fornecedor.Situacao == 'A' ? "ativo" : "inativo";
                        string novo = fornecedor.Situacao == 'A' ? "intivo" : "ativo";

                        Console.WriteLine($"O fornecedor está {atual}, confirmar aletração para {novo}? (s) Sim / (n) Não");
                        if (Console.ReadLine().ToLower() == "s") fornecedor.InverterSituacao();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.\n");
                        break;
                }
            } while (opcao is < 1 or > 3);
        }
    }
}
