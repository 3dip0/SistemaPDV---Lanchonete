using Microsoft.Reporting.WinForms;
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

namespace SistemaPDV___Lanchonete
{
    public partial class ImpressaoSite : Form
    {

        MySQL instanciaMySql = new MySQL();
       
        public static ListBox Bobina { get; set; }
        public ImpressaoSite(string comandoVenda, string tipoPagamento, string taxa, int rowsCarrinho, Boolean semEndereco)
        {
            InitializeComponent();

            bdlanche lanche = new bdlanche();
            MySqlConnection conn = instanciaMySql.GetConnection();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                MySqlCommand cmdVenda;
                MySqlCommand cmdCliente;
                MySqlCommand cmdCarrinho;

                MySqlDataAdapter daVenda;
                MySqlDataAdapter daCliente;
                MySqlDataAdapter daCarrinho;

                string SelecionarVenda = $"SELECT *FROM Venda where numero_venda_site={comandoVenda}";
                string selecionarCliente = $"SELECT *from Venda as venda " +
                   "inner join Cliente as cliente " +
                   $"on venda.id_cliente = cliente.id where venda.numero_venda_site ={comandoVenda}";
                string selecionarProdutos = $"SELECT *from Carrinho as carrinho " +
                   "inner join Venda as venda " +
                   $"on carrinho.id_venda = venda.id where carrinho.id_venda ={comandoVenda}";


                cmdVenda = new MySqlCommand(SelecionarVenda, conn);
                daVenda = new MySqlDataAdapter(cmdVenda);
                daVenda.Fill(lanche, lanche.Tables[7].TableName);

                cmdCliente = new MySqlCommand(selecionarCliente, conn);
                daCliente = new MySqlDataAdapter(cmdCliente);
                daCliente.Fill(lanche, lanche.Tables[1].TableName);

                cmdCarrinho = new MySqlCommand(selecionarProdutos, conn);
                daCarrinho = new MySqlDataAdapter(cmdCarrinho);
                daCarrinho.Fill(lanche, lanche.Tables[0].TableName);

                ReportDataSource rds = new ReportDataSource("Vendas", lanche.Tables[7]);
                ReportDataSource rdsClientes = new ReportDataSource("Clientes", lanche.Tables[1]);
                ReportDataSource rdsCarrinho = new ReportDataSource("Carrinho", lanche.Tables[0]);


                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.DataSources.Add(rdsClientes);
                reportViewer1.LocalReport.DataSources.Add(rdsCarrinho);

                if (semEndereco == true)
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("virgula", " "));
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("traco", " "));

                }
                else
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("virgula", ","));
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("traco", "-"));

                }




                if (taxa == "ENTREGA:")
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tipoTaxa", "ENTREGA:"));
                }
                else
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tipoTaxa", "   "));
                }




                if (tipoPagamento != "CARTAO")
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("trocoPara", "TROCO PARA:"));
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("trocoCliente", "TROCO:"));
                }
                else
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("trocoPara", "   "));
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("trocoCliente", "   "));
                }

                reportViewer1.LocalReport.Refresh();
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                var setup = reportViewer1.GetPageSettings();
                setup.PaperSize.Height = 500;
                setup.PaperSize.Width = 370;
                for (int i = 0; i <= rowsCarrinho; i++)
                {

                    setup.PaperSize.Height = setup.PaperSize.Height + 150;
                }

                setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                reportViewer1.SetPageSettings(setup);


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            finally
            {
                conn.Close();
            }
            this.reportViewer1.RefreshReport();

        }


        private void ImpressaoSite_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            
        }
    }
}
