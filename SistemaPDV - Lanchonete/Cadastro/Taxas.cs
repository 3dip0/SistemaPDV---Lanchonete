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

namespace SistemaPDV___Lanchonete.Cadastro
{
    public partial class Taxas : Form
    {

        MySQL instanciaMySql = new MySQL();
        string sql;
        public Taxas()
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

                sql = "INSERT INTO Taxa VALUES " +
                      "(default,?,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("valor", txtValor.Text.Replace(',', '.'));



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

                sql = "UPDATE Taxa " +
                    " SET descricao=@descricao," +
                    " valor=@valor" +
                    " WHERE id=@id";



                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("valor", txtValor.Text.Replace(',', '.'));
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
                    " valor AS \"Valor\" " +
                    " FROM Taxa";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvTaxas.DataSource = ds;



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
            foreach (DataGridViewColumn coluna in dgvTaxas.Columns)
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

                sql = "DELETE FROM Taxa WHERE id=@id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Taxa excluída com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtId.Text = dgvTaxas.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvTaxas.SelectedCells[1].Value.ToString();
            txtValor.Text = dgvTaxas.SelectedCells[2].Value.ToString();

            btnSalv.Visible = true;
            btnCancel.Visible = true;
            panelAdd.Enabled = true;
            btnNov.Visible = false;
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvTaxas.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvTaxas.SelectedCells[1].Value.ToString();
            txtValor.Text = dgvTaxas.SelectedCells[2].Value.ToString();

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
                   txtValor.Text = "";

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
               txtValor.Text = "";
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
            txtValor.Text = "";
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
            if (dgvTaxas.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvTaxas.SelectedCells[0].Value.ToString());
                string cliente = dgvTaxas.SelectedCells[1].Value.ToString();

                if (MessageBox.Show($"Confirma a exclusão da Taxa: {id} - {cliente}?",
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
                (dgvTaxas.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvTaxas.Columns["Valor"].DefaultCellStyle.Format = "C2";
        }
    }
}
