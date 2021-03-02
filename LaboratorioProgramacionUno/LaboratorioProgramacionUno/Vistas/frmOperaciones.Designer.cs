
namespace LaboratorioProgramacionUno.VIstas
{
    partial class frmOperaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioDelProducto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lbProductoNombre = new System.Windows.Forms.Label();
            this.lbTotalSinIVA = new System.Windows.Forms.Label();
            this.lbIVAaAgregar = new System.Windows.Forms.Label();
            this.lbTotalSinDescuentoMasIVA = new System.Windows.Forms.Label();
            this.lbTotalConDescuento = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IVA";
            // 
            // txtIVA
            // 
            this.txtIVA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(236, 320);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(168, 26);
            this.txtIVA.TabIndex = 1;
            this.txtIVA.Text = "0.13";
            this.txtIVA.TextChanged += new System.EventHandler(this.txtIVA_TextChanged);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(308, 516);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(96, 28);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre del Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio del producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(587, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total a pagar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(543, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total sin descuento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(582, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "IVA a agregar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(587, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total sin IVA:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(542, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Producto";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(69, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(249, 29);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tabla de descuentos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(590, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "Usuario actual";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(625, 71);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(31, 18);
            this.lblUsuario.TabIndex = 13;
            this.lblUsuario.Text = "- - -";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(74, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 18);
            this.label12.TabIndex = 14;
            this.label12.Text = "Catidad";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProducto.Location = new System.Drawing.Point(236, 367);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(168, 26);
            this.txtNombreProducto.TabIndex = 15;
            this.txtNombreProducto.Text = "LAPTOP";
            // 
            // txtPrecioDelProducto
            // 
            this.txtPrecioDelProducto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioDelProducto.Location = new System.Drawing.Point(236, 418);
            this.txtPrecioDelProducto.Name = "txtPrecioDelProducto";
            this.txtPrecioDelProducto.Size = new System.Drawing.Size(168, 26);
            this.txtPrecioDelProducto.TabIndex = 16;
            this.txtPrecioDelProducto.Text = "100";
            this.txtPrecioDelProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioDelProducto_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(236, 467);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(168, 26);
            this.txtCantidad.TabIndex = 17;
            this.txtCantidad.Text = "1";
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // lbProductoNombre
            // 
            this.lbProductoNombre.AutoSize = true;
            this.lbProductoNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductoNombre.Location = new System.Drawing.Point(634, 328);
            this.lbProductoNombre.Name = "lbProductoNombre";
            this.lbProductoNombre.Size = new System.Drawing.Size(31, 18);
            this.lbProductoNombre.TabIndex = 18;
            this.lbProductoNombre.Text = "- - -";
            // 
            // lbTotalSinIVA
            // 
            this.lbTotalSinIVA.AutoSize = true;
            this.lbTotalSinIVA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalSinIVA.Location = new System.Drawing.Point(695, 375);
            this.lbTotalSinIVA.Name = "lbTotalSinIVA";
            this.lbTotalSinIVA.Size = new System.Drawing.Size(31, 18);
            this.lbTotalSinIVA.TabIndex = 19;
            this.lbTotalSinIVA.Text = "- - -";
            // 
            // lbIVAaAgregar
            // 
            this.lbIVAaAgregar.AutoSize = true;
            this.lbIVAaAgregar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIVAaAgregar.Location = new System.Drawing.Point(695, 426);
            this.lbIVAaAgregar.Name = "lbIVAaAgregar";
            this.lbIVAaAgregar.Size = new System.Drawing.Size(31, 18);
            this.lbIVAaAgregar.TabIndex = 20;
            this.lbIVAaAgregar.Text = "- - -";
            // 
            // lbTotalSinDescuentoMasIVA
            // 
            this.lbTotalSinDescuentoMasIVA.AutoSize = true;
            this.lbTotalSinDescuentoMasIVA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalSinDescuentoMasIVA.Location = new System.Drawing.Point(695, 472);
            this.lbTotalSinDescuentoMasIVA.Name = "lbTotalSinDescuentoMasIVA";
            this.lbTotalSinDescuentoMasIVA.Size = new System.Drawing.Size(31, 18);
            this.lbTotalSinDescuentoMasIVA.TabIndex = 21;
            this.lbTotalSinDescuentoMasIVA.Text = "- - -";
            // 
            // lbTotalConDescuento
            // 
            this.lbTotalConDescuento.AutoSize = true;
            this.lbTotalConDescuento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalConDescuento.Location = new System.Drawing.Point(695, 516);
            this.lbTotalConDescuento.Name = "lbTotalConDescuento";
            this.lbTotalConDescuento.Size = new System.Drawing.Size(31, 18);
            this.lbTotalConDescuento.TabIndex = 22;
            this.lbTotalConDescuento.Text = "- - -";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(555, 485);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 18);
            this.label18.TabIndex = 23;
            this.label18.Text = "y con IVA incluido";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(0, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 24;
            this.button1.Text = "btnSalir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(75, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(634, 150);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // column1
            // 
            this.column1.HeaderText = "ACCIÓN";
            this.column1.Name = "column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "REGLA";
            this.Column2.Name = "Column2";
            // 
            // frmOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(793, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lbTotalConDescuento);
            this.Controls.Add(this.lbTotalSinDescuentoMasIVA);
            this.Controls.Add(this.lbIVAaAgregar);
            this.Controls.Add(this.lbTotalSinIVA);
            this.Controls.Add(this.lbProductoNombre);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtPrecioDelProducto);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.label1);
            this.Name = "frmOperaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOperaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOperaciones_FormClosing);
            this.Load += new System.EventHandler(this.frmOperaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrecioDelProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtIVA;
        public System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lbProductoNombre;
        public System.Windows.Forms.Label lbTotalSinIVA;
        public System.Windows.Forms.Label lbIVAaAgregar;
        public System.Windows.Forms.Label lbTotalSinDescuentoMasIVA;
        public System.Windows.Forms.Label lbTotalConDescuento;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}