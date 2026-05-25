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
    public partial class Vendas : Form
    {

        private string nomeProduto = "";
        List <CarrinhoItem> carrinho = new List<CarrinhoItem>();

        public Vendas()
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn =new MySqlConnection(DataBase.conexao);

                conn.Open();

                string sql =
                @"SELECT * FROM produtos
                WHERE codigo=@busca
                OR nome LIKE @nome";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@busca",txtBuscar.Text);
                cmd.Parameters.AddWithValue("@nome","%" + txtBuscar.Text + "%");

                MySqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.Read())
                {
                    nomeProduto = leitor["nome"].ToString();

                    txtValor.Text = Convert.ToDecimal(leitor["valor"]).ToString("N2");

                    txtQuantidade.Text = leitor["quantidade"].ToString();

                    string imagem = leitor["imagem"].ToString();

                    if (!string.IsNullOrEmpty(imagem))
                    {
                        picProd.Image = Image.FromFile(imagem);

                        picProd.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    nudQuantidade.Maximum = Convert.ToInt32(leitor["quantidade"]);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado");
                }

                conn.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nomeProduto))
            {
                MessageBox.Show("Favor fazer a busca de um item primeiro.");

                return;
            }

            CarrinhoItem item = new CarrinhoItem();

            item.Produto = nomeProduto;
            item.Quantidade = (int)nudQuantidade.Value;
            item.ValorUnitario = Convert.ToDecimal(txtValor.Text);
            carrinho.Add(item);

            lstCarrinho.Items.Add(
            $"{item.Produto} | " +
            $"Qtd:{item.Quantidade} | " +
            $"Unit:R${item.ValorUnitario:N2} | " +
            $"Sub:R${item.Subtotal:N2}");

            decimal total = carrinho.Sum(x => x.Subtotal);
            txtTotal.Text = "R$ " + total.ToString("N2");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtValor.Clear();
            txtQuantidade.Clear();
            nudQuantidade.Value = 0;
            picProd.Image = null;
            nomeProduto = "";
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstCarrinho.SelectedIndex >= 0)
            {
                int indice = lstCarrinho.SelectedIndex;

                carrinho.RemoveAt(indice);
                lstCarrinho.Items.RemoveAt(indice);
                decimal total = carrinho.Sum(x => x.Subtotal);
                txtTotal.Text = "R$ " + total.ToString("N2");
            }
            else
            {
                MessageBox.Show("Favor selecione um item do carrinho.");
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!");

                return;
            }

            ResumoCompra tela = new ResumoCompra( carrinho);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                carrinho.Clear();

                lstCarrinho.Items.Clear();

                txtTotal.Clear();

                btnLimpar.PerformClick();
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Historico tela = new Historico();
            tela.Show();
            this.Hide();

        }
    }
}

