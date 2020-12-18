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
    public partial class Produtos : Form
    {
        SQL instanciaMySql = new SQL();
        string sql;

        public Produtos()
        {
            InitializeComponent();
            CarregarDados();
            PreencherComboBoxPesquisa();
        }

        private void InserirDados()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO Produto VALUES " +
                      "(null,?,?,?);";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("quantidade", txtQtd.Text);
                cmd.Parameters.AddWithValue("valor", txtValorTotal.Text.Replace(',', '.'));



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
            SQLiteConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "UPDATE Produto " +
                    " SET descricao=@descricao," +
                    " quantidade=@quantidade," +
                    " valor=@valor" +
                    " WHERE id=@id";



                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("quantidade", txtQtd.Text);
                cmd.Parameters.AddWithValue("valor", txtValorTotal.Text.Replace(',', '.'));
                cmd.Parameters.AddWithValue("id", txtId.Text);

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


        private void CarregarDados()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT id AS ID," +
                    " descricao AS \"Descricao\"," +
                    " quantidade AS \"Quantidade\"," +
                    " valor AS \"Valor Venda\" " +
                    " FROM Produto";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
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

        private void InserirDadosIngredientes()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "INSERT INTO detalheProduto (id, id_produto, id_materiaPrima, descricao, quantidade, valor) VALUES " +
                      "(null,?,?,?,?,?);";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("id_produto", txtId.Text);
                cmd.Parameters.AddWithValue("id_materiaPrima", txtIDIngredientes.Text);
                cmd.Parameters.AddWithValue("descricao", cbIngredientes.Text);
                cmd.Parameters.AddWithValue("quantidade", txtIngQtd.Text);
                cmd.Parameters.AddWithValue("valor", txtIngTotal.Text.Replace(',', '.'));




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


        private void AlterarDadosIngredientes()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "UPDATE detalheProduto " +
                    " SET descricao=@descricao," +
                    " quantidade=@quantidade," +
                    " valor=@valor" +
                    " WHERE id_materiaPrima=@id_materiaPrima";



                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", cbIngredientes.Text);
                cmd.Parameters.AddWithValue("quantidade", txtIngQtd.Text);
                cmd.Parameters.AddWithValue("valor", txtIngTotal.Text.Replace(',', '.'));
                cmd.Parameters.AddWithValue("id_materiaPrima", txtIDIngredientes.Text);

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

        private void CarregarDadosIngredientes()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT dp.id_materiaPrima as \"ID Estoque\", " +
                    "dp.descricao as \"Descricao\", " +
                    "dp.quantidade as \"Quantidade\", " +
                    "dp.valor as \"Valor Total\" " +
                    "from detalheProduto as dp " +
                    "inner join Produto as p " +
                    $"on dp.id_produto = p.id where dp.id_produto = {txtId.Text}";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvIngredientes.DataSource = ds;



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
            foreach (DataGridViewColumn coluna in dgvProdutos.Columns)
            {
                cbPesquisar.Items.Add(coluna.HeaderText);
            }
        }

        private void PreencherComboBoxIngredientes()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT id, descricao FROM Estoque";

               
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
               
                DataTable ds = new DataTable();
                da.Fill(ds);
                cbIngredientes.ValueMember = "id";
                cbIngredientes.DisplayMember = "descricao";
                cbIngredientes.DataSource = ds;
                preencheTxtIDIngredientes();



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

        private void PreencherComboBoxIngredientesEdit()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = $"SELECT id_materiaPrima, descricao, quantidade, valor FROM detalheProduto where id_materiaPrima LIKE '{dgvIngredientes.SelectedCells[0].Value}%'";


                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

                DataTable ds = new DataTable();
                da.Fill(ds);
                cbIngredientes.ValueMember = "id";
                cbIngredientes.DisplayMember = "descricao";
                cbIngredientes.DataSource = ds;
                preencheTxtIDIngredientes();



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

        private void preencheTxtIDIngredientes()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = $"SELECT id FROM Estoque where descricao LIKE '{cbIngredientes.Text}%'";


                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    txtIDIngredientes.Text = leitor["id"].ToString();

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

        private void mostraIDProduto()
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = $"SELECT id FROM Produto where descricao LIKE '{txtDescricao.Text}%'";


                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    txtId.Text = leitor["id"].ToString();

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

        private void preencheTxtValorUnitario()
        {
            if (!string.IsNullOrEmpty(cbIngredientes.Text))
            {
                SQLiteConnection conn = instanciaMySql.GetConnection();
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    sql = $"SELECT valorUnitario FROM Estoque where id LIKE '{txtIDIngredientes.Text}%'";


                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader leitor = cmd.ExecuteReader();
                    if (leitor.HasRows)
                    {
                        leitor.Read();
                        txtIngUnitario.Text = leitor["valorUnitario"].ToString();

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
        }

        private void preencheEditor()
        {
            
           
                SQLiteConnection conn = instanciaMySql.GetConnection();
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    sql = $"SELECT id_materiaPrima, descricao, quantidade, valor FROM detalheProduto where id_materiaPrima LIKE '{dgvIngredientes.SelectedCells[0].Value}%'";


                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    SQLiteDataReader leitor = cmd.ExecuteReader();
                    if (leitor.HasRows)
                    {
                        leitor.Read();
                        txtIDIngredientes.Text = leitor["id_materiaPrima"].ToString();
                    txtIngQtd.Text = leitor["quantidade"].ToString();
                        txtIngTotal.Text = leitor["valor"].ToString();
                        
                        if (leitor != null)
                            leitor.Close();

                    }
                PreencherComboBoxIngredientesEdit();
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

        private void ExcluirDados(int id)
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "DELETE FROM Produto WHERE id=@id;";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto excluído com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ExcluirDadosIngredientes(int id)
        {
            SQLiteConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "DELETE FROM detalheProduto WHERE id_materiaPrima=@id;";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ingrediente excluído com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtId.Text = dgvProdutos.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvProdutos.SelectedCells[1].Value.ToString();
            txtQtd.Text = dgvProdutos.SelectedCells[2].Value.ToString();
            txtValorTotal.Text = dgvProdutos.SelectedCells[3].Value.ToString();
            CarregarDadosIngredientes();

            btnSalv.Visible = true;
            btnCancel.Visible = true;
            panelAdd.Enabled = true;
            btnNov.Visible = false;
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvProdutos.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvProdutos.SelectedCells[1].Value.ToString();
            txtQtd.Text = dgvProdutos.SelectedCells[2].Value.ToString();
            txtValorTotal.Text = dgvProdutos.SelectedCells[3].Value.ToString();

            btnSalv.Visible = true;
            btnCancel.Visible = true;
            panelAdd.Enabled = true;
            btnNov.Visible = false;
        }

        private void salvar()
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Verifique os dados!");

                }
                else
                {
                    InserirDados();
                    btnSalv.Visible = false;
                    btnCancel.Visible = false;
                    panelAdd.Enabled = false;
                    btnNov.Visible = true;


                    txtId.Text = "";
                    txtDescricao.Text = "";
                    txtQtd.Text = "";
                    txtValorTotal.Text = "";

                    CarregarDados();
                }
            }
            else
            {
                AlterarDados();
                btnSalv.Visible = false;
                btnCancel.Visible = false;
                panelAdd.Enabled = false;
                btnNov.Visible = true;


                txtId.Text = "";
                txtDescricao.Text = "";
                txtQtd.Text = "";
                txtValorTotal.Text = "";
                CarregarDados();
            }
        }



        private void btnSalv_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSalv.Visible = false;
            btnCancel.Visible = false;
            panelAdd.Enabled = false;
            btnNov.Visible = true;

            txtId.Text = "";
            txtDescricao.Text = "";
            txtQtd.Text = "";
            txtValorTotal.Text = "";
        }

        private void btnNov_Click(object sender, EventArgs e)
        {
            panelAdd.Enabled = true;
            btnSalv.Visible = true;
            btnCancel.Visible = true;
            btnNov.Visible = false;

        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvProdutos.SelectedCells[0].Value.ToString());
                string cliente = dgvProdutos.SelectedCells[1].Value.ToString();

                if (MessageBox.Show($"Confirma a exclusão do Cliente: {id} - {cliente}?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ExcluirDados(id);
                    CarregarDados();

                }

            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbPesquisar.Text))
            {
                (dgvProdutos.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }


        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            dgvProdutos.Columns["Valor Venda"].DefaultCellStyle.Format = "C2";
          
        }



        private void btnAddIngred_Click(object sender, EventArgs e)
        {
           
                btnSalvarIngred.Visible = true;
                btnCancelIngred.Visible = true;
                btnAddIngred.Visible = false;
                panelIngredientes.Enabled = true;
            txtIngQtd.Text = "";
            txtIngTotal.Text = "";



            if (string.IsNullOrEmpty(txtId.Text))
                {
                    if (txtDescricao.Text == "")
                    {
                        MessageBox.Show("Verifique os dados!");

                    }
                    else
                    {
                    foreach (DataGridViewRow row in dgvProdutos.Rows)
                    {
                        if (!row.Cells["ID"].Value.ToString().ToLower().Equals(txtId.Text))
                        {
                            InserirDados();
                            CarregarDados();
                            break;
                        }
                    }
                    
                    }
                }
                
                mostraIDProduto();

                PreencherComboBoxIngredientes();
                CarregarDadosIngredientes();
                preencheTxtValorUnitario();

            

        }

        private void btnSalvarIngred_Click(object sender, EventArgs e)
        {
            Boolean naoExiste = false;
            if (string.IsNullOrEmpty(txtIngQtd.Text) || Convert.ToInt32(txtIngQtd.Text) < 1)
            {
                txtIngQtd.BackColor = Color.Red;
               
            }
            
            else
            {
                if (dgvIngredientes.RowCount == 0)
                {
                    txtIngQtd.BackColor = Color.White;
                    InserirDadosIngredientes();
                    btnAddIngred.Visible = true;
                    btnSalvarIngred.Visible = false;
                    btnCancelIngred.Visible = false;
                    panelIngredientes.Enabled = false;
                    txtIngQtd.Text = "";

                    CarregarDadosIngredientes();
                }

                else
                {
                    foreach (DataGridViewRow row in dgvIngredientes.Rows)
                    {

                        if (row.Cells["ID Estoque"].Value.ToString().ToLower().Equals(txtIDIngredientes.Text))
                        {
                            if (btnEditIngred.Visible == false)
                            {
                                AlterarDadosIngredientes();
                                btnEditIngred.Visible = true;
                                btnAddIngred.Visible = true;
                                btnSalvarIngred.Visible = false;
                                btnCancelIngred.Visible = false;
                                panelIngredientes.Enabled = false;
                                naoExiste = false;
                                CarregarDadosIngredientes();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Ingrediente já está adicionado!");
                                naoExiste = false;

                                break;
                            }
                           
                        }
                        else
                        {
                            naoExiste = true;
                         
                        }
                       
                    }
                    if(naoExiste==true)
                    {
                        txtIngQtd.BackColor = Color.White;
                        InserirDadosIngredientes();
                        btnAddIngred.Visible = true;
                        btnSalvarIngred.Visible = false;
                        btnCancelIngred.Visible = false;
                        panelIngredientes.Enabled = false;
                        txtIngQtd.Text = "";

                        CarregarDadosIngredientes();
                    }
                   
                }
            }
            
        }

        private void btnEditIngred_Click(object sender, EventArgs e)
        {
            btnSalvarIngred.Visible = true;
            btnCancelIngred.Visible = true;
            btnEditIngred.Visible = false;
            btnAddIngred.Visible = false;
            panelIngredientes.Enabled = true;
            preencheEditor();
            
            

        }

        private void btnCancelIngred_Click(object sender, EventArgs e)
        {
            btnAddIngred.Visible = true;
            btnSalvarIngred.Visible = false;
            btnCancelIngred.Visible = false;
            panelIngredientes.Enabled = false;
            btnEditIngred.Visible = true;
            txtIngQtd.BackColor = Color.White;
        }

        private void cbIngredientes_TextChanged(object sender, EventArgs e)
        {
            preencheTxtIDIngredientes();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIngUnitario.Text) && !string.IsNullOrEmpty(txtIngQtd.Text))
            {
                decimal valorTotal = Convert.ToDecimal(txtIngUnitario.Text) * Convert.ToInt32(txtIngQtd.Text);

                txtIngTotal.Text = valorTotal.ToString();
            }
            else
            {
                txtIngTotal.Text = "";
            }
        }

        private void cbIngredientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            preencheTxtValorUnitario();
        }

        private void btnExcIngred_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvIngredientes.SelectedCells[0].Value.ToString());
                string ingrediente = dgvIngredientes.SelectedCells[1].Value.ToString();

                if (MessageBox.Show($"Confirma a exclusão do Ingrediente: {id} - {ingrediente}?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ExcluirDadosIngredientes(id);
                    CarregarDadosIngredientes();

                }

            }
        }
    }
}
