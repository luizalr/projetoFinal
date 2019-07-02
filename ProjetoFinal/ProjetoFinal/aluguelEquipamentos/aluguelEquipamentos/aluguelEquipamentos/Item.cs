using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projFinal
{
    class Item
    {
        private int idPatrimonio;
        private List<Contrato> locacoes;

        public Item()
        {
            this.locacoes = new List<Contrato>();
        }

        public Item(int t)
        {
            this.idPatrimonio = t;
            this.locacoes = new List<Contrato>();
        }

        public int Patrimonio
        {
            get { return this.idPatrimonio; }
            set { this.idPatrimonio = value; }
        }

        public List<Contrato> Locacoes
        {
            get { return this.locacoes; }
            set { this.locacoes = value; }
        }

        public bool alugar()
        {
            if (this.disponivel())
            {
                this.locacoes.Add(new Contrato(DateTime.Now));
                return true;
            }
            return false;
        }

        public bool devolver()
        {
            if (!this.disponivel())
            {
                this.locacoes[this.locacoes.Count - 1].DtDevolucao = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool disponivel()
        {
            if (this.locacoes.Count > 0)
                if (this.locacoes[this.locacoes.Count - 1].DtDevolucao == DateTime.MinValue)
                    return false;
            return true;
        }

        public int qtdLocados()
        {
            return this.locacoes.Count;
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() == this.GetType())
                return this.idPatrimonio == ((Item)obj).Patrimonio;
            return false;
        }
    }
}
