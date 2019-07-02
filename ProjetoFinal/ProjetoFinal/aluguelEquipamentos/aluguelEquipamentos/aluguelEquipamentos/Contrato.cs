using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projFinal
{
    class Contrato
    {
        private int idContrato;
        private DateTime dtAluguel;
        private DateTime dtDevolucao;


        public Contrato(DateTime dtEmp)
        {
            this.dtAluguel = dtEmp;
        }

        public DateTime DtAluguel
        {
            get { return this.dtAluguel; }
            set { this.dtAluguel = value; }
        }

        public DateTime DtDevolucao
        {
            get { return this.dtDevolucao; }
            set { this.dtDevolucao = value; }
        }
    }
}
