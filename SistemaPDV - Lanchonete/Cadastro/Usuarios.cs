using SistemaPDV___Lanchonete.Classes;
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
    public partial class Usuarios : Form
    {
        SQL instanciaMySql = new SQL();
        string sql;
        int nivel;
        public Usuarios()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
          
            SQLiteConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT id AS ID," +
                    " usuario AS \"Usuario\"," +
                    " nivel AS \"Nivel\" " +
                    " FROM Usuario";
                

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                dgvUsuarios.DataSource = ds;
                
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja apagar este usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string nomeUsuario;
                using (var connection = new SQLiteConnection("Data Source=lanche"))
                {

                    foreach (DataGridViewRow row in dgvUsuarios.Rows)
                    {


                        try
                        {

                            connection.Open();

                           
                                DataTable dt = new DataTable();
                                nomeUsuario = Convert.ToString(row.Cells[1].Value);


                                SQLiteDataAdapter adapter;
                                SQLiteDataAdapter adapter2;

                                string delete = "";
                                string select;


                                delete = $"DELETE FROM Usuario ";

                                select = $"select usuario from Usuario";


                                try
                                {


                                    if (nomeUsuario != UsuarioLogado.NomeUsuario)
                                    {
                                        adapter = new SQLiteDataAdapter($"{delete} where Usuario = '{nomeUsuario}'", connection);
                                        

                                        dt = new System.Data.DataTable("lanche");

                                        adapter.Fill(dt);
                                    CarregarDados();
                                }
                                    else
                                    {
                                        MessageBox.Show("Não é possivel excluir o usuário que está logado atualmente!");
                                    }
                                }
                                catch (Exception erro)
                                {
                                    MessageBox.Show(erro.Message);
                                }

                            
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                                connection.Close();
                        }
                    }

                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=lanche"))
            {
                var command = connection.CreateCommand();

                try
                {
                    connection.Open();
                  
                    if (usuario.Text != UsuarioLogado.NomeUsuario)
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter($"INSERT INTO Usuario values (null, '{usuario.Text}', '{senha.Text}', '{tipo.Text}')", connection);
                        dt = new System.Data.DataTable("lanche");
                        //Preenche a DataTable com os dados do adaptar     
                        try
                        {
                            adapter.Fill(dt);
                            MessageBox.Show("Usuário criado com sucesso!");
                            CarregarDados();
                        }
                        catch
                        {
                            MessageBox.Show("Falha ao criar o usuário!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuário já existe!");
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
