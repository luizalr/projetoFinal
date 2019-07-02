using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projFinal
{
    class TipoEquipamento
    {
        private int idTipo;
        private string nome;
        private double valor;
        private List<Item> itens;

        public List<Item> Itens { get { return this.itens; } }
        
        public TipoEquipamento(int i) { this.idTipo = i; }

        public TipoEquipamento(int i, string t, string a)
        {
            this.idTipo = i;
            this.nome = t;
            this.valor = 0;
            this.itens = new List<Item>();
        }

        public void cadastrarItem(Item item)
        {
            foreach (Item ite in this.itens)
                if (ite.Equals(item)) throw new Exception("Já existe um item com este id.");
            this.itens.Add(item);
        }

        public int qtdItens()
        {
            return this.itens.Count;
        }

        public int qtdeDisponiveis()
        {
            int disponiveis = 0;
            this.itens.ForEach(item => { if (item.disponivel()) disponiveis++; });
            return disponiveis;
        }

        public int qtdLocados()
        {
            int alugados = 0;
            this.itens.ForEach(item => alugados += item.qtdLocados());
            return alugados;
        }
        
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.idTipo.Equals(((TipoEquipamento)obj).idTipo);
            return false;
        }
    }
}
