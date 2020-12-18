using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPDV___Lanchonete
{
    public partial class Vendas : Form
    {

        List<Carrinho> t { get; set; }
        MySQL instanciaMySql = new MySQL();
        string sql;
        public Vendas()
        {
            InitializeComponent();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormaEntrega.Text == "Entrega")
            {
                gbEntrega.Height = 169;
                gbPagamento.Location = new Point(12, 420);
            }
            if (cbFormaEntrega.Text == "Retirada no Local")
            {
                gbEntrega.Height = 70;
                gbPagamento.Location = new Point(12, 320);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbPagamento.Text == "Dinheiro")
            {
                gbPagamento.Height = 169;
            }
            if (cbPagamento.Text == "Cartão")
            {
                gbPagamento.Height = 70;
            }
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            CarregarDados();
            CarregarDadosProdutos();
            PreencherComboBoxPesquisa();
        }

        private void CarregarDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT nome AS \"Nome\"," +
                    " telefone AS \"Telefone\", " +
                    " cep AS \"CEP\", " +
                    " endereco AS \"Endereco\", " +
                    " numero AS \"Nº\", " +
                    " bairro AS \"Bairro\", " +
                    " cidade AS \"Cidade\", " +
                    " estado AS \"Estado\" " +
                    " FROM Cliente";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvClientes.DataSource = ds;
                dgvClientes.Columns["Nome"].Width = 130;
                dgvClientes.Columns["Telefone"].Width = 100;
                dgvClientes.Columns["Endereco"].Width = 130;
                dgvClientes.Columns["CEP"].Visible = false;
                dgvClientes.Columns["nº"].Width = 40;
                dgvClientes.Columns["Cidade"].Visible = false;
                dgvClientes.Columns["Estado"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void CarregarDadosProdutos()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT descricao AS \"Descricao\"," +
                    " valor AS \"Valor\" " +
                    " FROM Produto";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvProdutos.DataSource = ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void PreencherComboBoxPesquisa()
        {
            foreach (DataGridViewColumn coluna in dgvClientes.Columns)
            {
                cbPesquisar.Items.Add(coluna.HeaderText);
            }
            foreach (DataGridViewColumn coluna in dgvProdutos.Columns)
            {
                cbProduto.Items.Add(coluna.HeaderText);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbPesquisar.Text))
            {
                (dgvClientes.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtNome.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtTelefone.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtCEP.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtEnd.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtNumero.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtBairro.Text = dgvClientes.SelectedCells[5].Value.ToString();
            txtCidade.Text = dgvClientes.SelectedCells[6].Value.ToString();
            txtUf.Text = dgvClientes.SelectedCells[7].Value.ToString();

        }

        private void txtPesquisarProdutos_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbProduto.Text))
            {
                (dgvProdutos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbProduto.Text, txtPesquisarProdutos.Text);
            }
        }


        public class Carrinho
        {
            
            public string Produto { get; set; }
            public string Quantidade { get; set; }
            public decimal Valor_Unitario { get; set; }
            public decimal Valor_Total { get; set; }

        }
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            t = new List<Carrinho>();

            t.Add(new Carrinho() { Produto = dgvProdutos.SelectedCells[0].Value.ToString(), 
                Quantidade = txtQuantidade.Text, 
                Valor_Unitario = Convert.ToDecimal(dgvProdutos.SelectedCells[1].Value.ToString()), 
                Valor_Total = Convert.ToDecimal(dgvProdutos.SelectedCells[1].Value.ToString()) * Convert.ToInt32(txtQuantidade.Text) });
            dgvCarrinho.DataSource = t;
            dgvCarrinho.Refresh();
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dgvProdutos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvProdutos.Columns["Valor"].DefaultCellStyle.Format = "C2";
        }

        private void dgvCarrinho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCarrinho.Columns["Valor_Unitario"].DefaultCellStyle.Format = "C2";
            dgvCarrinho.Columns["Valor_Total"].DefaultCellStyle.Format = "C2";
        }
    }
}
