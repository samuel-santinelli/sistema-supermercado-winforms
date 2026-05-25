using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace SistemaSupermercado
{
    public partial class ResumoCompra : Form
    {
        List<CarrinhoItem> carrinho;

        public ResumoCompra(List<CarrinhoItem> itens)
        {
            InitializeComponent();

            carrinho = itens;

            CarregarResumo();
        }

        private void CarregarResumo()
        {
            lstResumo.Items.Clear();

            foreach (var item in carrinho)
            {
                lstResumo.Items.Add(

                $"{item.Produto} | " +

                $"Qtd:{item.Quantidade} | " +

                $"R${item.Subtotal:N2}");
            }

            decimal total =
            carrinho.Sum(
            x => x.Subtotal);

            txtResumo.Text =
            "R$ " +
            total.ToString("N2");
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn =
                new MySqlConnection(
                DataBase.conexao);

                conn.Open();

                decimal total =
                carrinho.Sum(
                x => x.Subtotal);

                string sqlVenda =
                "INSERT INTO vendas " +
                "(dataVenda,total) " +
                "VALUES (@data,@total)";

                MySqlCommand cmdVenda = new MySqlCommand(sqlVenda, conn);

                cmdVenda.Parameters.AddWithValue("@data", DateTime.Now);

                cmdVenda.Parameters.AddWithValue("@total", total);

                cmdVenda.ExecuteNonQuery();

                int idVenda = (int)cmdVenda.LastInsertedId;

                foreach (var item in carrinho)
                {
                    string sqlItem =
                    "INSERT INTO itensVenda " +
                    "(idVenda,produto,quantidade,valor) " +
                    "VALUES " +
                    "(@id,@produto,@qtd,@valor)";

                    MySqlCommand cmdItem =
                    new MySqlCommand(
                    sqlItem,
                    conn);

                    cmdItem.Parameters.AddWithValue(
                    "@id",
                    idVenda);

                    cmdItem.Parameters.AddWithValue(
                    "@produto",
                    item.Produto);

                    cmdItem.Parameters.AddWithValue(
                    "@qtd",
                    item.Quantidade);

                    cmdItem.Parameters.AddWithValue(
                    "@valor",
                    item.ValorUnitario);

                    cmdItem.ExecuteNonQuery();
                }

                conn.Close();

                NotaFiscal tela = new NotaFiscal(carrinho);

                tela.ShowDialog();

                this.DialogResult = DialogResult.OK;

                this.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta =
            MessageBox.Show(
            "Deseja cancelar esta compra?",
            "Confirmação",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
