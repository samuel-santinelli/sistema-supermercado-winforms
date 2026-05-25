using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSupermercado
{
    public class Prod
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Validade { get; set; }
        public string Imagem { get; set; }
    }
}
