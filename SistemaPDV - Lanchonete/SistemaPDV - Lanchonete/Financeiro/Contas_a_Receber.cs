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
    public partial class Contas_a_Receber : Form
    {

        MySQL instanciaMySql = new MySQL();
        string sql;

        public Contas_a_Receber()
        {
            InitializeComponent();
        }
    }
}
