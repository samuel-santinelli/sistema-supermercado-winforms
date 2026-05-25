using MySql.Data.MySqlClient;
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
    public partial class Historico : Form
    {
        public Historico()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form1 tela = new Form1();
            tela.Show();
            this.Hide();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Produtos tela = new Produtos();
            tela.Show();
            this.Hide();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Vendas tela = new Vendas();
            tela.Show();
            this.Hide();
        }

        private void CarregarHistorico()
        {
            try
            {
                lstHistorico.Items.Clear();

                MySqlConnection conn = new MySqlConnection(DataBase.conexao);

                conn.Open();

                string sql =
                "SELECT * FROM vendas ORDER BY dataVenda DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    lstHistorico.Items.Add(

                    "Venda #" +

                    leitor["idVenda"] +

                    " | " +

                    Convert.ToDateTime(
                    leitor["dataVenda"])
                    .ToString(
                    "dd/MM/yyyy HH:mm") +

                    " | R$" +

                    Convert.ToDecimal(
                    leitor["total"])
                    .ToString(
                    "N2"));
                }

                conn.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show(
                erro.Message);
            }
        }

        private void Historico_Load(object sender, EventArgs e)
        {
            CarregarHistorico();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstHistorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstHistorico.SelectedItem == null)
                    return;

                lstDetalhes.Items.Clear();

                string linha = lstHistorico.SelectedItem
                .ToString();

                int idVenda =
                Convert.ToInt32(linha.Split('|')[0].Replace("Venda #", "").Trim());

                MySqlConnection conn = new MySqlConnection(DataBase.conexao);

                conn.Open();

                string sql =
                "SELECT * FROM itensVenda " +
                "WHERE idVenda=@id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", idVenda);

                MySqlDataReader leitor = cmd.ExecuteReader(); while (leitor.Read())
                {
                    lstDetalhes.Items.Add(leitor["produto"] +" | Qtd: " + leitor["quantidade"] +" | R$ " + Convert.ToDecimal(leitor["valor"]).ToString("N2"));
                }

                conn.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
