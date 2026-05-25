using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaSupermercado
{
    public partial class Edicao : Form
    {
        private Prod produto;
        private string caminhoImagem = "";

        public Edicao(Prod p)
        {
            InitializeComponent();

            produto = p;

            txtId.Text =
                produto.Codigo.ToString();

            txtNome.Text =
                produto.Nome;

            cmbCategoria.Text =
                produto.Categoria;

            nudQuantidade.Value =
                produto.Quantidade;

            txtValor.Text =
                produto.Valor.ToString();

            dtpEntrada.Value =
                produto.Entrada;

            dtpValidade.Value =
                produto.Validade;

            if (!string.IsNullOrEmpty(produto.Imagem))
            {
                caminhoImagem = produto.Imagem;

                picProduto.Image = Image.FromFile(caminhoImagem);

                picProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            caminhoImagem = produto.Imagem;

            if (!string.IsNullOrEmpty(produto.Imagem))
            {
                picProduto.Image = Image.FromFile(produto.Imagem);
                picProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn =
                new MySqlConnection(
                DataBase.conexao);

                conn.Open();

                string sql =
                @"UPDATE produtos
                SET

                nome=@nome,
                categoria=@categoria,
                quantidade=@quantidade,
                valor=@valor,
                entrada=@entrada,
                validade=@validade,
                imagem=@imagem

                WHERE codigo=@codigo";

                MySqlCommand cmd =
                new MySqlCommand(
                sql,
                conn);

                cmd.Parameters.AddWithValue(
                "@codigo",
                produto.Codigo);

                cmd.Parameters.AddWithValue(
                "@nome",
                txtNome.Text);

                cmd.Parameters.AddWithValue(
                "@categoria",
                cmbCategoria.Text);

                cmd.Parameters.AddWithValue(
                "@quantidade",
                (int)nudQuantidade.Value);

                cmd.Parameters.AddWithValue(
                "@valor",
                decimal.Parse(
                txtValor.Text));

                cmd.Parameters.AddWithValue("@entrada", dtpEntrada.Value);

                cmd.Parameters.AddWithValue("@validade", dtpValidade.Value);

                cmd.Parameters.AddWithValue("@imagem", caminhoImagem);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Produto atualizado!");

                this.DialogResult = DialogResult.OK;

                this.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();

            cmbCategoria.SelectedIndex = -1;

            nudQuantidade.Value = 0;

            txtValor.Clear();

            dtpEntrada.Value = DateTime.Now;

            dtpValidade.Value = DateTime.Now;

            picProduto.Image = null;

            caminhoImagem = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DialogResult resposta =
         MessageBox.Show(
         "Deseja realmente excluir este produto?",
         "Confirmação",
         MessageBoxButtons.YesNo,
         MessageBoxIcon.Warning);

            if (resposta == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection conn =
                    new MySqlConnection(
                    DataBase.conexao);

                    conn.Open();

                    string sql =
                    "DELETE FROM produtos WHERE codigo=@codigo";

                    MySqlCommand cmd =
                    new MySqlCommand(
                    sql,
                    conn);

                    cmd.Parameters.AddWithValue("@codigo", produto.Codigo);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Produto excluído.");

                    this.DialogResult =DialogResult.Abort;

                    this.Close();
                }

                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }
        

        private void btnImg_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagens|*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = openFileDialog1.FileName;

                picProduto.Image = Image.FromFile(caminhoImagem);

                picProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}