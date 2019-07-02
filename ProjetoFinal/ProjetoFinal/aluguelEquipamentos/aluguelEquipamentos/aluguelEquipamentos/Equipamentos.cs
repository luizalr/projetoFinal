using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projFinal
{
    class Equipamentos
    {
        private List<TipoEquipamento> total;

        public List<TipoEquipamento> Total { get { return this.total; } }

        public Equipamentos()
        {
            this.total = new List<TipoEquipamento>();
        }

        public void cadastrar(TipoEquipamento equipamento)
        {
            if (this.consultar(equipamento) != null) throw new Exception("Já existe um equipamento com esse ID.");
            this.total.Add(equipamento);
        }

        public TipoEquipamento consultar(TipoEquipamento equipamento)
        {
            return this.total.FirstOrDefault(item => item.Equals(equipamento));
        }
    }
}
