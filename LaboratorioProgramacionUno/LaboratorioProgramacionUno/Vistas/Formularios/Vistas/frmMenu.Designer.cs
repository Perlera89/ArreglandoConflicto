
namespace Formularios
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(77, 85);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(124, 86);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "USUARIO";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.Location = new System.Drawing.Point(315, 85);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(124, 86);
            this.btnAdministrador.TabIndex = 1;
            this.btnAdministrador.Text = "ADMINISTRADOR";
            this.btnAdministrador.UseVisualStyleBackColor = true;
            this.btnAdministrador.Click += new System.EventHandler(this.btnAdministrador_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Enabled = false;
            this.lblBienvenida.Location = new System.Drawing.Point(175, 27);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(191, 15);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "SEAN BIEVENIDOS A LA EMPERESA";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 203);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnAdministrador);
            this.Controls.Add(this.btnUsuario);
            this.Name = "frmMenu";
            this.Text = "MENU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Label lblBienvenida;
    }
}

