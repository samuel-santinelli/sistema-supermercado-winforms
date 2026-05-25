using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSupermercado
{
    public class CarrinhoItem
    {
        public string Produto { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal Subtotal
        {
            get
            {
                return Quantidade * ValorUnitario;
            }
        }
    }
}
