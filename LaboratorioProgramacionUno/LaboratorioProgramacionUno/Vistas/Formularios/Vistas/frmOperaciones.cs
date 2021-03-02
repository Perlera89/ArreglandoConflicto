using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Formularios.Vistas
{
    public partial class frmOperaciones : Form
    {
        public frmOperaciones()
        {
            InitializeComponent();
        }

        private void frmOperaciones_Load(object sender, EventArgs e)
        {
            ClsReglas cls = new ClsReglas();

           foreach(var iteracion in cls.regla)
            {
                dataGridView.Rows.Add(iteracion.ToString());
            }       
            
        }

        private void txtIva_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
