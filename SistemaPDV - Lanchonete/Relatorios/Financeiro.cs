using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPDV___Lanchonete.Relatorios
{
    public partial class Financeiro : Form
    {
        SQL instanciaMySql = new SQL();
        string sql;

        public Financeiro()
        {
            InitializeComponent();
        }
    }
}
