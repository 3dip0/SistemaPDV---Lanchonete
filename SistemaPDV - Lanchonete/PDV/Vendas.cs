using MySql.Data.MySqlClient;
using SistemaPDV___Lanchonete.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPDV___Lanchonete
{
    public partial class Vendas : Form
    {

        List<Carrinho> t { get; set; }
        MySQL instanciaMySql = new MySQL();
        
        int idCarrinho;
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
            InserirDadosIncompletosVendas();
            CarregarIDUltimaVenda();

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
                cbTaxa.DataSource = null;
                cbTaxa.Items.Add("Nenhuma");
                txtValorTaxa.Text = "";
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

                sql = "SELECT id AS \"ID\"," +
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
                   $"on carrinho.id_produto = p.id where carrinho.id_venda = '{lblNVenda.Text}%'";
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
        

private void CarregarIDUltimaVenda()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = $"select* from Venda where id = (select max(id) from Venda)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    lblNVenda.Text = leitor["id"].ToString();

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

        private void PuxarVendas()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "select * from Venda order by numero_venda desc limit 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    ultimavenda =  Convert.ToInt32(leitor["numero_venda"].ToString());

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

        private void InserirDadosIncompletosVendas()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Venda VALUES " +
                      "(default,null,null,null,null,null,null,null,null);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                
                
                cmd.ExecuteNonQuery();
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
        int ultimavenda=0;

        private void FinalizarVenda()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Venda VALUES " +
                      "(default,?,?,?,?,?,?,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id_cliente", txtId.Text);
                cmd.Parameters.AddWithValue("taxa", txtValorTaxa.Text.Replace("R", "").Replace("$",""));
                cmd.Parameters.AddWithValue("numero_venda", ultimavenda=ultimavenda+1);
                cmd.Parameters.AddWithValue("formaEntrega", cbFormaEntrega.Text);
                cmd.Parameters.AddWithValue("formaPagamento", cbPagamento.Text);
                cmd.Parameters.AddWithValue("troco", txtTroco.Text.Replace("R", "").Replace("$", ""));
                cmd.Parameters.AddWithValue("sub_total", txtSubTotal.Text.Replace("R", "").Replace("$", ""));
                cmd.Parameters.AddWithValue("valor_total", txtValorTotal.Text.Replace("R", "").Replace("$", ""));

                cmd.ExecuteNonQuery();
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

        private void AlterarDadosVendas()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "UPDATE Venda " +
                    " SET id_cliente=@id_carinho," +
                    " id_carrinho=@id_carrinho," +
                    " valor=@valor," +
                    " taxa_entrega=@taxa_entrega," +
                    " valor_total=@valor_total," +
                    " numero_venda=@numero_venda," +
                    " WHERE id=@id";



                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id_cliente", txtId.Text);
                cmd.Parameters.AddWithValue("id_carrinho", txtTelefone.Text);
                cmd.Parameters.AddWithValue("valor", txtCEP.Text);
                cmd.Parameters.AddWithValue("taxa_entrega", txtEnd.Text);
                cmd.Parameters.AddWithValue("valor_total", txtNumero.Text);
                cmd.Parameters.AddWithValue("numero_venda", txtBairro.Text);
                cmd.Parameters.AddWithValue("id", lblNVenda.Text);

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
            InserirDadosIncompletosVendas();
            //CarregarValorVendas();
            
            Boolean naoExiste = true;
            foreach (DataGridViewRow row in dgvCarrinho.Rows)
            {

                if (row.Cells["ID Produto"].Value.ToString().Equals(dgvProdutos.SelectedCells[0].Value.ToString()))
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
                InserirDadosCarrinho();
                CarregarDadosCarrinho();
            }

            calculaValorTotalGrid();

        }

        private decimal ValorTotal()
        {
            decimal total = 0;
            int i = 0;
            decimal taxa = 0;
            for (i = 0; i < dgvCarrinho.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(dgvCarrinho.Rows[i].Cells["Valor Total"].Value);
            }
            if (string.IsNullOrEmpty(txtValorTaxa.Text))
            {
                
                taxa = 0;
            }
            else
            {
                taxa = Convert.ToDecimal(txtValorTaxa.Text.Replace("R", "").Replace("$", ""));
            }

            return total + taxa;
        }
        private decimal ValorSubTotal()
        {
            decimal Subtotal = 0;
            int i = 0;
       
            for (i = 0; i < dgvCarrinho.Rows.Count; i++)
            {
                Subtotal = Subtotal + Convert.ToDecimal(dgvCarrinho.Rows[i].Cells["Valor Total"].Value);
            }
         

            return Subtotal;
        }

       
        private void calculaValorTotalGrid()
        {
            if (dgvCarrinho.Rows.Count > 0)
                txtSubTotal.Text = ValorSubTotal().ToString("c");
            txtValorTotal.Text = ValorTotal().ToString("c");

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
            dgvCarrinho.Columns["Descricao"].ReadOnly = true;
            dgvCarrinho.Columns["Valor Unitario"].ReadOnly = true;
            dgvCarrinho.Columns["Valor Total"].ReadOnly = true;

        }

        private void cbTaxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarValorTaxa();
            calculaValorTotalGrid();
        }

        private void InserirDadosCarrinho()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Carrinho VALUES " +
                      "(default,?,?,?,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id_cliente", dgvClientes.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("id_produto", dgvProdutos.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("id_venda", lblNVenda.Text);
                cmd.Parameters.AddWithValue("quantidade", txtQuantidade.Text);
                cmd.Parameters.AddWithValue("valor_total", Convert.ToDecimal(dgvProdutos.SelectedCells[2].Value.ToString()) * Convert.ToInt32(txtQuantidade.Text));
                cmd.ExecuteNonQuery();

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
            PuxarVendas();
            FinalizarVenda();

            ImpressaoPedido impressaoPedido = new ImpressaoPedido();
            impressaoPedido.lblCliente.Text = txtNome.Text;
            impressaoPedido.lblEnd.Text = txtEnd.Text;
            impressaoPedido.lblNumero.Text = txtNumero.Text;
            impressaoPedido.lblBairro.Text = txtBairro.Text;
            impressaoPedido.lblTaxa.Text = txtValorTaxa.Text;
            impressaoPedido.lblSub.Text = txtSubTotal.Text;
            impressaoPedido.lblTotal.Text = txtValorTotal.Text;
            impressaoPedido.lblPedido.Text = ultimavenda.ToString();

            impressaoPedido.dgvItens.DataSource = dgvCarrinho.DataSource;
            impressaoPedido.dgvItens.Columns["ID Produto"].Visible = false;
            impressaoPedido.dgvItens.Columns["Valor Unitario"].Visible = false;
            impressaoPedido.dgvItens.Columns["Valor Total"].DefaultCellStyle.Format = "C2";
            impressaoPedido.ShowDialog();

            
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
            dgvCarrinho.CurrentRow.Cells[4].Value = Convert.ToDecimal(dgvCarrinho.CurrentRow.Cells[3].Value) * Convert.ToInt32(dgvCarrinho.CurrentRow.Cells[2].Value);
            calculaValorTotalGrid();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
