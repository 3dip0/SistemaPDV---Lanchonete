﻿using System;
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
    public partial class Confirmacao : Form
    {
        public string simNao;
        public string oMotivo;
        public Confirmacao()
        {
            InitializeComponent();

        }

        private void btnSIm_Click(object sender, EventArgs e)
        {
            simNao = "sim";
            oMotivo = txtMotivo.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simNao = "nao";
            Close();
        }
    }
}
