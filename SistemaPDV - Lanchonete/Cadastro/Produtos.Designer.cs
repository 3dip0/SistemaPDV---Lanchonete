
namespace SistemaPDV___Lanchonete
{
    partial class Produtos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNov = new System.Windows.Forms.Button();
            this.btnSalv = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExc = new System.Windows.Forms.Button();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPesquisar = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelIngredientes = new System.Windows.Forms.Panel();
            this.cbIngredientes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIngTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIngUnitario = new System.Windows.Forms.TextBox();
            this.txtIngQtd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalvarIngred = new System.Windows.Forms.Button();
            this.btnCancelIngred = new System.Windows.Forms.Button();
            this.btnAddIngred = new System.Windows.Forms.Button();
            this.btnEditIngred = new System.Windows.Forms.Button();
            this.btnExcIngred = new System.Windows.Forms.Button();
            this.dgvIngredientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lbl_Descricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDIngredientes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelIngredientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNov
            // 
            this.btnNov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNov.Location = new System.Drawing.Point(676, 546);
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
            this.btnSalv.Location = new System.Drawing.Point(3, 546);
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
            this.btnCancel.Location = new System.Drawing.Point(117, 546);
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
            this.btnEdit.Location = new System.Drawing.Point(790, 546);
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
            this.btnExc.Location = new System.Drawing.Point(904, 546);
            this.btnExc.Name = "btnExc";
            this.btnExc.Size = new System.Drawing.Size(108, 29);
            this.btnExc.TabIndex = 39;
            this.btnExc.Text = "Excluir";
            this.btnExc.UseVisualStyleBackColor = true;
            this.btnExc.Click += new System.EventHandler(this.btnExc_Click);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvProdutos.Location = new System.Drawing.Point(0, 309);
            this.dgvProdutos.MultiSelect = false;
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(1022, 231);
            this.dgvProdutos.TabIndex = 35;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvClientes_CellFormatting);
            this.dgvProdutos.DoubleClick += new System.EventHandler(this.dgvClientes_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.cbPesquisar);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1022, 63);
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
            this.txtPesquisar.Size = new System.Drawing.Size(824, 20);
            this.txtPesquisar.TabIndex = 11;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.groupBox2);
            this.panelAdd.Controls.Add(this.label1);
            this.panelAdd.Controls.Add(this.txtValorTotal);
            this.panelAdd.Controls.Add(this.txtQtd);
            this.panelAdd.Controls.Add(this.lblQuantidade);
            this.panelAdd.Controls.Add(this.label40);
            this.panelAdd.Controls.Add(this.txtId);
            this.panelAdd.Controls.Add(this.lbl_Descricao);
            this.panelAdd.Controls.Add(this.txtDescricao);
            this.panelAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdd.Enabled = false;
            this.panelAdd.Location = new System.Drawing.Point(0, 0);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(1022, 246);
            this.panelAdd.TabIndex = 34;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelIngredientes);
            this.groupBox2.Controls.Add(this.btnSalvarIngred);
            this.groupBox2.Controls.Add(this.btnCancelIngred);
            this.groupBox2.Controls.Add(this.btnAddIngred);
            this.groupBox2.Controls.Add(this.btnEditIngred);
            this.groupBox2.Controls.Add(this.btnExcIngred);
            this.groupBox2.Controls.Add(this.dgvIngredientes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1022, 194);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adicionar Ingredientes";
            // 
            // panelIngredientes
            // 
            this.panelIngredientes.Controls.Add(this.label6);
            this.panelIngredientes.Controls.Add(this.txtIDIngredientes);
            this.panelIngredientes.Controls.Add(this.cbIngredientes);
            this.panelIngredientes.Controls.Add(this.label5);
            this.panelIngredientes.Controls.Add(this.txtIngTotal);
            this.panelIngredientes.Controls.Add(this.label2);
            this.panelIngredientes.Controls.Add(this.txtIngUnitario);
            this.panelIngredientes.Controls.Add(this.txtIngQtd);
            this.panelIngredientes.Controls.Add(this.label3);
            this.panelIngredientes.Controls.Add(this.label4);
            this.panelIngredientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelIngredientes.Enabled = false;
            this.panelIngredientes.Location = new System.Drawing.Point(3, 16);
            this.panelIngredientes.Name = "panelIngredientes";
            this.panelIngredientes.Size = new System.Drawing.Size(1016, 41);
            this.panelIngredientes.TabIndex = 148;
            // 
            // cbIngredientes
            // 
            this.cbIngredientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIngredientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIngredientes.FormattingEnabled = true;
            this.cbIngredientes.Location = new System.Drawing.Point(111, 18);
            this.cbIngredientes.Name = "cbIngredientes";
            this.cbIngredientes.Size = new System.Drawing.Size(615, 21);
            this.cbIngredientes.TabIndex = 149;
            this.cbIngredientes.SelectedIndexChanged += new System.EventHandler(this.cbIngredientes_SelectedIndexChanged);
            this.cbIngredientes.TextChanged += new System.EventHandler(this.cbIngredientes_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(910, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 148;
            this.label5.Text = "Valor Total";
            // 
            // txtIngTotal
            // 
            this.txtIngTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIngTotal.Enabled = false;
            this.txtIngTotal.Location = new System.Drawing.Point(913, 18);
            this.txtIngTotal.Name = "txtIngTotal";
            this.txtIngTotal.Size = new System.Drawing.Size(100, 20);
            this.txtIngTotal.TabIndex = 147;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(804, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 146;
            this.label2.Text = "Valor Unitario";
            // 
            // txtIngUnitario
            // 
            this.txtIngUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIngUnitario.Enabled = false;
            this.txtIngUnitario.Location = new System.Drawing.Point(807, 18);
            this.txtIngUnitario.Name = "txtIngUnitario";
            this.txtIngUnitario.Size = new System.Drawing.Size(100, 20);
            this.txtIngUnitario.TabIndex = 145;
            // 
            // txtIngQtd
            // 
            this.txtIngQtd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIngQtd.Location = new System.Drawing.Point(732, 18);
            this.txtIngQtd.Name = "txtIngQtd";
            this.txtIngQtd.Size = new System.Drawing.Size(69, 20);
            this.txtIngQtd.TabIndex = 144;
            this.txtIngQtd.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(731, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 143;
            this.label3.Text = "Quantidade";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 142;
            this.label4.Text = "Ingredientes";
            // 
            // btnSalvarIngred
            // 
            this.btnSalvarIngred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalvarIngred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarIngred.Location = new System.Drawing.Point(3, 63);
            this.btnSalvarIngred.Name = "btnSalvarIngred";
            this.btnSalvarIngred.Size = new System.Drawing.Size(108, 29);
            this.btnSalvarIngred.TabIndex = 146;
            this.btnSalvarIngred.Text = "Salvar";
            this.btnSalvarIngred.UseVisualStyleBackColor = true;
            this.btnSalvarIngred.Visible = false;
            this.btnSalvarIngred.Click += new System.EventHandler(this.btnSalvarIngred_Click);
            // 
            // btnCancelIngred
            // 
            this.btnCancelIngred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelIngred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelIngred.Location = new System.Drawing.Point(117, 63);
            this.btnCancelIngred.Name = "btnCancelIngred";
            this.btnCancelIngred.Size = new System.Drawing.Size(108, 29);
            this.btnCancelIngred.TabIndex = 147;
            this.btnCancelIngred.Text = "Cancelar";
            this.btnCancelIngred.UseVisualStyleBackColor = true;
            this.btnCancelIngred.Visible = false;
            this.btnCancelIngred.Click += new System.EventHandler(this.btnCancelIngred_Click);
            // 
            // btnAddIngred
            // 
            this.btnAddIngred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddIngred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIngred.Location = new System.Drawing.Point(676, 62);
            this.btnAddIngred.Name = "btnAddIngred";
            this.btnAddIngred.Size = new System.Drawing.Size(108, 29);
            this.btnAddIngred.TabIndex = 143;
            this.btnAddIngred.Text = "Adicionar";
            this.btnAddIngred.UseVisualStyleBackColor = true;
            this.btnAddIngred.Click += new System.EventHandler(this.btnAddIngred_Click);
            // 
            // btnEditIngred
            // 
            this.btnEditIngred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditIngred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditIngred.Location = new System.Drawing.Point(790, 62);
            this.btnEditIngred.Name = "btnEditIngred";
            this.btnEditIngred.Size = new System.Drawing.Size(108, 29);
            this.btnEditIngred.TabIndex = 144;
            this.btnEditIngred.Text = "Editar";
            this.btnEditIngred.UseVisualStyleBackColor = true;
            this.btnEditIngred.Click += new System.EventHandler(this.btnEditIngred_Click);
            // 
            // btnExcIngred
            // 
            this.btnExcIngred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcIngred.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcIngred.Location = new System.Drawing.Point(904, 62);
            this.btnExcIngred.Name = "btnExcIngred";
            this.btnExcIngred.Size = new System.Drawing.Size(108, 29);
            this.btnExcIngred.TabIndex = 145;
            this.btnExcIngred.Text = "Excluir";
            this.btnExcIngred.UseVisualStyleBackColor = true;
            this.btnExcIngred.Click += new System.EventHandler(this.btnExcIngred_Click);
            // 
            // dgvIngredientes
            // 
            this.dgvIngredientes.AllowUserToAddRows = false;
            this.dgvIngredientes.AllowUserToDeleteRows = false;
            this.dgvIngredientes.AllowUserToResizeColumns = false;
            this.dgvIngredientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvIngredientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvIngredientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngredientes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvIngredientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvIngredientes.Location = new System.Drawing.Point(3, 98);
            this.dgvIngredientes.MultiSelect = false;
            this.dgvIngredientes.Name = "dgvIngredientes";
            this.dgvIngredientes.ReadOnly = true;
            this.dgvIngredientes.RowHeadersVisible = false;
            this.dgvIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredientes.Size = new System.Drawing.Size(1016, 93);
            this.dgvIngredientes.TabIndex = 142;
            this.dgvIngredientes.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(896, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "Valor Venda";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorTotal.Location = new System.Drawing.Point(899, 26);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(113, 20);
            this.txtValorTotal.TabIndex = 123;
            // 
            // txtQtd
            // 
            this.txtQtd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQtd.Location = new System.Drawing.Point(832, 26);
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(61, 20);
            this.txtQtd.TabIndex = 122;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(831, 10);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 116;
            this.lblQuantidade.Text = "Quantidade";
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
            this.txtDescricao.Size = new System.Drawing.Size(712, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 151;
            this.label6.Text = "ID";
            // 
            // txtIDIngredientes
            // 
            this.txtIDIngredientes.Enabled = false;
            this.txtIDIngredientes.Location = new System.Drawing.Point(6, 18);
            this.txtIDIngredientes.Name = "txtIDIngredientes";
            this.txtIDIngredientes.Size = new System.Drawing.Size(102, 20);
            this.txtIDIngredientes.TabIndex = 150;
            // 
            // Produtos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1022, 583);
            this.Controls.Add(this.btnNov);
            this.Controls.Add(this.btnSalv);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnExc);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Produtos";
            this.Text = "Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelAdd.ResumeLayout(false);
            this.panelAdd.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelIngredientes.ResumeLayout(false);
            this.panelIngredientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNov;
        private System.Windows.Forms.Button btnSalv;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExc;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Panel panelAdd;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtValorTotal;
        public System.Windows.Forms.TextBox txtQtd;
        public System.Windows.Forms.Label lblQuantidade;
        public System.Windows.Forms.Label label40;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.Label lbl_Descricao;
        public System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddIngred;
        private System.Windows.Forms.Button btnEditIngred;
        private System.Windows.Forms.Button btnExcIngred;
        private System.Windows.Forms.DataGridView dgvIngredientes;
        private System.Windows.Forms.Panel panelIngredientes;
        private System.Windows.Forms.ComboBox cbIngredientes;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtIngTotal;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtIngUnitario;
        public System.Windows.Forms.TextBox txtIngQtd;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalvarIngred;
        private System.Windows.Forms.Button btnCancelIngred;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtIDIngredientes;
    }
}