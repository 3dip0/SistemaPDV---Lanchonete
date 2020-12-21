using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SistemaPDV___Lanchonete.Cadastro
{
    public partial class ImpressaoPedido : Form
    {

        public static ListBox Bobina { get; set; }
        public string nome, end, numero, bairro, taxaEntrega, subTotal, valorTotal, nPedido;

        public ImpressaoPedido()
        {
            InitializeComponent();
            CarregarImpressoras();


            bobina.Items.Add("CUPOM NÃO FISCAL");
            bobina.Items.Add("");
            bobina.Items.Add("PRODUTO          QUANTIDADE      VALOR");


        }

        private void CarregarImpressoras()
        {
            impressoraComboBox.Items.Clear();

            foreach (var impressora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                impressoraComboBox.Items.Add(impressora);
            }
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            using (var pd = new System.Drawing.Printing.PrintDocument())
            {
                pd.PrinterSettings.PrinterName = impressoraComboBox.SelectedItem.ToString();
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
        }
        int margem = 0;
        public decimal valorDecimal;
        private void Pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (var font = new Font("Courier New", 12))
            using (var brush = new SolidBrush(Color.Black))

            {



                e.Graphics.DrawString("-----------------------------------", font, brush, 0, 0);

                e.Graphics.DrawString("CUPOM NÃO FISCAL", font, brush, 0, margem = margem + 50);
                e.Graphics.DrawString("", font, brush, 0, margem = margem + 50);
                e.Graphics.DrawString("PRODUTO          QUANTIDADE   VALOR", font, brush, 0, margem);
                e.Graphics.DrawString("-----------------------------------", font, brush, 0, margem = margem + 10);
                int cont;
               
                foreach (DataGridViewRow item in dgvItens.Rows)
                {
                    decimal.TryParse(item.Cells["Valor Total"].Value.ToString(), out valorDecimal);
                    e.Graphics.DrawString(
                String.Format("{0,10}  {1,10} {2, 10}",
                item.Cells["Descricao"].Value.ToString(),
                item.Cells["Quantidade"].Value.ToString(),
                valorDecimal), font, brush, 0, margem = margem + 20);

                }
                
                            e.Graphics.DrawString("-----------------------------------", font, brush, 0, margem = margem + 10);
                            e.Graphics.DrawString($"SubTotal..................{lblSub.Text}", font, brush, 0, margem = margem + 20);
                            e.Graphics.DrawString($"Taxa......................{lblTaxa.Text}", font, brush, 0, margem = margem + 20);
                            e.Graphics.DrawString($"Total.....................{lblTotal.Text}", font, brush, 0, margem = margem + 20);

                        
                    
                
            }
        }

        private void dgvItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void bobina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;

        
        private void Button1_click(object sender, EventArgs e)
        {
           
        }

      

        

       

     
        public DataTable itens;


        private void ImpressãoPedido_Load(object sender, EventArgs e)
        {

        }

       
        public static void ImprimeCabecalhoBobina()
        {
            
        }
    }
}
