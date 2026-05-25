using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaSupermercado
{
    public partial class NotaFiscal : Form
    {
        List<CarrinhoItem> carrinho;

        public NotaFiscal(
        List<CarrinhoItem> itens)
        {
            InitializeComponent();

            carrinho = itens;

            GerarNota();
        }

        private void GerarNota()
        {
            rtbNota.Clear();

            rtbNota.Font =
            new Font(
            "Consolas",
            10);

            rtbNota.AppendText(
            "      MERCADO LIMOEIRO\n");

            rtbNota.AppendText(
            "      Avenida dos Remedios, 287\n");

            rtbNota.AppendText(
            "      CNPJ: 11.784.678/0001-90\n");

            rtbNota.AppendText(
            "      Fone: (11)4002-8922\n");

            rtbNota.AppendText(
            "\n");

            rtbNota.AppendText(
            "      *** NOTA DE COMPRA ***\n\n");

            Random numero =
            new Random();

            rtbNota.AppendText(
            "N° Nota: " +
            numero.Next(10000, 99999));

            rtbNota.AppendText(
            "     Data: " +
            DateTime.Now.ToString(
            "dd/MM/yyyy HH:mm"));

            rtbNota.AppendText(
            "\n");

            rtbNota.AppendText(
            "-------------------------------------------------\n");

            rtbNota.AppendText(
            "Produto".PadRight(18) +

            "Qtd".PadRight(6) +

            "Unit".PadRight(10) +

            "Total\n");

            rtbNota.AppendText(
            "-------------------------------------------------\n");

            decimal totalCompra = 0;

            foreach (var item in carrinho)
            {
                decimal totalItem =
                item.Subtotal;

                totalCompra +=
                totalItem;

                rtbNota.AppendText(

                item.Produto.PadRight(18) +

                item.Quantidade.ToString()
                .PadRight(6) +

                item.ValorUnitario
                .ToString("N2")
                .PadRight(10) +

                totalItem
                .ToString("N2") +

                "\n");
            }

            rtbNota.AppendText(
            "\n");

            rtbNota.AppendText(
            "-------------------------------------------------\n");

            rtbNota.AppendText(
            "TOTAL DA COMPRA".PadRight(30));

            rtbNota.AppendText(
            "R$ " +
            totalCompra.ToString(
            "N2"));

            rtbNota.AppendText(
            "\n\n");

            rtbNota.AppendText(
            "        Obrigado e volte sempre!");
        }

        private void btnFechar_Click(
        object sender,
        EventArgs e)
        {
            this.Close();
        }
    }
}
