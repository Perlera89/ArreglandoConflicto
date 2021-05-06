
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Linq;
using System;
using System.Collections;
using System.Xml.Linq;
using System.Windows.Forms;


using System.Data.OleDb;

namespace HBRS
{
    public partial class frmGuest
    {
        public frmGuest()
        {
            InitializeComponent();


        }

        #region Default Instance

        private static frmGuest defaultInstance;

        public static frmGuest Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmGuest();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

        public void bttnSave_Click(System.Object sender, System.EventArgs e)
        {
            Module1.con.Open();
            string fname = txtFName.Text.Trim();
            string mname = txtMName.Text.Trim();
            string lname = txtLName.Text.Trim();
            string add = txtAddress.Text.Trim();
            string num = txtNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string stat = "Activo";
            string remark = "Disponible";

            if (fname == null || mname == null || lname == null || add == null || num == null)
            {
                Interaction.MsgBox("Por favor rellene todos los campos", Constants.vbInformation, "Nota");
            }
            else
            {
                OleDbCommand add_guest = new OleDbCommand("INSERT INTO tblGuest(GuestFName,GuestMName,GuestLName,GuestAddress,GuestContactNumber,GuestGender,GuestEmail,Status,Remarks) values (\'" +
                fname + "\',\'" +
                mname + "\',\'" +
                lname + "\',\'" +
                add + "\',\'" +
                num + "\',\'" +
                cboGender.Text + "\',\'" +
                email + "\',\'" +
                stat + "\',\'" +
                remark + "\')", Module1.con);
                add_guest.ExecuteNonQuery();
                add_guest.Dispose();
                Interaction.MsgBox("¡Huésped Agregado!", Constants.vbInformation, "Nota");
                txtFName.Clear();
                txtMName.Clear();
                txtLName.Clear();
                txtAddress.Clear();
                txtNumber.Clear();
                txtEmail.Clear();
            }
            Module1.con.Close();
            display_guest();
        }

        public void frmGuest_Load(System.Object sender, System.EventArgs e)
        {
            display_guest();
            TabControl1.SelectTab(0);
        }

        private void display_guest()
        {
            Module1.con.Open();
            //DataTable Dt = new DataTable("tblGuest");
            //OleDbDataAdapter rs = default(OleDbDataAdapter);

            //rs = new OleDbDataAdapter("Select ID,GuestFName,GuestMName,GuestLName,GuestAddress,GuestContactNumber,Status from tblGuest", Module1.con);

            /*rs.Fill(Dt);
            int indx = default(int);
            lvGuest.Items.Clear();
            for (indx = 0; indx <= Dt.Rows.Count - 1; indx++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = (string) (Dt.Rows[indx]["ID"]);
                lv.SubItems.Add(Dt.Rows[indx]["GuestFName"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["GuestMName"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["GuestLName"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["GuestAddress"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["GuestContactNumber"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["Status"].ToString());
                lvGuest.Items.Add(lv);
            }
            rs.Dispose();*/
            OleDbDataAdapter adaptador = new OleDbDataAdapter("Select ID,GuestFName,GuestMName,GuestLName,GuestAddress,GuestContactNumber,Status from tblGuest", Module1.con);

            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();

            adaptador.Fill(ds);
            tabla = ds.Tables[0];
            this.lvGuest.Items.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {

                DataRow filas = tabla.Rows[i];
                ListViewItem elementos = new ListViewItem(filas["ID"].ToString());
                elementos.SubItems.Add(filas["GuestFName"].ToString());
                elementos.SubItems.Add(filas["GuestMName"].ToString());
                elementos.SubItems.Add(filas["GuestLName"].ToString());
                elementos.SubItems.Add(filas["GuestAddress"].ToString());
                elementos.SubItems.Add(filas["GuestContactNumber"].ToString());
                elementos.SubItems.Add(filas["Status"].ToString());

                lvGuest.Items.Add(elementos);
            }



            Module1.con.Close();
        }

        public void bttnCancel_Click(System.Object sender, System.EventArgs e)
        {
            txtFName.Clear();
            txtMName.Clear();
            txtLName.Clear();
            txtAddress.Clear();
            txtNumber.Clear();
            txtEmail.Clear();
        }
    }
}
