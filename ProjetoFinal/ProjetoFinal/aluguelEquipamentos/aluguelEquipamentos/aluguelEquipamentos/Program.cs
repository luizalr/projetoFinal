using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projFinal
{
    class Program
    {
        static Equipamentos equipamentos = new Equipamentos();

        static void Main(string[] args)
        {
            string op = "";
            do
            {

                Console.Clear();

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("| 0. Sair                           |");
                Console.WriteLine("| 1. Cadastrar equipamento          |");
                Console.WriteLine("| 2. Consultar equipamento          |");
                Console.WriteLine("| 3. Consultar itens alugados       |");
                Console.WriteLine("| 4. Cadastrar item                 |");
                Console.WriteLine("| 5. Registrar aluguel              |");
                Console.WriteLine("| 6. Registrar devolução            |");
                Console.WriteLine("-------------------------------------");

                Console.Write("Digite uma opção: ");
                try
                {
                    op = Console.ReadLine();

                    switch (op)
                    {
                        case "0": break;
                        case "1": cadastrarTipoEquipamento(); break;
                        case "2": pesquisar(); break;
                        case "3": pesquisarX(); break;
                        case "4": cadastrarItem(); break;
                        case "5": registrarEmprestimo(); break;
                        case "6": registrarDevolucao(); break;
                        default: Console.WriteLine("Opção inválida."); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            } while (op != "0");

            System.Environment.Exit(0);
        }

        static void cadastrarTipoEquipamento()
        {

            Console.Write("\nDigite o ID do tipo: ");
            int idTipo = Int32.Parse(Console.ReadLine());
            if (equipamentos.consultar(new TipoEquipamento(idTipo)) != null) throw new Exception("Já existe um equipamento com esse id");

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o valor: ");
            string valor = Console.ReadLine();

            equipamentos.cadastrar(new TipoEquipamento(idTipo, nome, valor));
            Console.WriteLine("Tipo de equipamento cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void pesquisar()
        {

            Console.Write("\nDigite o ID do tipo de equipamento: ");
            int idTipo = Int32.Parse(Console.ReadLine());
            TipoEquipamento equipamento = equipamentos.consultar(new TipoEquipamento(idTipo));
            if (equipamento == null) throw new Exception("Equipamento não encontrado.");

            Console.WriteLine("Total de itens: " + equipamento.qtdItens());
            Console.WriteLine("Total de itens disponíveis: " + equipamento.qtdeDisponiveis());
            Console.WriteLine("Total de aluguéis: " + equipamento.qtdLocados());

            Console.ReadKey();
        }

        static void pesquisarX()
        {

            Console.Write("\nDigite o ID do tipo de equipamento: ");
            int idTipo = Int32.Parse(Console.ReadLine());
            TipoEquipamento equipamento = equipamentos.consultar(new TipoEquipamento(idTipo));
            if (equipamento == null) throw new Exception("Equipamento não encontrado.");

            Console.WriteLine("Total de itens: " + equipamento.qtdItens());
            Console.WriteLine("Total de itens disponíveis: " + equipamento.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: " + equipamento.qtdLocados());

            equipamento.Itens.ForEach(i => {
                Console.WriteLine("=========================================================");
                Console.WriteLine("Patrimonio: " + i.Patrimonio);
                i.Locacoes.ForEach(j => {
                    String devolucao = (j.DtDevolucao != DateTime.MinValue) ? j.DtDevolucao.ToString() : "-------------------";
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Data Empréstimo: " + j.DtAluguel);
                    Console.WriteLine("Data Devolução:  " + devolucao);
                });
            });

            Console.ReadKey();
        }

        static void cadastrarItem()
        {

            Console.Write("\nDigite o ID do Tipo: ");
            int idTipo = Int32.Parse(Console.ReadLine());

            TipoEquipamento equipamento = equipamentos.consultar(new TipoEquipamento(idTipo));
            if (equipamento == null) throw new Exception("equipamento não encontrado.");

            Console.Write("Digite o ID do Patrimônio: ");
            int idPatrimonio = Int32.Parse(Console.ReadLine());
            equipamento.cadastrarItem(new Item(idPatrimonio));
            Console.WriteLine("Item cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void registrarEmprestimo()
        {
            Console.Write("\nDigite o Id do Tipo: ");
            int idTipo = Int32.Parse(Console.ReadLine());

            TipoEquipamento equipamento = equipamentos.consultar(new TipoEquipamento(idTipo));
            if (equipamento == null) throw new Exception("Equipamento não encontrado.");

            Item item = equipamento.Itens.FirstOrDefault(i => i.alugar());
            if (item != null) Console.WriteLine("Item " + item.Patrimonio + " alugado com sucesso!");
            else throw new Exception("Não há itens disponíveis.");
        }

        static void registrarDevolucao()
        {
            Console.Write("\nDigite o ID do Tipo: ");
            int idTipo = Int32.Parse(Console.ReadLine());

            TipoEquipamento equipamento = equipamentos.consultar(new TipoEquipamento(idTipo));
            if (equipamento == null) throw new Exception("Equipamento não encontrado.");

            Item item = equipamento.Itens.FirstOrDefault(i => i.devolver());
            if (item != null) Console.WriteLine("Item " + item.Patrimonio + " devolvido com sucesso!");
            else Console.WriteLine("Não há itens locados.");
            Console.ReadKey();
        }
    }
}