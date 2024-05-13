using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Producao
{
    internal class MainProducao
    {
        public void Acesso()
        {
            int opcao = 0;
            bool repetir = true;
            Producao p = new Producao();
            ItemProducao ip = new ItemProducao();

            void Menu()
            {
                Console.Clear();
                Console.WriteLine("|----[ Módulo de Produção ]----|\n");
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("[ 1 ] Cadastrar Produção");
                Console.WriteLine("[ 2 ] Localizar Produção");
                Console.WriteLine("[ 3 ] Remover Podução");
                Console.WriteLine("[ 4 ] Navegar por registro");
                Console.WriteLine("[ 0 ] Volar");
            }
            do
            {
                Menu();
                try
                {
                    Console.Write("\nOpção: ");
                    opcao = int.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("Erro! Valor inválido.");
                }
                switch (opcao)
                {
                    case 1:
                        p.CriarProducao(ip);
                        break;
                    case 2:
                        p.LocalizarProducao(ip);
                        break;
                    case 3:
                        p.RemoverProducao();
                        break;
                    case 4:
                        p.NavegarProducao();
                        break;
                    case 0:
                        repetir = false;
                        break;
                }
            } while (repetir);
        }
    }
}
