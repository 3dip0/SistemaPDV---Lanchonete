﻿
namespace SistemaPDV___Lanchonete.Cadastro
{
    partial class Taxas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNov = new System.Windows.Forms.Button();
            this.btnSalv = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExc = new System.Windows.Forms.Button();
            this.dgvTaxas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPesquisar = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.lbl_Descricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNov
            // 
            this.btnNov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNov.Location = new System.Drawing.Point(458, 558);
            this.btnNov.Name = "btnNov";
            this.btnNov.Size = new System.Drawing.Size(108, 29);
            this.btnNov.TabIndex = 37;
            this.btnNov.Text = "Novo";
            this.btnNov.UseVisualStyleBackColor = true;
            this.btnNov.Click += new System.EventHandler(this.btnNov_Click);
            // 
            // btnSalv
            // 
            this.btnSalv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalv.Location = new System.Drawing.Point(3, 558);
            this.btnSalv.Name = "btnSalv";
            this.btnSalv.Size = new System.Drawing.Size(108, 29);
            this.btnSalv.TabIndex = 40;
            this.btnSalv.Text = "Salvar";
            this.btnSalv.UseVisualStyleBackColor = true;
            this.btnSalv.Visible = false;
            this.btnSalv.Click += new System.EventHandler(this.btnSalv_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(117, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 29);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(572, 558);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 29);
            this.btnEdit.TabIndex = 38;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExc
            // 
            this.btnExc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExc.Location = new System.Drawing.Point(686, 558);
            this.btnExc.Name = "btnExc";
            this.btnExc.Size = new System.Drawing.Size(108, 29);
            this.btnExc.TabIndex = 39;
            this.btnExc.Text = "Excluir";
            this.btnExc.UseVisualStyleBackColor = true;
            this.btnExc.Click += new System.EventHandler(this.btnExc_Click);
            // 
            // dgvTaxas
            // 
            this.dgvTaxas.AllowUserToAddRows = false;
            this.dgvTaxas.AllowUserToDeleteRows = false;
            this.dgvTaxas.AllowUserToResizeColumns = false;
            this.dgvTaxas.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvTaxas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTaxas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaxas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaxas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaxas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTaxas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTaxas.Location = new System.Drawing.Point(0, 128);
            this.dgvTaxas.MultiSelect = false;
            this.dgvTaxas.Name = "dgvTaxas";
            this.dgvTaxas.ReadOnly = true;
            this.dgvTaxas.RowHeadersVisible = false;
            this.dgvTaxas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaxas.Size = new System.Drawing.Size(800, 415);
            this.dgvTaxas.TabIndex = 35;
            this.dgvTaxas.TabStop = false;
            this.dgvTaxas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvClientes_CellFormatting);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.cbPesquisar);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 63);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar";
            // 
            // cbPesquisar
            // 
            this.cbPesquisar.FormattingEnabled = true;
            this.cbPesquisar.ItemHeight = 13;
            this.cbPesquisar.Location = new System.Drawing.Point(6, 19);
            this.cbPesquisar.Name = "cbPesquisar";
            this.cbPesquisar.Size = new System.Drawing.Size(180, 21);
            this.cbPesquisar.TabIndex = 14;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisar.Location = new System.Drawing.Point(192, 19);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(602, 20);
            this.txtPesquisar.TabIndex = 11;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.label1);
            this.panelAdd.Controls.Add(this.txtValor);
            this.panelAdd.Controls.Add(this.label40);
            this.panelAdd.Controls.Add(this.txtId);
            this.panelAdd.Controls.Add(this.lblCEP);
            this.panelAdd.Controls.Add(this.lbl_Descricao);
            this.panelAdd.Controls.Add(this.txtDescricao);
            this.panelAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdd.Enabled = false;
            this.panelAdd.Location = new System.Drawing.Point(0, 0);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(800, 65);
            this.panelAdd.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(674, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(677, 26);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(108, 20);
            this.txtValor.TabIndex = 123;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(5, 10);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(18, 13);
            this.label40.TabIndex = 114;
            this.label40.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(6, 26);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(102, 20);
            this.txtId.TabIndex = 1;
            // 
            // lblCEP
            // 
            this.lblCEP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(-191, 49);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(28, 13);
            this.lblCEP.TabIndex = 100;
            this.lblCEP.Text = "CEP";
            // 
            // lbl_Descricao
            // 
            this.lbl_Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Descricao.AutoSize = true;
            this.lbl_Descricao.Location = new System.Drawing.Point(111, 10);
            this.lbl_Descricao.Name = "lbl_Descricao";
            this.lbl_Descricao.Size = new System.Drawing.Size(55, 13);
            this.lbl_Descricao.TabIndex = 98;
            this.lbl_Descricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(114, 26);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(557, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // Taxas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.btnNov);
            this.Controls.Add(this.btnSalv);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnExc);
            this.Controls.Add(this.dgvTaxas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Taxas";
            this.Text = "Taxa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelAdd.ResumeLayout(false);
            this.panelAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNov;
        private System.Windows.Forms.Button btnSalv;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExc;
        private System.Windows.Forms.DataGridView dgvTaxas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Panel panelAdd;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtValor;
        public System.Windows.Forms.Label label40;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.Label lblCEP;
        public System.Windows.Forms.Label lbl_Descricao;
        public System.Windows.Forms.TextBox txtDescricao;
    }
}