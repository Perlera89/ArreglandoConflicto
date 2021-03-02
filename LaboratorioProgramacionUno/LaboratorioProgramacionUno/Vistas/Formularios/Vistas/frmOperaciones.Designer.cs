
namespace Formularios.Vistas
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
            System.Windows.Forms.Label label5;
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btncalcular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtNombreDelProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioDelProducto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalIva = new System.Windows.Forms.Label();
            this.lblIvaAgregado = new System.Windows.Forms.Label();
            this.lblSindescuentos = new System.Windows.Forms.Label();
            this.lblTotalAPagar = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(22, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(974, 197);
            this.dataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ACCION";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "REGLA";
            this.Column2.Name = "Column2";
            // 
            // btncalcular
            // 
            this.btncalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btncalcular.Location = new System.Drawing.Point(482, 501);
            this.btncalcular.Name = "btncalcular";
            this.btncalcular.Size = new System.Drawing.Size(75, 23);
            this.btncalcular.TabIndex = 1;
            this.btncalcular.Text = "Calcular";
            this.btncalcular.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Iva";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(233, 248);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(100, 23);
            this.txtIva.TabIndex = 3;
            this.txtIva.TextChanged += new System.EventHandler(this.txtIva_TextChanged);
            // 
            // txtNombreDelProducto
            // 
            this.txtNombreDelProducto.Location = new System.Drawing.Point(233, 311);
            this.txtNombreDelProducto.Name = "txtNombreDelProducto";
            this.txtNombreDelProducto.Size = new System.Drawing.Size(100, 23);
            this.txtNombreDelProducto.TabIndex = 4;
            // 
            // txtPrecioDelProducto
            // 
            this.txtPrecioDelProducto.Location = new System.Drawing.Point(233, 369);
            this.txtPrecioDelProducto.Name = "txtPrecioDelProducto";
            this.txtPrecioDelProducto.Size = new System.Drawing.Size(100, 23);
            this.txtPrecioDelProducto.TabIndex = 5;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(233, 442);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 23);
            this.txtCantidad.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre del producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Precio del producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cantidad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(596, 229);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(56, 15);
            label5.TabIndex = 10;
            label5.Text = "Producto";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Location = new System.Drawing.Point(799, 280);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(38, 15);
            this.lblNombreProducto.TabIndex = 11;
            this.lblNombreProducto.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(613, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total sin iva:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(613, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Iva a agregar:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(480, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Total sin descuento y con IVA incluido:\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(613, 472);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Total a pagar:";
            // 
            // lblTotalIva
            // 
            this.lblTotalIva.AutoSize = true;
            this.lblTotalIva.Location = new System.Drawing.Point(759, 330);
            this.lblTotalIva.Name = "lblTotalIva";
            this.lblTotalIva.Size = new System.Drawing.Size(38, 15);
            this.lblTotalIva.TabIndex = 16;
            this.lblTotalIva.Text = "label6";
            // 
            // lblIvaAgregado
            // 
            this.lblIvaAgregado.AutoSize = true;
            this.lblIvaAgregado.Location = new System.Drawing.Point(759, 376);
            this.lblIvaAgregado.Name = "lblIvaAgregado";
            this.lblIvaAgregado.Size = new System.Drawing.Size(44, 15);
            this.lblIvaAgregado.TabIndex = 17;
            this.lblIvaAgregado.Text = "label11";
            // 
            // lblSindescuentos
            // 
            this.lblSindescuentos.AutoSize = true;
            this.lblSindescuentos.Location = new System.Drawing.Point(759, 427);
            this.lblSindescuentos.Name = "lblSindescuentos";
            this.lblSindescuentos.Size = new System.Drawing.Size(44, 15);
            this.lblSindescuentos.TabIndex = 18;
            this.lblSindescuentos.Text = "label12";
            // 
            // lblTotalAPagar
            // 
            this.lblTotalAPagar.AutoSize = true;
            this.lblTotalAPagar.Location = new System.Drawing.Point(759, 472);
            this.lblTotalAPagar.Name = "lblTotalAPagar";
            this.lblTotalAPagar.Size = new System.Drawing.Size(44, 15);
            this.lblTotalAPagar.TabIndex = 19;
            this.lblTotalAPagar.Text = "label13";
            // 
            // frmOperaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 547);
            this.Controls.Add(this.lblTotalAPagar);
            this.Controls.Add(this.lblSindescuentos);
            this.Controls.Add(this.lblIvaAgregado);
            this.Controls.Add(this.lblTotalIva);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblNombreProducto);
            this.Controls.Add(label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtPrecioDelProducto);
            this.Controls.Add(this.txtNombreDelProducto);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncalcular);
            this.Controls.Add(this.dataGridView);
            this.Name = "frmOperaciones";
            this.Text = "frmOperaciones";
            this.Load += new System.EventHandler(this.frmOperaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btncalcular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtNombreDelProducto;
        private System.Windows.Forms.TextBox txtPrecioDelProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalIva;
        private System.Windows.Forms.Label lblIvaAgregado;
        private System.Windows.Forms.Label lblSindescuentos;
        private System.Windows.Forms.Label lblTotalAPagar;
    }
}