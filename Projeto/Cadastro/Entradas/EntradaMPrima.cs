using Projeto.Cadastro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Cadastro.Manipuladores;

namespace Projeto.Cadastro.Entradas
{
    internal class EntradaMPrima
    {
        public static MPrima CadastrarMateria(int id)
        {
            Console.WriteLine("Digite os dados para dar entrada em uma nova Materia prima: \n");

            Console.WriteLine("Nome (Máximo 20 caracteres):");
            string nome = Console.ReadLine();

            string newId = MPrima.FormatarId(id);

            return new(newId, nome);
        }

        public static void AlterarMateriaPrima(MPrima materia)
        {
            Console.Write("Alteração nome da MP: ");
            string novoNome = Console.ReadLine();
            materia.Nome = novoNome;
        }
    }
}
