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
                gbPagamento.Location = new Point(12, 460);
            }
            if (cbFormaEntrega.Text == "Retirada no Local")
            {
                gbEntrega.Height = 70;
                gbPagamento.Location = new Point(12, 360);
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
            CarregarDadosTaxas();
        }

        private void CarregarDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT id AS \"ID\"," +
                    " nome AS \"Nome\"," +
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
                dgvClientes.Columns["ID"].Visible = false;
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

        private void CarregarDadosTaxas()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT descricao from Taxa";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                cbTaxa.DataSource = dt;
                cbTaxa.DisplayMember = "descricao";

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

        private void CarregarValorTaxa()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = $"SELECT valor from Taxa where descricao like '{cbTaxa.Text}%'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    
                    txtValorTaxa.Text = leitor["valor"].ToString();
                    if (leitor != null)
                        leitor.Close();

                }

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

                sql = "SELECT id as \"ID\", " +
                    " descricao AS \"Descricao\"," +
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

        private void CarregarDadosCarrinho()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT carrinho.id_Produto as \"ID Produto\", " +
                   "p.descricao as \"Descricao\", " +
                   "carrinho.quantidade as \"Quantidade\", " +
                   "p.valor as \"Valor Unitario\", " +
                   "carrinho.valor_total as \"Valor Total\" " +
                   "from Carrinho as carrinho " +
                   "inner join Produto as p " +
                   $"on carrinho.id_produto = p.id where carrinho.id_cliente = '{dgvClientes.SelectedCells[0].Value}%'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvCarrinho.DataSource = ds;

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


        private void InserirDadosCliente()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Cliente VALUES " +
                      "(default,?,?,?,?,?,?,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("cep", txtCEP.Text);
                cmd.Parameters.AddWithValue("endereco", txtEnd.Text);
                cmd.Parameters.AddWithValue("numero", txtNumero.Text);
                cmd.Parameters.AddWithValue("bairro", txtBairro.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("estado", txtUf.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void AlterarDados()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "UPDATE Cliente " +
                    " SET nome=@nome," +
                    " telefone=@telefone," +
                    " cep=@cep," +
                    " endereco=@endereco," +
                    " numero=@numero," +
                    " bairro=@bairro," +
                    " cidade=@cidade," +
                    " estado=@estado " +
                    " WHERE id=@id";



                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("nome", txtNome.Text);
                cmd.Parameters.AddWithValue("telefone", txtTelefone.Text);
                cmd.Parameters.AddWithValue("cep", txtCEP.Text);
                cmd.Parameters.AddWithValue("endereco", txtEnd.Text);
                cmd.Parameters.AddWithValue("numero", txtNumero.Text);
                cmd.Parameters.AddWithValue("bairro", txtBairro.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("estado", txtUf.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro alterado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbPesquisar.Text))
            {
                (dgvClientes.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNome.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtTelefone.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtCEP.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtEnd.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtNumero.Text = dgvClientes.SelectedCells[5].Value.ToString();
            txtBairro.Text = dgvClientes.SelectedCells[6].Value.ToString();
            txtCidade.Text = dgvClientes.SelectedCells[7].Value.ToString();
            txtUf.Text = dgvClientes.SelectedCells[8].Value.ToString();

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
            if (string.IsNullOrEmpty(txtId.Text))
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Verifique os dados!");

                }
                else
                {
                    InserirDadosCliente();
                    CarregarDados();
                    InserirDadosCarrinho();
                    CarregarDadosCarrinho();
                }
            }
            else
            {
                AlterarDados();
                InserirDadosCarrinho();
                CarregarDadosCarrinho();



                CarregarDados();
            }

            
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
            dgvCarrinho.Columns["Valor Unitario"].DefaultCellStyle.Format = "C2";
            dgvCarrinho.Columns["Valor Total"].DefaultCellStyle.Format = "C2";
        }

        private void cbTaxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarValorTaxa();
        }

        private void InserirDadosCarrinho()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Carrinho VALUES " +
                      "(default,?,?,null,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id_cliente", dgvClientes.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("id_produto", dgvProdutos.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("quantidade", txtQuantidade.Text);
                cmd.Parameters.AddWithValue("valor_total", Convert.ToDecimal(dgvProdutos.SelectedCells[2].Value.ToString()) * Convert.ToInt32(txtQuantidade.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        //private void CarregarDadosVendas()
        //{
        //    MySqlConnection conn = instanciaMySql.GetConnection();
        //    try
        //    {
        //        if (conn.State == ConnectionState.Closed)
        //            conn.Open();

        //        sql = "SELECT dp.id_materiaPrima as \"ID Estoque\", " +
        //            "dp.descricao as \"Descricao\", " +
        //            "dp.quantidade as \"Quantidade\", " +
        //            "dp.valor as \"Valor Total\" " +
        //            "from detalheProduto as dp " +
        //            "inner join Produto as p " +
        //            $"on dp.id_produto = p.id where dp.id_produto = {txtId.Text}";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //        DataTable ds = new DataTable();
        //        da.Fill(ds);
        //        dgvIngredientes.DataSource = ds;



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();
        //    }

        //}
        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtCEP.Text = "";
            txtEnd.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
        }
    }
}
