
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
	public partial class frmDiscount
	{
		public frmDiscount()
		{
			InitializeComponent();
			
		}
		
#region Default Instance
		
		private static frmDiscount defaultInstance;

		public static frmDiscount Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmDiscount();
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
		bool update_discount = false;
		int id;
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			clear_txt();
			update_discount = false;
		}
		
		public void frmDiscount_Load(System.Object sender, System.EventArgs e)
		{
			display_discount();
			clear_txt();
		}
		
		private void display_discount()
		{
			Module1.con.Open();
			/*DataTable dt = new DataTable("tblDiscount");
			Module1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount", Module1.con);
			Module1.rs.Fill(dt);
			
			lvlDiscount.Items.Clear();
			
			int indx = default(int);
			for (indx = 0; indx <= dt.Rows.Count - 1; indx++)
			{
				ListViewItem lv = new ListViewItem();
				lv.Text = (string) (dt.Rows[indx]["ID"]);
				lv.SubItems.Add(dt.Rows[indx]["DiscountType"].ToString());
				lv.SubItems.Add(dt.Rows[indx]["DiscountRate"].ToString());
				lvlDiscount.Items.Add(lv);
			}
			Module1.rs.Dispose();
			Module1.con.Close();*/
            OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblDiscount", Module1.con);

            DataSet ds = new DataSet();
            DataTable tablaRoom = new DataTable();

            adaptador.Fill(ds);
            tablaRoom = ds.Tables[0];
            this.lvlDiscount.Items.Clear();
            for (int i = 0; i < tablaRoom.Rows.Count; i++)
            {

                DataRow filas = tablaRoom.Rows[i];
                ListViewItem elementos = new ListViewItem(filas["ID"].ToString());
                elementos.SubItems.Add(filas["DiscountType"].ToString());
                elementos.SubItems.Add(filas["DiscountRate"].ToString());
                lvlDiscount.Items.Add(elementos);
            }
            Module1.con.Close();
		}
		
			
		public void bttnSave_Click(System.Object sender, System.EventArgs e)
		{
			//if (txtType.Text.Trim() == null | bool.Parse(txtRate.Text.Trim()))
            //if (txtType.Text.Trim() == null | txtRate.Text.ToString("0%"))
            if (txtType.Text.Trim() == null || txtRate.Text.Trim() == null || id==null)
			{
				Interaction.MsgBox("Completar todos los Campos!", Constants.vbInformation, "Nota");
				return;
			}
			string a = System.Convert.ToString(Interaction.MsgBox("¿Guardar Descuento?", (int) Constants.vbQuestion + Constants.vbYesNo, "Guardar"));
			if (a == Constants.vbYes.ToString())
			{
				if (update_discount == false)
				{
					Module1.con.Open();
					OleDbCommand save = new OleDbCommand("INSERT INTO tblDiscount(DiscountType,DiscountRate,Status) values (\'" + txtType.Text.Trim() + "\',\'" + Conversion.Val(txtRate.Text.Trim()) / 100 + "\',\'Activo\')", Module1.con);
					save.ExecuteNonQuery();
					Module1.con.Close();
				}
				else
				{
					Module1.con.Open();
					OleDbCommand update = new OleDbCommand("UPDATE tblDiscount SET DiscountType = \'" + txtType.Text.Trim() + "\',DiscountRate = \'" + Conversion.Val(txtRate.Text.Trim()) / 100 + "\' WHERE ID = " + id.ToString() + "", Module1.con);
					update.ExecuteNonQuery();
					Module1.con.Close();
				}
				Interaction.MsgBox("Información Guardada Exitosamente!", Constants.vbInformation, "Descuentos");
				display_discount();
				clear_txt();
			}
			
		}
		
		private void clear_txt()
		{
			txtType.Clear();
			txtRate.Clear();
			update_discount = false;
		}
		
		public void lvlDiscount_DoubleClick(object sender, System.EventArgs e)
		{
			string a = System.Convert.ToString(Interaction.MsgBox("¿Actualizar información seleccionada?", (int) Constants.vbQuestion + Constants.vbYesNo, "Actualizar Descuento"));
			if (a == Constants.vbYes.ToString())
			{
				id = int.Parse(lvlDiscount.SelectedItems[0].Text);
				txtType.Text = lvlDiscount.SelectedItems[0].SubItems[1].Text;
				txtRate.Text = System.Convert.ToString(Conversion.Val(lvlDiscount.SelectedItems[0].SubItems[2].Text) * 100);
				update_discount = true;
				bttnSave.Text = "&Actualizar";
			}
		}

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
            {
                //cancel keys
                e.Handled = true;
            }
        }
	}
}
