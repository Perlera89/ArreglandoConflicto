using LaboratorioProgramacionUno.Dominio;
using LaboratorioProgramacionUno.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioProgramacionUno.VIstas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public Boolean estadoU;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //ClsLoginAdmin clsLoginAdmin = new ClsLoginAdmin();
            //Form1 frmMenu = new Form1();
            frmOperaciones _frmOperaciones = new frmOperaciones();



            //int accederAdmin = clsLoginAdmin.accesoAdmin(clsEntidad);

            if ((this.txtUser.Text == "") && (this.txtPass.Text == ""))
            {
                MessageBox.Show("Llene los campos");

            }
            else
            {
                if (estadoU == false)
                {
                    ClsEntidades clsEntidad1 = new ClsEntidades();
                    ClsLogin clsLogin = new ClsLogin();
                    clsEntidad1.User = txtUser.Text;
                    clsEntidad1.UserPass = txtPass.Text;

                    Boolean acceder1 = clsLogin.acceso1(clsEntidad1);

                    if (acceder1 == true)
                    {
                        MessageBox.Show("Bienvenido " + txtUser.Text);
                        _frmOperaciones.usuarioEstado = txtUser.Text;
                        _frmOperaciones.Show();
                        this.Hide();
                        _frmOperaciones.txtIVA.Enabled = false;
                        _frmOperaciones.txtNombreProducto.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta");
                    }
                }
                else
                {
                    ClsEntidades clsEntidad2 = new ClsEntidades();
                    ClsLogin clsLogin2 = new ClsLogin();
                    clsEntidad2.Admin = txtUser.Text;
                    clsEntidad2.AdminPass = txtPass.Text;

                    Boolean acceder2 = clsLogin2.acceso2(clsEntidad2);

                    if (acceder2 == true)
                    {
                        MessageBox.Show("Bienvenido " + txtUser.Text);
                        _frmOperaciones.usuarioEstado = txtUser.Text;
                        _frmOperaciones.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecta");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnEntrar.PerformClick();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnEntrar.PerformClick();
            }
        }
    }
}
