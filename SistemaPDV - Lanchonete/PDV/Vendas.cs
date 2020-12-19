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
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            
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
            CarregarDadosTaxas();
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
            t = new List<Carrinho>();
            CarregarDados();
            CarregarDadosProdutos();
            PreencherComboBoxPesquisa();
            CarregarDadosTaxas();

            dgvCarrinho.ColumnCount = 4;
            //Informo os nomes das colunas do dataGridView
            dgvCarrinho.Columns[0].Name = "Produto";
            dgvCarrinho.Columns[1].Name = "Quantidade";
            dgvCarrinho.Columns[2].Name = "Valor_Unitario";
            dgvCarrinho.Columns[3].Name = "Valor_Total";

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
            if(cbFormaEntrega.Text=="Retirada no Local")
            {
                cbTaxa.Items.Add("Nenhuma");
            }
            else
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
                    txtValorTaxa.Text = string.Format("{0:C}", Convert.ToDouble(leitor["valor"].ToString()));
                    
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

        private void CarregarGrid()
        {
            dgvCarrinho.DataSource = t;
            dgvCarrinho.Refresh();
        }
        private void btnAddProduto_Click(object sender, EventArgs e)
        {

            Boolean naoExiste = true;
            foreach (DataGridViewRow row in dgvCarrinho.Rows)
            {

                if (row.Cells["Produto"].Value.ToString().Equals(dgvProdutos.SelectedCells[0].Value.ToString()))
                {
                    
                        MessageBox.Show("Produto já está adicionado!");
                        naoExiste = false;

                        break;
                    

                }
                else
                {
                    naoExiste = true;
                   
                    
                }

            }
            if (naoExiste == true)
            {
                dgvCarrinho.Rows.Add(
                dgvProdutos.SelectedCells[0].Value.ToString(),
                txtQuantidade.Text,
                Convert.ToDecimal(dgvProdutos.SelectedCells[1].Value.ToString()),
                Convert.ToDecimal(dgvProdutos.SelectedCells[1].Value.ToString()) * Convert.ToInt32(txtQuantidade.Text));
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
            dgvCarrinho.Columns["Valor_Unitario"].DefaultCellStyle.Format = "C2";
            dgvCarrinho.Columns["Valor_Total"].DefaultCellStyle.Format = "C2";
            dgvCarrinho.Columns["Produto"].ReadOnly = true;
            dgvCarrinho.Columns["Valor_Unitario"].ReadOnly = true;
            dgvCarrinho.Columns["Valor_Total"].ReadOnly = true;

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

        private void dgvCarrinho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvCarrinho_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvCarrinho.CurrentRow.Cells[3].Value = Convert.ToDecimal(dgvCarrinho.CurrentRow.Cells[2].Value) * Convert.ToInt32(dgvCarrinho.CurrentRow.Cells[1].Value);
        }

        private void dgvCarrinho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCarrinho.BeginEdit(true);
        }

        private void btnEditIngred_Click(object sender, EventArgs e)
        {
           
            dgvCarrinho.BeginEdit(true);
        }
        decimal troco;
        private void txtTroco_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTroco_Leave(object sender, EventArgs e)
        {
            if (char.IsDigit(txtTroco.Text[0]))
            {
                troco = Convert.ToDecimal(txtTroco.Text.Replace("R", "").Replace("$", ""));


                txtTroco.Text = string.Format("{0:C}", Convert.ToDouble(troco.ToString()));
            }

           
                       
        }

        private void txtTroco_Click(object sender, EventArgs e)
        {
            txtTroco.SelectAll();
        }

        private void txtQuantidade_Click(object sender, EventArgs e)
        {
            txtQuantidade.SelectAll();
        }

        private void txtPesquisar_Click(object sender, EventArgs e)
        {
            txtPesquisar.SelectAll();
        }

        private void txtNome_Click(object sender, EventArgs e)
        {
            txtNome.SelectAll();
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            
                txtTelefone.Select();
            
                txtTelefone.SelectAll();

        }

        private void txtCEP_Click(object sender, EventArgs e)
        {

            txtCEP.Select();

            txtCEP.SelectAll();
        }

        private void txtEnd_Click(object sender, EventArgs e)
        {
            txtEnd.SelectAll();
        }

        private void txtNumero_Click(object sender, EventArgs e)
        {
            txtNumero.SelectAll();
        }

        private void txtBairro_Click(object sender, EventArgs e)
        {
            txtBairro.SelectAll();
        }

        private void txtCidade_Click(object sender, EventArgs e)
        {
            txtCidade.SelectAll();
        }

        private void txtUf_Click(object sender, EventArgs e)
        {
            txtUf.SelectAll();
        }
    }
}
