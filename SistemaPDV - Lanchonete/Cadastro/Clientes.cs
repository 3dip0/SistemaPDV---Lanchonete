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


namespace SistemaPDV___Lanchonete.Cadastro
{
    public partial class Clientes : Form
    {

        MySQL instanciaMySql = new MySQL();
        string sql;
        public Clientes()
        {
            InitializeComponent();
            CarregarDados();
            PreencherComboBoxPesquisa();
        }


        private void InserirDados()
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
                cmd.Parameters.AddWithValue("telefone", txtFone.Text);
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
                cmd.Parameters.AddWithValue("telefone", txtFone.Text);
                cmd.Parameters.AddWithValue("cep", txtCEP.Text);
                cmd.Parameters.AddWithValue("endereco", txtEnd.Text);
                cmd.Parameters.AddWithValue("numero", txtNumero.Text);
                cmd.Parameters.AddWithValue("bairro", txtBairro.Text);
                cmd.Parameters.AddWithValue("cidade", txtCidade.Text);
                cmd.Parameters.AddWithValue("estado", txtUf.Text);
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
            MySqlConnection conn = instanciaMySql.GetConnection();
            try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    sql = "SELECT id AS ID," +
                        " nome AS \"Nome\"," +
                        " telefone AS \"Telefone\"," +
                        " cep AS \"CEP\"," +
                        " endereco AS \"Endereco\"," +
                        " numero AS \"Numero\"," +
                        " bairro AS \"Bairro\"," +
                        " cidade AS \"Cidade\"," +
                        " estado AS \"UF\" " +
                        " FROM Cliente";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    dgvClientes.DataSource = ds;

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
        }

        private void ExcluirDados(int id)
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "DELETE FROM Cliente WHERE id=@id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtId.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNome.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtFone.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtCEP.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtEnd.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtNumero.Text = dgvClientes.SelectedCells[5].Value.ToString();
            txtBairro.Text = dgvClientes.SelectedCells[6].Value.ToString();
            txtCidade.Text = dgvClientes.SelectedCells[7].Value.ToString();
            txtUf.Text = dgvClientes.SelectedCells[8].Value.ToString();
            btnSalvar.Visible = true;
            btnCancelar.Visible = true;
            panelAdd.Enabled = true;
            btnNovo.Visible = false;
            
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbPesquisar.Text))
            {
                (dgvClientes.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                if (txtNome.Text == "")
                {
                    MessageBox.Show("Verifique os dados!");
                    
                }
                else
                {
                    InserirDados();
                    btnSalvar.Visible = false;
                    btnCancelar.Visible = false;
                    panelAdd.Enabled = false;
                    btnNovo.Visible = true;


                    txtId.Text = "";
                    txtNome.Text = "";
                    txtFone.Text = "";
                    txtCEP.Text = "";
                    txtEnd.Text = "";
                    txtNumero.Text = "";
                    txtCidade.Text = "";
                    txtUf.Text = "";
                    CarregarDados();
                }
            }
            else
            {
                AlterarDados();
                btnSalvar.Visible = false;
                btnCancelar.Visible = false;
                panelAdd.Enabled = false;
                btnNovo.Visible = true;


                txtId.Text = "";
                txtNome.Text = "";
                txtFone.Text = "";
                txtCEP.Text = "";
                txtEnd.Text = "";
                txtNumero.Text = "";
                txtCidade.Text = "";
                txtUf.Text = "";
                CarregarDados();
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnSalvar.Visible = false;
            btnCancelar.Visible = false;
            panelAdd.Enabled = false;
            btnNovo.Visible = true;

            txtId.Text = "";
            txtNome.Text = "";
            txtFone.Text = "";
            txtCEP.Text = "";
            txtEnd.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelAdd.Enabled = true;
            btnSalvar.Visible = true;
            btnCancelar.Visible = true;
            btnNovo.Visible = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
                string cliente = dgvClientes.SelectedCells[1].Value.ToString();

                if (MessageBox.Show($"Confirma a exclusão do Cliente: {id} - {cliente}?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ExcluirDados(id);
                    CarregarDados();

                }

            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNome.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtFone.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtCEP.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtEnd.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtNumero.Text = dgvClientes.SelectedCells[5].Value.ToString();
            txtBairro.Text = dgvClientes.SelectedCells[6].Value.ToString();
            txtCidade.Text = dgvClientes.SelectedCells[7].Value.ToString();
            txtUf.Text = dgvClientes.SelectedCells[8].Value.ToString();
            btnSalvar.Visible = true;
            btnCancelar.Visible = true;
            panelAdd.Enabled = true;
            btnNovo.Visible = false;
        }
    }
}
