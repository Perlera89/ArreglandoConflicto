using Formularios.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome");
            frmLOGIN lg = new frmLOGIN();
            lg.Show();
            this.Hide();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome");
            frmLOGIN lg = new frmLOGIN();
            lg.Show();
            this.Hide();
        }
    }
}
