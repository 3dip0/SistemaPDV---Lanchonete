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
    public partial class Categorias : Form
    {

        MySQL instanciaMySql = new MySQL();
        string sql;
        public Categorias()
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

                sql = "INSERT INTO Categoria VALUES " +
                      "(default,?);";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);



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

                sql = "UPDATE Categoria " +
                    " SET descricao=@descricao " +
                    " WHERE id=@id";



                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("descricao", txtDescricao.Text);
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

                sql = "SELECT *FROM Categoria";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvCategorias.DataSource = ds;



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
            foreach (DataGridViewColumn coluna in dgvCategorias.Columns)
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

                sql = "DELETE FROM Categoria WHERE id=@id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Categoria excluída com sucesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtId.Text = dgvCategorias.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvCategorias.SelectedCells[1].Value.ToString();

            btnSalv.Visible = true;
            btnCancel.Visible = true;
            panelAdd.Enabled = true;
            btnNov.Visible = false;
        }

        private void dgvCategorias_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgvCategorias.SelectedCells[0].Value.ToString();
            txtDescricao.Text = dgvCategorias.SelectedCells[1].Value.ToString();

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
            if (dgvCategorias.SelectedRows.Count > 0)
            {

                int id = Convert.ToInt32(dgvCategorias.SelectedCells[0].Value.ToString());
                string cliente = dgvCategorias.SelectedCells[1].Value.ToString();

                if (MessageBox.Show($"Confirma a exclusão da Categoria: {id} - {cliente}?",
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
                (dgvCategorias.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert({0}, 'System.String') LIKE '%{1}%'", cbPesquisar.Text, txtPesquisar.Text);
            }
        }

        private void dgvCategorias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCategorias.Columns["Valor"].DefaultCellStyle.Format = "C2";
        }
    }
}
