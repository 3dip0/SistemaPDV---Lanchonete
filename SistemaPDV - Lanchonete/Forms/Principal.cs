using SistemaPDV___Lanchonete.Cadastro;
using SistemaPDV___Lanchonete.Relatorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPDV___Lanchonete
{
    public partial class Principal : Form
    {

        public string nivel = "0";

        public Principal()
        {
            InitializeComponent();
        }

        private void AbrirFormNoPanel(object Formhijo)
        {
            if (this.panelPrincipal.Controls.Count > 0)
                this.panelPrincipal.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(fh);
            this.panelPrincipal.Tag = fh;
            fh.Show();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Usuarios());
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Produtos());
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Estoque());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Clientes());
        }

        private void caixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Caixa());
        }

        private void despesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Contas_a_Pagar());
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Contas_a_Receber());
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Vendas());
        }

        private void financeiroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Financeiro());
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Produtos());
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Relatorio_Vendas());
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Taxas());
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new Categorias());
        }

        private void monitoramentoSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monitoramento.RunWorkerAsync();
        }
        
        private void Monitoramento_DoWork(object sender, DoWorkEventArgs e)
        {

            Confirmacao confirmacao = new Confirmacao();

            confirmacao.WindowState = FormWindowState.Maximized;
            confirmacao.ShowDialog();
        }

        private void portaSerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracao configuracao = new Configuracao();
            configuracao.ShowDialog();
        }

        private void Monitoramento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        private void monitoramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Clientes confirmacao = new Clientes();

            confirmacao.WindowState = FormWindowState.Maximized;
            confirmacao.ShowDialog();
        }
    }
}
