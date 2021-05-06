
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
	public partial class frmCheckout
	{
		public frmCheckout()
		{
			InitializeComponent();
			
			
		}
		
#region Default Instance
		
		private static frmCheckout defaultInstance;
		
		public static frmCheckout Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmCheckout();
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
		
		public void bttnSearchGuest_Click(System.Object sender, System.EventArgs e)
		{
			frmCheckinList1.Default.ShowDialog();
		}
		
		public void txtRoomNumber_TextChanged(System.Object sender, System.EventArgs e)
		{
            if (txtRoomNumber.Text == null)
            {

            }
            else
            {
                Module1.con.Open();
                /*DataTable dt = new DataTable("tblRoom");
                Module1.rs = new OleDbDataAdapter("SELECT * FROM tblRoom WHERE RoomNumber =" + txtRoomNumber.Text + "", Module1.con);
                Module1.rs.Fill(dt);
                txtRoomType.Text = (string) (dt.Rows[0]["RoomType"].ToString());
                txtRoomRate.Text = (string) (Conversion.Val(dt.Rows[0]["RoomRate"]).ToString("N"));
                Module1.rs.Dispose();*/


                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblRoom WHERE RoomNumber = \'" + txtRoomNumber.Text + "\'", Module1.con);

                DataSet ds = new DataSet();
                DataTable tabla = new DataTable();

                adaptador.Fill(ds);
                tabla = ds.Tables[0];
                
                for (int i = 0; i < tabla.Rows.Count; i++)
                {

                    DataRow filas = tabla.Rows[i];
                    txtRoomType.Text = (string)(filas["RoomType"].ToString());
                    txtRoomRate.Text = (string)(Conversion.Val(filas["RoomRate"]).ToString("N"));
                    //elementos.SubItems.Add(filas["GuestLName"].ToString());

                }
                Module1.con.Close();

            }
			
		}
		
		public void txtCash_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0'|| e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
			{
				//cancel keys
				e.Handled = true;
			}
		}
		
		public void txtCash_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtCash.Text) < Conversion.Val(txtTotal.Text))
			{
				txtChange.Text = "0.00";
			}
			else
			{
				txtChange.Text = System.Convert.ToString((Conversion.Val(txtCash.Text) - Conversion.Val(txtTotal.Text)).ToString("N"));
			}
		}
		
		public void bttnCheckout_Click(System.Object sender, System.EventArgs e)
		{
			if (txtTransID.Text == null)
			{
				Interaction.MsgBox("Por favor seleccionar transacción para checkout!", Constants.vbExclamation, "Nota");
			}
			else
			{
				if (Conversion.Val(txtCash.Text) < Conversion.Val(txtTotal.Text))
				{
					Interaction.MsgBox("Efectivo Insuficiente!", Constants.vbExclamation, "Nota");
				}
				else
				{
                                   
                    string @out1 = System.Convert.ToString(Interaction.MsgBox("Confirmar Checkout", (int) Constants.vbQuestion + Constants.vbYesNo, "Checkout"));
					if (@out1 == Constants.vbYes.ToString())
					{
						Module1.con.Open();
						OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET Remarks = \'Checkout\' WHERE TransID = " + txtTransID.Text + "", Module1.con);
						update_trans.ExecuteNonQuery();
						
						OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Disponible\' WHERE ID = " + lblGuestID.Text + "", Module1.con);
						update_guest.ExecuteNonQuery();

                        OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Disponible\' WHERE RoomNumber = \'" + txtRoomNumber.Text + "\'", Module1.con);
						update_room.ExecuteNonQuery();
						
						Interaction.MsgBox("Huésped Checked out!", Constants.vbInformation, "Checkout");
                        Module1.con.Close();
                        clear_text();
                        
					}
                    Module1.con.Close();
				}
			}
		}
		
		public void clear_text()
		{
			txtTransID.Clear();
			txtGuestName.Clear();
			txtRoomNumber.Clear();
			txtRoomRate.Clear();
			txtRoomType.Clear();
			txtCheckin.Clear();
			txtCheckout.Clear();
			txtChildren.Clear();
			txtAdult.Clear();
			txtAdvance.Clear();
			txtDiscountType.Clear();
			txtTotal.Clear();
			txtSubTotal.Clear();
			txtDays.Clear();
			txtCash.Clear();
			txtChange.Clear();
		}
		
			
		public void frmCheckout_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
            string a = System.Convert.ToString(Interaction.MsgBox("¿Cancelar Transacción?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
            if (a == Constants.vbNo.ToString())
            {
                e.Cancel = true;
               
            }
            else
            {
                clear_text();
               
            }
		}
		
		public void frmCheckout_Load(System.Object sender, System.EventArgs e)
		{
			txtRoomNumber.Clear();
			dtOut.Value = DateTime.Now;
		}
		
		public void txtAdvance_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void txtTotal_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
		
		
		public void txtDiscountType_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
	}
}
