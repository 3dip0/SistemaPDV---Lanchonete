﻿using MySql.Data.MySqlClient;
using SistemaPDV___Lanchonete.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SMS.Core.SMS;


namespace SistemaPDV___Lanchonete
{
    public partial class Monitor : Form
    {
        MySQL instanciaMySql = new MySQL();

        string sql;

        int i;
        int thread = 0;
        public Monitor()
        {
            InitializeComponent();
            CarregarDadosPedidoAceito();
            if (dgvVendas.SelectedRows.Count > 0)
            {
                
                int index = dgvVendas.SelectedRows[0].Index;

                if (index >= 0)
                    dgvVendas.Rows[index].Selected = false;
            }
        }
        const int SC_CLOSE = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);







        SMS.Core.SMS sms = new SMS.Core.SMS();
        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int CountMenu = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, CountMenu, SC_CLOSE);
            LimparNumerosPedido();
            CarregarDadosPedidoAceito();
            backgroundWorker1.RunWorkerAsync();
            
            DateTime dateTime = DateTime.Today;

            lblAceitos.Text = $"Pedidos Aceitos: {dateTime.Day.ToString("00")}/{dateTime.Month.ToString("00")}/{dateTime.Year}";
        }
       



        SoundPlayer simpleSound;

        int pedido = 0;
        int numeroPedido;
        int numeroPedidoUpdate;


        private void CarregarDados()
        {

            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT " +
                    "venda.numero_venda_site as \"Numero Pedido\", " +
                    "cliente.nome as \"Nome\", " +
                    "cliente.telefone as \"Telefone\", " +
                   "cliente.endereco as \"Endereco\", " +
                   "cliente.numero as \"Numero\", " +
                   "cliente.bairro as \"Bairro\", " +
                   "venda.formaPagamento as \"Forma de Pagamento\", " +
                   "venda.formaEntrega as \"Forma de Entrega\", " +
                   "venda.troco as \"Troco\", " +
                   "venda.sub_total as \"Sub Total\", " +
                   "venda.valor_total as \"Valor Total\", " +
                   "venda.valorTroco as \"Valor do Troco\", " +
                   "venda.taxa_entrega as \"Taxa de Entrega\", " +
                   "venda.pedidoAceito as \"Status Pedido\" " +
                   "from Venda as venda " +
                   "inner join Cliente as cliente " +
                   $"on venda.id_cliente = cliente.id where venda.pedidoAceito=0 order by venda.numero_venda_site desc";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count != 0)
                {
                    try
                    {
                        dgvVendas.Invoke((Action)(() => dgvVendas.DataSource = ds));
                        dgvVendas.Invoke((Action)(() => dgvVendas.ClearSelection()));

                        dgvVendas.Invoke((Action)(() => i = dgvVendas.Rows.Count));
                    }
                    catch
                    {

                    }

                  
                }
                MySqlDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    pedido = Convert.ToInt32(leitor["Status Pedido"].ToString());
                    numeroPedido = Convert.ToInt32(leitor["Numero Pedido"].ToString());
                    if (Convert.ToInt32(leitor["Numero Pedido"].ToString()) > i)
                    {

                        playSimpleSound();
                        Thread.Sleep(3000);
                    }
                    i = Convert.ToInt32(leitor["Numero Pedido"].ToString());
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

        private void CarregarDadosCarrinho(string numero)
        {

            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DateTime dateTime = DateTime.Today;

               
                sql = $"SELECT descricao as \"Descricao\", " +
                    $"CONCAT('R$',format(valor_unitario,2,'pt_BR')) " +
                    $"as \"Valor Unitario\"," +
                    $" quantidade as \"Quantidade\",  " +
                    $"CONCAT('R$',format(valor_total,2,'pt_BR')) as \"Valor Total\" " +
                    $"from Carrinho where  id_venda={numero}";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);

                dgvCarrinho.Invoke((Action)(() => dgvCarrinho.DataSource = ds));



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
        public class Processo
        {
            public int numeroProcesso { get; set; }
            public string fone { get; set; }
            public Processo()
            { }

            public Processo(int id, string tel)
            {
                numeroProcesso = id;
                fone = tel;
            }
        }
        Processo processo;
        string tempo;
        DateTime theDate = DateTime.Now;
        private void aceitarPedido_Click(object sender, EventArgs e)
        {

            //simpleSound.Stop();
            tempoEntrega tempoEntrega = new tempoEntrega();
            tempoEntrega.ShowDialog();
            tempo = tempoEntrega.tempo;
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();



                sql = "UPDATE Venda " +
                        " SET pedidoAceito=@pedidoAceito, " +
                        " tempoEntrega=@tempoEntrega, " +
                        " data=@data " +
                        $" WHERE numero_venda_site=@numero_venda_site";
                
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("pedidoAceito", 1);
                cmd.Parameters.AddWithValue("tempoEntrega", tempoEntrega.tempo);
                cmd.Parameters.AddWithValue("data", theDate.ToString("yyyy-MM-dd H:mm:ss"));
                cmd.Parameters.AddWithValue("numero_venda_site", numeroPedidoUpdate);

                cmd.ExecuteNonQuery();
                dgvVendas.DataSource = "";
                CarregarDados();

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
            aceitarPedido.Visible = false;
            recusarPedido.Visible = false;
            CarregarDadosPedidoAceito();
            EnviarSMS();


        }

        public void LimparNumerosPedido()
        {
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {

                DateTime dataAtual;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

           

                    sql = $"select data from NumeroVenda";


                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    dataAtual = Convert.ToDateTime(leitor["data"]);
                    conn.Close();
                    try
                    {
                        if (dataAtual < theDate)
                        {
                            sql = "truncate NumeroVenda";
                            conn.Open();

                            MySqlCommand cmd2 = new MySqlCommand(sql, conn);


                            cmd2.ExecuteNonQuery();

                            sql = $"update Carrinho set id_venda=' ' where data<'{theDate}'";
                            conn.Open();

                            MySqlCommand cmd3 = new MySqlCommand(sql, conn);


                            cmd3.ExecuteNonQuery();

                        }
                    }
                    catch
                    {

                    }
                    
                       
                   
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
        private void CarregarDadosPedidoAceito()
        {

            MySqlConnection conn = instanciaMySql.GetConnection();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                sql = "SELECT " +
                    "venda.numero_venda_site as \"Numero Pedido\", " +
                    "cliente.nome as \"Nome\", " +
                    "cliente.telefone as \"Telefone\", " +
                   "cliente.endereco as \"Endereco\", " +
                   "cliente.numero as \"Numero\", " +
                   "cliente.bairro as \"Bairro\", " +
                   "venda.formaPagamento as \"Forma de Pagamento\", " +
                   "venda.formaEntrega as \"Forma de Entrega\", " +
                   "venda.troco as \"Troco\", " +
                   "venda.sub_total as \"Sub Total\", " +
                   "venda.valor_total as \"Valor Total\", " +
                   "venda.valorTroco as \"Valor do Troco\", " +
                   "venda.taxa_entrega as \"Taxa de Entrega\", " +
                   "venda.pedidoAceito as \"Status Pedido\" " +
                   "from Venda as venda " +
                   "inner join Cliente as cliente " +
                   $"on venda.id_cliente = cliente.id where venda.pedidoAceito=1 and venda.data = '{theDate}' order by venda.numero_venda_site desc";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                da.Fill(ds);
                if (ds.Rows.Count != 0)
                {
                    dgvAceitos.Invoke((Action)(() => dgvAceitos.DataSource = ds));
                    dgvAceitos.Invoke((Action)(() => dgvAceitos.ClearSelection()));

                    dgvAceitos.Invoke((Action)(() => i = dgvAceitos.Rows.Count));


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

        private void playSimpleSound()

        {

            simpleSound = new SoundPlayer("novoPedido.wav");
            simpleSound.Play();


        }
        public string RemoverAcentuacao(string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
        private void dgvVendas_DoubleClick(object sender, EventArgs e)
        {



        }


        private void dgvCarrinho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.dgvCarrinho.Columns[1].DefaultCellStyle.Format = "c";
        }

        private void btnRecusar_Click(object sender, EventArgs e)
        {
            string simNao, cnfirmacao;
            Confirmacao confirmacao = new Confirmacao();
            confirmacao.ShowDialog();
            if (confirmacao.simNao == "sim")
            {


                MySqlConnection conn = instanciaMySql.GetConnection();

                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();



                    sql = "UPDATE Venda " +
                        " SET pedidoAceito=@pedidoAceito, " +
                        " motivoRecusa=@motivoRecusa " +
                        $" WHERE numero_venda_site=@numero_venda_site";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("pedidoAceito", 2);
                    cmd.Parameters.AddWithValue("motivoRecusa", confirmacao.oMotivo);
                    cmd.Parameters.AddWithValue("numero_venda_site", numeroPedidoUpdate);

                    cmd.ExecuteNonQuery();
                    simpleSound.Stop();

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
                aceitarPedido.Visible = false;
                recusarPedido.Visible = false;
                CarregarDadosPedidoAceito();
            }
        }

        private void dgvVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txnumeroPedido.Text = "PEDIDO: " + dgvVendas.SelectedCells[0].Value.ToString();
            nome.Text = RemoverAcentuacao(dgvVendas.SelectedCells[1].Value.ToString().ToUpper());
            telefone.Text = RemoverAcentuacao(dgvVendas.SelectedCells[2].Value.ToString().ToUpper());

            formaPagamento.Text = "FORMA DE PAGAMENTO: " + dgvVendas.SelectedCells[6].Value.ToString();

            if (dgvVendas.SelectedCells[6].Value.ToString() == "CARTAO")
            {
                troco.Visible = false;
                valorTroco.Visible = false;
                subTotal.Visible = false;
            }
            else
            {
                troco.Visible = true;
                valorTroco.Visible = true;
                subTotal.Visible = true;
            }
            entrega.Text = Regex.Replace(dgvVendas.SelectedCells[7].Value.ToString().Replace(": R$", "").Replace(",", ""), @"[\d-]", string.Empty);
            if (entrega.Text == "RETIRAR NO LOCAL")
            {
                taxaEntrega.Visible = false;
                endereco.Visible = false;
                numero.Visible = false;
                bairro.Visible = false;
            }
            else
            {
                taxaEntrega.Visible = true;
                endereco.Visible = true;
                numero.Visible = true;
                bairro.Visible = true;
            }
            endereco.Text = RemoverAcentuacao(dgvVendas.SelectedCells[3].Value.ToString().ToUpper());
            numero.Text = dgvVendas.SelectedCells[4].Value.ToString().ToUpper();
            bairro.Text = RemoverAcentuacao(dgvVendas.SelectedCells[5].Value.ToString().ToUpper());

            troco.Text = "TROCO PARA: R$" + dgvVendas.SelectedCells[8].Value.ToString().Replace(".", ",");
            subTotal.Text = "SUBTOTAL: R$" + dgvVendas.SelectedCells[9].Value.ToString().Replace(".", ","); ;
            total.Text = "TOTAL: R$" + dgvVendas.SelectedCells[10].Value.ToString().Replace(".", ","); ;
            valorTroco.Text = "TROCO: R$" + dgvVendas.SelectedCells[11].Value.ToString().Replace(".", ","); ;
            taxaEntrega.Text = "TAXA DE ENTREGA: R$" + dgvVendas.SelectedCells[12].Value.ToString().Replace(".", ","); ;
            pedido = Convert.ToInt32(dgvVendas.SelectedCells[13].Value.ToString());
            aceitarPedido.Visible = true;
            recusarPedido.Visible = true;

            CarregarDadosCarrinho(dgvVendas.SelectedCells[0].Value.ToString());
            numeroPedidoUpdate = numeroPedido;

            thread = 0;
        }

        private void dgvAceitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txnumeroPedido.Text = dgvAceitos.SelectedCells[0].Value.ToString();
            nome.Text = RemoverAcentuacao(dgvAceitos.SelectedCells[1].Value.ToString().ToUpper());
            telefone.Text = RemoverAcentuacao(dgvAceitos.SelectedCells[2].Value.ToString().ToUpper());

            formaPagamento.Text = "FORMA DE PAGAMENTO: " + dgvAceitos.SelectedCells[6].Value.ToString();

            if (dgvAceitos.SelectedCells[6].Value.ToString() == "CARTAO")
            {
                troco.Visible = false;
                valorTroco.Visible = false;
                subTotal.Visible = false;
            }
            else
            {
                troco.Visible = true;
                valorTroco.Visible = true;
                subTotal.Visible = true;
            }
            entrega.Text = Regex.Replace(dgvAceitos.SelectedCells[7].Value.ToString().Replace(": R$", "").Replace(",", ""), @"[\d-]", string.Empty);
            if (entrega.Text == "RETIRAR NO LOCAL")
            {
                taxaEntrega.Visible = false;
                endereco.Visible = false;
                numero.Visible = false;
                bairro.Visible = false;
            }
            else
            {
                taxaEntrega.Visible = true;
                endereco.Visible = true;
                numero.Visible = true;
                bairro.Visible = true;
            }
            endereco.Text = RemoverAcentuacao(dgvAceitos.SelectedCells[3].Value.ToString().ToUpper());
            numero.Text = dgvAceitos.SelectedCells[4].Value.ToString().ToUpper();
            bairro.Text = RemoverAcentuacao(dgvAceitos.SelectedCells[5].Value.ToString().ToUpper());

            troco.Text = "TROCO PARA: R$" + dgvAceitos.SelectedCells[8].Value.ToString().Replace(".", ",");
            subTotal.Text = "SUBTOTAL: R$" + dgvAceitos.SelectedCells[9].Value.ToString().Replace(".", ","); ;
            total.Text = "TOTAL: R$" + dgvAceitos.SelectedCells[10].Value.ToString().Replace(".", ","); ;
            valorTroco.Text = "TROCO: R$" + dgvAceitos.SelectedCells[11].Value.ToString().Replace(".", ","); ;
            taxaEntrega.Text = "TAXA DE ENTREGA: R$" + dgvAceitos.SelectedCells[12].Value.ToString().Replace(".", ","); ;
            pedido = Convert.ToInt32(dgvAceitos.SelectedCells[13].Value.ToString());


            CarregarDadosCarrinho(dgvAceitos.SelectedCells[0].Value.ToString());


            thread = 0;
        }

        private void dgvAceitos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvAceitos.Columns[2].Visible = false;
            dgvAceitos.Columns[3].Visible = false;
            dgvAceitos.Columns[4].Visible = false;
            dgvAceitos.Columns[5].Visible = false;
            dgvAceitos.Columns[6].Visible = false;
            dgvAceitos.Columns[7].Visible = false;
            dgvAceitos.Columns[8].Visible = false;
            dgvAceitos.Columns[9].Visible = false;
            dgvAceitos.Columns[10].Visible = false;
            dgvAceitos.Columns[11].Visible = false;
            dgvAceitos.Columns[12].Visible = false;
            dgvAceitos.Columns[13].Visible = false;
        }

        private void dgvVendas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvVendas.Columns[2].Visible = false;
            dgvVendas.Columns[3].Visible = false;
            dgvVendas.Columns[4].Visible = false;
            dgvVendas.Columns[5].Visible = false;
            dgvVendas.Columns[6].Visible = false;
            dgvVendas.Columns[7].Visible = false;
            dgvVendas.Columns[8].Visible = false;
            dgvVendas.Columns[9].Visible = false;
            dgvVendas.Columns[10].Visible = false;
            dgvVendas.Columns[11].Visible = false;
            dgvVendas.Columns[12].Visible = false;
            dgvVendas.Columns[13].Visible = false;
        }
        string msg;



        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        public void limparCampos()
        {
            numero.Clear();
            nome.Clear();
            telefone.Clear();
            endereco.Clear();
            numero.Clear();
            bairro.Clear();
            formaPagamento.Clear();
            entrega.Clear();
            subTotal.Clear();
            total.Clear();
            taxaEntrega.Clear();
            troco.Clear();
            valorTroco.Clear();
            dgvCarrinho.DataSource = "";
        }




        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                thread = 2000;
                Thread.Sleep(thread);


                CarregarDados();


                //impressaoPedido.ShowDialog();
                // Some call to your data access layer to get dt

            }
        }
        public void imprimirPedido()
        {

            Boolean semEnd;
            string end;
            if (!string.IsNullOrEmpty(endereco.Text))
            {
                semEnd = false;
                end = endereco.Text + ", " + numero.Text + " - " + bairro.Text;
            }
            else
            {
                semEnd = true;
                end = "     ";
            }




            ImpressaoSite impressaoPedido = new ImpressaoSite(txnumeroPedido.Text, formaPagamento.Text, taxaEntrega.Text, dgvCarrinho.Rows.Count, semEnd);

            impressaoPedido.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (nome.Text != "")
            {
                imprimirPedido();
            }
           
        }

        private void EnviarSMS()
        {
            msg = $"Ola {nome.Text}, Seu Pedido Foi Aceito, tempo de entrega: {tempo}, agradecemos a preferencia! :D";
            using (var port = new System.IO.Ports.SerialPort())
            {
                string linha;
                using (StreamReader reader = new StreamReader("porta.config"))
                {
                    linha = reader.ReadLine();
                }
                try
                {
                    port.PortName = linha;

                    port.Open();
                    port.DtrEnable = true;
                    port.RtsEnable = true;
                    port.Write("AT\r"); // iniciando a comunicação
                    port.Write("AT+CMGF=1\r"); // setando a comunicação para o modo texto
                    string tel = new string(telefone.Text.Where(char.IsDigit).ToArray());
                    port.Write(string.Format("AT+CMGS=\"{0}\"\r", tel)); // setando o número do destinatário
                    port.Write(msg + char.ConvertFromUtf32(26)); // enviando a mensagem
                }
                catch
                {

                }
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviarSMS();
           
        }
    }
}
