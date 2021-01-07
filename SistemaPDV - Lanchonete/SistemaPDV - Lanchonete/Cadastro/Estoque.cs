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
    public partial class Estoque : Form
    {
        MySQL instanciaMySql = new MySQL();
        string sql;
        public Estoque()
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

                sql = "INSERT INTO Estoque VALUES " +
                      "(null,?,?,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("quantidade", txtQtd.Text);
                cmd.Parameters.AddWithValue("valorUnitario", txtValorUnitario.Text.Replace(',', '.'));
                cmd.Parameters.AddWithValue("valorTotal", txtValorTotal.Text.Replace(',', '.'));
                


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

                sql = "UPDATE Estoque " +
                    " SET descricao=@descricao," +
                    " quantidade=@quantidade," +
                    " valorUnitario=@valorUnitario," +
                    " valorTotal=@valorTotal" +
                    " WHERE id=@id";



                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("quantidade", txtQtd.Text);
                cmd.Parameters.AddWithValue("valorUnitario", txtValorUnitario.Text.Replace(',', '.'));
                cmd.Parameters.AddWithValue("valorTotal", txtValorTotal.Text.Replace(',', '.'));
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
                    " descricao AS \"Descricao\"," +
                    " quantidade AS \"Quantidade\"," +
                    " valorUnitario AS \"Valor Unitario\"," +
                    " valorTotal AS \"Valor Total\" " +
                    " FROM Estoque";
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

                sql = "DELETE FROM Estoque WHERE id=@id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item excluído com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtId.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtQtd.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtValorUnitario.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtValorTotal.Text = dgvClientes.SelectedCells[4].Value.ToString();
          
            btnSalv.Visible = true;
            btnCancel.Visible = true;
            panelAdd.Enabled = true;
            btnNov.Visible = false;
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtQtd.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtValorUnitario.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtValorTotal.Text = dgvClientes.SelectedCells[4].Value.ToString();

            btnSalv.Visible = true;
            btnCancel.Visible = true;
            panelAdd.Enabled = true;
            btnNov.Visible = false;
        }

        private void btnSalv_Click(object sender, EventArgs e)
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
                    txtValorUnitario.Text = "";
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
                txtValorUnitario.Text = "";
                txtValorTotal.Text = "";
                CarregarDados();
            }
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
            txtValorUnitario.Text = "";
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
            if (dgvClientes.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvClientes.SelectedCells[0].Value.ToString());
                string cliente = dgvClientes.SelectedCells[1].Value.ToString();

                if (MessageBox.Show($"Confirma a exclusão do Item: {id} - {cliente}?",
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
                (dgvClientes.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtValorUnitario_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtValorUnitario.Text) && !string.IsNullOrEmpty(txtQtd.Text))
                {
                    decimal valorTotal = Convert.ToDecimal(txtValorUnitario.Text) * Convert.ToInt32(txtQtd.Text);

                    txtValorTotal.Text = valorTotal.ToString();
                }
                else
                {
                    txtValorTotal.Text = "";
                }
            }
        }

        private void txtValorTotal_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtValorTotal.Text) && !string.IsNullOrEmpty(txtQtd.Text))
                {
                    decimal valorUnitario = Convert.ToDecimal(txtValorTotal.Text) / Convert.ToInt32(txtQtd.Text);

                    txtValorUnitario.Text = valorUnitario.ToString();
                }
                else
                {
                    txtValorTotal.Text = "";
                }
            }

        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            dgvClientes.Columns["Valor Total"].DefaultCellStyle.Format = "C2";
            dgvClientes.Columns["Valor Unitario"].DefaultCellStyle.Format = "C2";
        }

        private void Estoque_Load(object sender, EventArgs e)
        {
            

        }

 
    }
}
