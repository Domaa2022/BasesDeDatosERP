namespace ProyectoBD1.Clases
{
    partial class Inventario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgInventario = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCodigoBuscar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gpbxPersonal = new System.Windows.Forms.GroupBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoInventario = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.txtCompra = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpbxPersonal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 45);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(878, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "INVENTARIO";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(915, 555);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgInventario);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.gpbxPersonal);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(907, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gestión Productos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgInventario
            // 
            this.dtgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInventario.Location = new System.Drawing.Point(467, 107);
            this.dtgInventario.Name = "dtgInventario";
            this.dtgInventario.Size = new System.Drawing.Size(431, 272);
            this.dtgInventario.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtCodigoBuscar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox1.Location = new System.Drawing.Point(443, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(455, 83);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar producto";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.Location = new System.Drawing.Point(313, 47);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 58;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button2.Location = new System.Drawing.Point(313, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 57;
            this.button2.Text = "Consultar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCodigoBuscar
            // 
            this.txtCodigoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBuscar.Location = new System.Drawing.Point(144, 33);
            this.txtCodigoBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoBuscar.Name = "txtCodigoBuscar";
            this.txtCodigoBuscar.Size = new System.Drawing.Size(129, 23);
            this.txtCodigoBuscar.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 46;
            this.label7.Text = "Ingrese el código:";
            // 
            // gpbxPersonal
            // 
            this.gpbxPersonal.Controls.Add(this.txtColor);
            this.gpbxPersonal.Controls.Add(this.button3);
            this.gpbxPersonal.Controls.Add(this.label6);
            this.gpbxPersonal.Controls.Add(this.txtPrecio);
            this.gpbxPersonal.Controls.Add(this.button1);
            this.gpbxPersonal.Controls.Add(this.label5);
            this.gpbxPersonal.Controls.Add(this.txtAño);
            this.gpbxPersonal.Controls.Add(this.label3);
            this.gpbxPersonal.Controls.Add(this.label4);
            this.gpbxPersonal.Controls.Add(this.txtModelo);
            this.gpbxPersonal.Controls.Add(this.label8);
            this.gpbxPersonal.Controls.Add(this.txtCodigoInventario);
            this.gpbxPersonal.Controls.Add(this.txtMarca);
            this.gpbxPersonal.Controls.Add(this.lblFirstName);
            this.gpbxPersonal.Controls.Add(this.lblId);
            this.gpbxPersonal.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.gpbxPersonal.Location = new System.Drawing.Point(5, 5);
            this.gpbxPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.gpbxPersonal.Name = "gpbxPersonal";
            this.gpbxPersonal.Padding = new System.Windows.Forms.Padding(2);
            this.gpbxPersonal.Size = new System.Drawing.Size(434, 374);
            this.gpbxPersonal.TabIndex = 53;
            this.gpbxPersonal.TabStop = false;
            this.gpbxPersonal.Text = "Detalles del producto";
            // 
            // txtColor
            // 
            this.txtColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(54, 174);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(145, 23);
            this.txtColor.TabIndex = 56;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button3.Location = new System.Drawing.Point(228, 323);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 23);
            this.button3.TabIndex = 55;
            this.button3.Text = "Actualizar Producto";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(292, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 15);
            this.label6.TabIndex = 45;
            this.label6.Text = "Lps";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(179, 257);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(111, 23);
            this.txtPrecio.TabIndex = 44;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.Location = new System.Drawing.Point(69, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "Registrar Producto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 262);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Precio de venta:";
            // 
            // txtAño
            // 
            this.txtAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAño.Location = new System.Drawing.Point(275, 174);
            this.txtAño.Margin = new System.Windows.Forms.Padding(2);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(145, 23);
            this.txtAño.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Año:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Color:";
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(275, 102);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(2);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(145, 23);
            this.txtModelo.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(225, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "Modelo:";
            // 
            // txtCodigoInventario
            // 
            this.txtCodigoInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoInventario.Location = new System.Drawing.Point(179, 35);
            this.txtCodigoInventario.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoInventario.Name = "txtCodigoInventario";
            this.txtCodigoInventario.Size = new System.Drawing.Size(111, 23);
            this.txtCodigoInventario.TabIndex = 31;
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(54, 102);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(145, 23);
            this.txtMarca.TabIndex = 27;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(11, 107);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(41, 15);
            this.lblFirstName.TabIndex = 22;
            this.lblFirstName.Text = "Marca:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(123, 40);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(44, 15);
            this.lblId.TabIndex = 18;
            this.lblId.Text = "Código:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(907, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compras de Productos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.btnConsulta);
            this.groupBox2.Controls.Add(this.txtCompra);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.dgvCompras);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox2.Location = new System.Drawing.Point(11, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(889, 517);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Historial de compra";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(135, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 14);
            this.label15.TabIndex = 62;
            this.label15.Text = "el resultado";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(13, 66);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 15);
            this.label16.TabIndex = 61;
            this.label16.Text = "Cantidad de Compras :";
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnConsulta.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.ForeColor = System.Drawing.Color.White;
            this.btnConsulta.Location = new System.Drawing.Point(263, 93);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(88, 21);
            this.btnConsulta.TabIndex = 60;
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // txtCompra
            // 
            this.txtCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompra.Location = new System.Drawing.Point(123, 95);
            this.txtCompra.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(129, 23);
            this.txtCompra.TabIndex = 59;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 99);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 15);
            this.label14.TabIndex = 58;
            this.label14.Text = "Código de la compra :";
            // 
            // dgvCompras
            // 
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Location = new System.Drawing.Point(16, 136);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.Size = new System.Drawing.Size(857, 368);
            this.dgvCompras.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 42);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 14);
            this.label11.TabIndex = 1;
            this.label11.Text = "Distribuidora de autos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Cosmo Autos";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(907, 528);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ventas de Productos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.txtVenta);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.dgvVentas);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.groupBox3.Location = new System.Drawing.Point(10, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(889, 517);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Historial de Ventas";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(122, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 14);
            this.label17.TabIndex = 62;
            this.label17.Text = "el resultado";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 62);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 15);
            this.label18.TabIndex = 61;
            this.label18.Text = "Cantidad de ventas :";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(263, 77);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 21);
            this.button5.TabIndex = 60;
            this.button5.Text = "Consulta";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtVenta
            // 
            this.txtVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Location = new System.Drawing.Point(123, 79);
            this.txtVenta.Margin = new System.Windows.Forms.Padding(2);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(129, 23);
            this.txtVenta.TabIndex = 59;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(13, 83);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 15);
            this.label19.TabIndex = 58;
            this.label19.Text = "Código de la venta :";
            // 
            // dgvVentas
            // 
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(16, 124);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(857, 380);
            this.dgvVentas.TabIndex = 46;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(16, 83);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 15);
            this.label20.TabIndex = 45;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(70, 62);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 14);
            this.label21.TabIndex = 44;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(13, 62);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 15);
            this.label22.TabIndex = 43;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(13, 42);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(154, 14);
            this.label23.TabIndex = 1;
            this.label23.Text = "Distribuidora de autos";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(13, 26);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 14);
            this.label24.TabIndex = 0;
            this.label24.Text = "Cosmo Autos";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(367, 93);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(88, 21);
            this.button6.TabIndex = 63;
            this.button6.Text = "Ver Todo";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(370, 77);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 21);
            this.button7.TabIndex = 63;
            this.button7.Text = "Ver Todo";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInventario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbxPersonal.ResumeLayout(false);
            this.gpbxPersonal.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCodigoBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gpbxPersonal;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoInventario;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.TextBox txtCompra;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dtgInventario;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}