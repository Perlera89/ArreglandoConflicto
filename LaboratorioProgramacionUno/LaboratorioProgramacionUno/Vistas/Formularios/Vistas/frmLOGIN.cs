using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Formularios.Vistas
{
    public partial class frmLOGIN : Form
    {
        public frmLOGIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            frmOperaciones frm = new frmOperaciones();
            frm.Show();
            this.Hide();
        }
    }
}
