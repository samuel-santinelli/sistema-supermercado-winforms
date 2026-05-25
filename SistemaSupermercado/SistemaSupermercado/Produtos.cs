using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaSupermercado
{
    public partial class Produtos : Form
    {
        private string caminhoImagem = "";

        public Produtos()
        {
            InitializeComponent();
        }

        private void Produtos_Load(object sender, EventArgs e)
        {
            string[] categorias =
            {
                "Alimentos",
                "Bebidas",
                "Limpeza",
                "Higiene",
                "Padaria"
            };

            for (int i = 0;i < categorias.Length; i++)
            {
                cmbCategoria.Items.Add(categorias[i]);
            }

            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            try
            {
                MySqlConnection conn =
                new MySqlConnection(
                DataBase.conexao);

                conn.Open();

                string sql =
                "SELECT * FROM produtos";

                MySqlDataAdapter da =
                new MySqlDataAdapter(
                sql,
                conn);

                DataTable tabela =
                new DataTable();

                da.Fill(tabela);

                dgvProdutos.DataSource =
                tabela;

                conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Informe codigo do produto.");

                return;
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o nome do produto.");

                return;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a categoria.");

                return;
            }

            if (txtValor.Text == "")
            {
                MessageBox.Show("Informe valor.");

                return;
            }

            switch (cmbCategoria.Text)
            {
                case "Alimentos":
                    break;

                case "Bebidas":
                    break;

                case "Limpeza":
                    break;

                case "Higiene":
                    break;

                case "Padaria":
                    break;

                default:

                    MessageBox.Show(
                    "Categoria inválida");

                    return;
            }

            try
            {
                MySqlConnection conn =
                new MySqlConnection(
                DataBase.conexao);

                conn.Open();

                string sql =
                @"INSERT INTO produtos
                (
                codigo,
                nome,
                categoria,
                quantidade,
                valor,
                entrada,
                validade,
                imagem
                )

                VALUES
                (
                @codigo,
                @nome,
                @categoria,
                @quantidade,
                @valor,
                @entrada,
                @validade,
                @imagem
                )";

                MySqlCommand cmd =
                new MySqlCommand(
                sql,
                conn);

                cmd.Parameters.AddWithValue(
                "@codigo",
                int.Parse(txtId.Text));

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
                decimal.Parse(txtValor.Text));

                cmd.Parameters.AddWithValue(
                "@entrada",
                dtpEntrada.Value);

                cmd.Parameters.AddWithValue(
                "@validade",
                dtpValidade.Value);

                cmd.Parameters.AddWithValue(
                "@imagem",
                caminhoImagem);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Produto salvo.");

                CarregarProdutos();

                btnLimpar.PerformClick();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn =
                new MySqlConnection(
                DataBase.conexao);

                conn.Open();

                string sql =
                @"SELECT * FROM produtos
                WHERE nome LIKE @pesquisa
                OR categoria LIKE @pesquisa
                OR codigo LIKE @pesquisa";

                MySqlCommand cmd =
                new MySqlCommand(
                sql,
                conn);

                cmd.Parameters.AddWithValue(
                "@pesquisa",
                "%" + txtBuscar.Text + "%");

                MySqlDataAdapter da =
                new MySqlDataAdapter(
                cmd);

                DataTable tabela =
                new DataTable();

                da.Fill(tabela);

                dgvProdutos.DataSource =
                tabela;

                conn.Close();

                if (tabela.Rows.Count == 0)
                {
                    MessageBox.Show(
                    "Produto não encontrado");
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(
                erro.Message);
            }
        }

        private void btnBuscarEdit_Click(object sender, EventArgs e)
        {
            int id =
            int.Parse(
            txtIdEditar.Text);

            try
            {
                MySqlConnection conn = new MySqlConnection( DataBase.conexao);

                conn.Open();

                string sql = "SELECT * FROM produtos WHERE codigo=@id";

                MySqlCommand cmd = new MySqlCommand( sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.Read())
                {
                    Prod produto =
                    new Prod();

                    produto.Codigo =
                    leitor.GetInt32(
                    "codigo");

                    produto.Nome =
                    leitor.GetString(
                    "nome");

                    produto.Categoria =
                    leitor.GetString(
                    "categoria");

                    produto.Quantidade =
                    leitor.GetInt32(
                    "quantidade");

                    produto.Valor =
                    leitor.GetDecimal(
                    "valor");

                    produto.Entrada =
                    leitor.GetDateTime(
                    "entrada");

                    produto.Validade =
                    leitor.GetDateTime(
                    "validade");

                    produto.Imagem =
                    leitor["imagem"]
                    .ToString();

                    leitor.Close();

                    Edicao tela = new Edicao(produto);

                    tela.ShowDialog();

                    CarregarProdutos();
                }

                else
                {
                    MessageBox.Show(
                    "Produto não encontrado.");
                }

                conn.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show(
                erro.Message);
            }
        }

        private void btnImg_Click( object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caminhoImagem = openFileDialog1.FileName;

                picProduto.Image = Image.FromFile(caminhoImagem);

                picProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Clear();

            txtNome.Clear();

            cmbCategoria.SelectedIndex = -1;

            nudQuantidade.Value = 0;

            txtValor.Clear();

            dtpEntrada.Value =
            DateTime.Now;

            dtpValidade.Value =
            DateTime.Now;

            picProduto.Image = null;

            caminhoImagem = "";
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form1 tela =
            new Form1();
            tela.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text ==
            "Digite o nome ou id do produto para buscar.")
            {
                txtBuscar.Clear();

                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text =
                "Digite o nome ou id do produto para buscar.";

                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            Vendas tela = new Vendas();
            tela.Show();
            this.Hide();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Historico tela = new Historico();
            tela.Show();
            this.Hide();
        }
    }
}