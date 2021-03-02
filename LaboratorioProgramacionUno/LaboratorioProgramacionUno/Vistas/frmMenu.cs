using LaboratorioProgramacionUno.Dominio;
using LaboratorioProgramacionUno.VIstas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioProgramacionUno
{
    public partial class Form1 : Form
    {
        ClsEntidades clsEntidades = new ClsEntidades();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void btnUsuario_Click(object sender, EventArgs e)
        {
            frmLogin frmLoginUser = new frmLogin();
            frmLoginUser.estadoU = false;
            frmLoginUser.Show();
            this.Hide();
        }

        public void btnAdministrador_Click(object sender, EventArgs e)
        {
            frmLogin frmLoginUser = new frmLogin();
            frmLoginUser.estadoU = true;
            frmLoginUser.Show();
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
