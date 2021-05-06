
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
	public partial class frmReserve
	{
		public frmReserve()
		{
			InitializeComponent();
			

		}
		
#region Default Instance
		
		private static frmReserve defaultInstance;
		

		public static frmReserve Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmReserve();
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
		string trans_id;
		int id;
		int guest_id;
		int room_num;
		
		public void dtCheckOutDate_ValueChanged(System.Object sender, System.EventArgs e)
		{
			TimeSpan T = dtCheckOutDate.Value - dtCheckInDate.Value;
			if (T.Days < 1)
			{
				dtCheckOutDate.Text = System.Convert.ToString(dtCheckInDate.Value.Date.AddDays(1));
				txtDaysNumber.Text = "1";
			}
			else
			{
				txtDaysNumber.Text = T.Days.ToString();
			}
			lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			lblDateNow.Text = DateTime.Now.Date.ToString();
		}
		
		public void bttnSearchGuest_Click(System.Object sender, System.EventArgs e)
		{
			frmSelectGuest.Default.ShowDialog();
		}
		
		public void bttnSearchRoom_Click(System.Object sender, System.EventArgs e)
		{
			frmSelectRoom.Default.ShowDialog();
		}
		
		public void bttnCancel_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void frmReserve_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			string a = System.Convert.ToString(Interaction.MsgBox("¿Cancelar Transacción?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
			if (a == Constants.vbNo.ToString())
			{
				e.Cancel = true;
			}
			else
			{
				clear_text();
			}
		}
		private void clear_text()
		{
			txtGuestName.Clear();
			txtRoomNumber.Clear();
			txtRoomType.Clear();
			txtRoomRate.Clear();
			txtChildren.Text = "0";
			txtAdults.Text = "0";
			cboDiscount.Refresh();
			txtAdvance.Clear();
			txtSubTotal.Clear();
			txtTotal.Clear();
			lblDiscountID.Text = "";
			lblDiscountRate.Text = "";
			lblGuestID.Text = "";
			lblAdvancePayment.Text = "";
			lblNoOfOccupancy.Text = "0";
			
			DateTime time = DateTime.Now;
            string format = "d/MM/yyyy HH:mm:ss";
			dtCheckInDate.Text = time.ToString(format);
			dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
		}
		
		public void frmReserve_Load(object sender, System.EventArgs e)
		{
			clear_text();
			DateTime time = DateTime.Now;
            string format = "d/MM/yyyy HH:mm:ss";
			dtCheckInDate.Text = time.ToString(format);
			//dtCheckOutDate.Text = System.Convert.ToString(dtCheckInDate.Value.Date.AddDays(1));
            dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
			lblDateNow.Text = DateTime.Now.Date.ToString();
			transID();
			pop_discount();
			display_reserve();
		}
		
		public void transID()
		{
			
			Module1.con.Open();
			/*DataTable dt = new DataTable("tblTransaction");
			Module1.rs = new OleDbDataAdapter("SELECT * FROM tblTransaction ORDER BY TransID DESC", Module1.con);
			Module1.rs.Fill(dt);
			
			if (dt.Rows.Count == 0)
			{
				txtTransID.Text = "TransID - 0001";
			}
			else
			{
				int value = (int) (Conversion.Val(dt.Rows[0]["TransID"]));
				value++;
				txtTransID.Text = "TransID - " + value.ToString("0000");
			}
			Module1.rs.Dispose();*/
            OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblTransaction ORDER BY TransID DESC", Module1.con);

            DataSet ds = new DataSet();
            DataTable tblTransaction = new DataTable();

            adaptador.Fill(ds);
            tblTransaction = ds.Tables[0];

            if (tblTransaction.Rows.Count == 0)
            {
                txtTransID.Text = "TransID - 0001";
            }
            else
            {
                int value = (int)(Conversion.Val(tblTransaction.Rows[0]["TransID"].ToString()));
                value++;
                txtTransID.Text = "TransID - " + value.ToString("0000");
                //trans_ID = value;
            }
			Module1.con.Close();
			
		}
		
		private void pop_discount()
		{

            Module1.con.Open();
            /*
            DataTable dt = new DataTable();
			Module1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount", Module1.con);
			Module1.rs.Fill(dt);
			
			cboDiscount.Items.Clear();
			int i = default(int);
			for (i = 0; i <= dt.Rows.Count - 1; i++)
			{
				cboDiscount.Items.Add(dt.Rows[i]["DiscountType"]);
			}
			Module1.rs.Dispose();*/
            OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblDiscount", Module1.con);

            DataSet ds = new DataSet();
            DataTable tablaRoom = new DataTable();

            adaptador.Fill(ds);
            tablaRoom = ds.Tables[0];
            this.cboDiscount.Items.Clear();
            for (int i = 0; i < tablaRoom.Rows.Count; i++)
            {

                DataRow filas = tablaRoom.Rows[i];
                cboDiscount.Items.Add(filas["DiscountType"].ToString());
            }

			Module1.con.Close();
		}
		
		private void display_reserve()
		{
            Module1.con.Open();
			/*DataTable Dt = new DataTable("tblGuest");
			OleDbDataAdapter rs = default(OleDbDataAdapter);
			
			rs = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Reserve\'", Module1.con);
			
			rs.Fill(Dt);
			int indx = default(int);
			lvlreserve.Items.Clear();
			for (indx = 0; indx <= Dt.Rows.Count - 1; indx++)
			{
				ListViewItem lv = new ListViewItem();
				TimeSpan getdate = new TimeSpan();
				int days = default(int);
				int subtotal = default(int);
				int total = default(int);
				int rate = default(int);
				double discount = default(double);
				
				int value = (int) (Conversion.Val(Dt.Rows[indx]["TransID"]));
				
				lv.Text = "TransID - " + value.ToString("0000");
				lv.SubItems.Add(Dt.Rows[indx]["GuestFName"] + " " + Dt.Rows[indx]["GuestLName"]);
				lv.SubItems.Add(Dt.Rows[indx]["RoomNum"].ToString());
				
				rate = System.Convert.ToInt32(Dt.Rows[indx]["RoomRate"]);
				
				lv.SubItems.Add(Dt.Rows[indx]["CheckInDate"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["CheckOutDate"].ToString());
				
				dtIn.Value = System.Convert.ToDateTime(Dt.Rows[indx]["CheckOutDate"]);
				dtOut.Value = System.Convert.ToDateTime(Dt.Rows[indx]["CheckInDate"]);
				
				getdate = dtIn.Value - dtOut.Value;
				days = getdate.Days;
				
				lv.SubItems.Add(days.ToString());
				lv.SubItems.Add(Dt.Rows[indx]["NoOfChild"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["NoOfAdult"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["AdvancePayment"].ToString());
				lv.SubItems.Add(Dt.Rows[indx]["DiscountType"].ToString());
				
				discount = Conversion.Val(Dt.Rows[indx]["DiscountRate"]);
				
				subtotal = (int) ((days * rate) - ((days * rate) * discount));
				
				total = (int) (Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"]));
				
				lv.SubItems.Add(System.Convert.ToString(Conversion.Val(total.ToString())));
				lvlreserve.Items.Add(lv);
			}
			rs.Dispose();*/
            OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Reservado\'", Module1.con);

            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();

            adaptador.Fill(ds);
            tabla = ds.Tables[0];
            this.lvlreserve.Items.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {

                TimeSpan getdate = new TimeSpan();
                int days = default(int);
                int subtotal = default(int);
                int total = default(int);
                int rate = default(int);
                double discount = default(double);
                DataRow filas = tabla.Rows[i];

                int value = (int)(Conversion.Val(filas["TransID"].ToString()));


                ListViewItem elementos = new ListViewItem(Text = "TransID - " + value.ToString("0000"));
                elementos.SubItems.Add(filas["GuestMName"].ToString() + " " + filas["GuestLName"].ToString());
                elementos.SubItems.Add(filas["RoomNum"].ToString());

                rate = System.Convert.ToInt32(filas["RoomRate"].ToString());

                elementos.SubItems.Add(filas["CheckInDate"].ToString());
                elementos.SubItems.Add(filas["CheckOutDate"].ToString());

                dtIn.Value = System.Convert.ToDateTime(filas["CheckOutDate"].ToString());
                dtOut.Value = System.Convert.ToDateTime(filas["CheckInDate"].ToString());

                getdate = dtIn.Value - dtOut.Value;
                days = getdate.Days;

                elementos.SubItems.Add(days.ToString());
                elementos.SubItems.Add(filas["NoOfChild"].ToString());
                elementos.SubItems.Add(filas["NoOfAdult"].ToString());
                elementos.SubItems.Add(filas["AdvancePayment"].ToString());
                elementos.SubItems.Add(filas["DiscountType"].ToString());


                discount = Conversion.Val(filas["DiscountRate"].ToString());

                subtotal = (int)((days * rate) - ((days * rate) * discount));

                int ap = (int)(Conversion.Val(filas["AdvancePayment"].ToString()));

                int subap = subtotal - ap;

                total = System.Convert.ToInt32(Conversion.Val(subap).ToString());

                if (Conversion.Val(subtotal.ToString()) > Conversion.Val(filas["AdvancePayment"]))
                {
                    elementos.SubItems.Add(System.Convert.ToString(Conversion.Val(total.ToString())));
                }
                else
                {
                    elementos.SubItems.Add("0");
                }

                lvlreserve.Items.Add(elementos);
            }
            Module1.con.Close();
		}
		
		public void bttnReserve_Click(System.Object sender, System.EventArgs e)
		{
			int children = (int) (Conversion.Val(txtChildren.Text));
			int adult = (int) (Conversion.Val(txtAdults.Text));
			int advance = (int) (Conversion.Val(txtAdvance.Text));
			int discount = (int) (Conversion.Val(lblDiscountID.Text));
			string reserve = "0";
			string remarks = "Reservado";
			string stat = "Activo";
           			
			if (lblGuestID.Text == "GuestID" || lblGuestID.Text == null || txtRoomNumber.Text == null || Conversion.Val(System.Convert.ToString(children + adult)) == null || advance == null || discount == null)
			{
				Interaction.MsgBox("Por favor rellene todos los campos", Constants.vbInformation, "Nota");
			}
			else
			{
				string a = System.Convert.ToString(Interaction.MsgBox("¿Confirmar Reservación?", (int) Constants.vbQuestion + Constants.vbYesNo, "Reservación"));
				if (a == Constants.vbYes.ToString())
				{
					Module1.con.Open();
					OleDbCommand checkin = new OleDbCommand("INSERT INTO tblTransaction(GuestID,RoomNum,CheckInDate,CheckOutDate,ReservationDate,NoOfChild,NoOfAdult,AdvancePayment,DiscountID,Remarks,Status) values (\'" +
					lblGuestID.Text + "\',\'" +
					txtRoomNumber.Text + "\',\'" +
					dtCheckInDate.Text + "\',\'" +
					dtCheckOutDate.Text + "\',\'" +
					lblDateNow.Text + "\',\'" +
					txtChildren.Text + "\',\'" +
					txtAdults.Text + "\',\'" +
					txtAdvance.Text + "\',\'" +
					lblDiscountID.Text + "\',\'" +
					remarks + "\',\'" +
					stat + "\')", Module1.con);
					checkin.ExecuteNonQuery();
					
					OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Reservado\' WHERE ID = " + lblGuestID.Text + "", Module1.con);
					update_guest.ExecuteNonQuery();

                    OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Reservado\' WHERE RoomNumber =\'" + txtRoomNumber.Text + "\'", Module1.con);
					update_room.ExecuteNonQuery();
					
					Interaction.MsgBox("¡Huésped Reservado Exitosamente", Constants.vbInformation, "Reservación");
					clear_text();
					Module1.con.Close();
					transID();
					display_reserve();
				}
			}
		}
		
		public void dtCheckInDate_ValueChanged(System.Object sender, System.EventArgs e)
		{
			DateTime t = dtCheckInDate.Value;
			if (t.Date < DateTime.Now.Date)
			{
				dtCheckInDate.Value = DateTime.Now.Date;
			}
			else
			{
				dtCheckOutDate.Value = dtCheckInDate.Value.Date.AddDays(1);
			}
		}
		
		public void bttnAddAdult_Click(System.Object sender, System.EventArgs e)
		{
			int tao;
			tao = (int) (Conversion.Val(txtAdults.Text) + Conversion.Val(txtChildren.Text));
			if (tao == Conversion.Val(lblNoOfOccupancy.Text))
			{
				
			}
			else
			{
				txtAdults.Text = System.Convert.ToString(Conversion.Val(txtAdults.Text) + 1);
			}
		}
		
		public void bttnAddChildren_Click(System.Object sender, System.EventArgs e)
		{
			int tao;
			tao = (int) (Conversion.Val(txtAdults.Text) + Conversion.Val(txtChildren.Text));
			if (tao == Conversion.Val(lblNoOfOccupancy.Text))
			{
				
			}
			else
			{
				txtChildren.Text = System.Convert.ToString(Conversion.Val(txtChildren.Text) + 1);
			}
		}
		
		public void bttnSubAdult_Click(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtAdults.Text) == 0)
			{
				txtAdults.Text = System.Convert.ToString(Conversion.Val(txtAdults.Text));
			}
			else
			{
				txtAdults.Text = System.Convert.ToString(Conversion.Val(txtAdults.Text) - 1);
			}
		}
		
		public void bttnSubChildren_Click(System.Object sender, System.EventArgs e)
		{
			if (Conversion.Val(txtChildren.Text) == 0)
			{
				txtChildren.Text = System.Convert.ToString(Conversion.Val(txtChildren.Text));
			}
			else
			{
				txtChildren.Text = System.Convert.ToString(Conversion.Val(txtChildren.Text) - 1);
			}
		}
		
		public void cboDiscount_TextChanged(object sender, System.EventArgs e)
		{
			Module1.con.Open();
			/*DataTable dt = new DataTable();
			Module1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount WHERE DiscountType = \'" + cboDiscount.Text + "\'", Module1.con);
			Module1.rs.Fill(dt);
			
			lblDiscountID.Text = (string) (dt.Rows[0]["ID"]);
			lblDiscountRate.Text = (string) (dt.Rows[0]["DiscountRate"]);
			
			//lblTotal.Text = Val(txtSubTotal.Text) - (Val(txtSubTotal.Text) * Val(lblDiscountRate.Text))
			txtSubTotal.Text = System.Convert.ToString(Conversion.Val(lblTotal.Text) - (Conversion.Val(lblTotal.Text) * Conversion.Val(lblDiscountRate.Text)));
			lblAdvancePayment.Text = "Advance payment must be atleast Php " + (Conversion.Val(txtSubTotal.Text) * 0.5);
			Module1.rs.Dispose();
			Module1.con.Close();*/

            OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT * FROM tblDiscount WHERE DiscountType = \'" + cboDiscount.Text + "\'", Module1.con);

            DataSet ds = new DataSet();
            DataTable tablaRoom = new DataTable();

            adaptador.Fill(ds);
            tablaRoom = ds.Tables[0];


            DataRow filas = tablaRoom.Rows[0];
            lblDiscountID.Text = filas["ID"].ToString();
            lblDiscountRate.Text = filas["DiscountRate"].ToString();

            //lblTotal.Text = Val(txtSubTotal.Text) - (Val(txtSubTotal.Text) * Val(lblDiscountRate.Text))
            txtSubTotal.Text = System.Convert.ToString((Conversion.Val(lblTotal.Text) - (Conversion.Val(lblTotal.Text) * Conversion.Val(lblDiscountRate.Text))).ToString("00.00"));
            lblAdvancePayment.Text = "Pago adelantado debe ser por lo menos $ " + (Conversion.Val(txtSubTotal.Text) * 0.5).ToString("00.00");

            Module1.con.Close();
		}
		
		public void txtAdvance_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0'|| e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
			{
				//cancel keys
				e.Handled = true;
			}
		}
		
		public void txtAdvance_TextChanged(System.Object sender, System.EventArgs e)
		{
			//txtTotal.Text = System.Convert.ToString(Conversion.Val(lblTotal.Text) - Conversion.Val(txtAdvance.Text));

            if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
            {
                txtTotal.Text = "0.00";
            }
            else
            {
                txtTotal.Text = System.Convert.ToString((Conversion.Val(txtSubTotal.Text) - Conversion.Val(txtAdvance.Text)).ToString("00.00"));
            }
        
		}
		
		public void txtRoomRate_TextChanged(System.Object sender, System.EventArgs e)
		{
			lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
			txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
		}
		
		public void lvlreserve_Click(object sender, System.EventArgs e)
		{
			trans_id = lvlreserve.SelectedItems[0].Text;
			Module1.con.Open();
			DataTable dt = new DataTable("tblTransaction");
			Module1.rs = new OleDbDataAdapter("SELECT * FROM tblTransaction", Module1.con);
			Module1.rs.Fill(dt);
			int indx = default(int);
			for (indx = 0; indx <= dt.Rows.Count - 1; indx++)
			{
				if (trans_id == "TransID - " + Conversion.Val(dt.Rows[indx]["TransID"]).ToString("0000"))
				{
					guest_id = System.Convert.ToInt32(dt.Rows[0]["GuestID"]);
					room_num = System.Convert.ToInt32(dt.Rows[0]["RoomNum"]);
					id = System.Convert.ToInt32(dt.Rows[indx]["TransID"]);
					break;
				}
			}
			Module1.rs.Dispose();
			Module1.con.Close();
		}
		
		public void bttnCheckin_Click(System.Object sender, System.EventArgs e)
		{
			string check_in = System.Convert.ToString(Interaction.MsgBox("Checkin Guest?", (int) Constants.vbQuestion + Constants.vbYesNo, "Checkin"));
			if (check_in == Constants.vbYes.ToString())
			{
				Module1.con.Open();
				OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET Remarks = \'Checkin\' WHERE TransID = " + id.ToString() + "", Module1.con);
				update_trans.ExecuteNonQuery();
				
				OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Checkin\' WHERE ID = " + guest_id.ToString() + "", Module1.con);
				update_guest.ExecuteNonQuery();

                OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Ocupado\' WHERE RoomNumber =\'" + room_num.ToString() + "\'", Module1.con);
				update_room.ExecuteNonQuery();
				Module1.con.Close();
				display_reserve();
				Interaction.MsgBox("Huésped Checkedin!", Constants.vbInformation, "Checkin");
			}
		}
		
		public void bttnCancelReserve_Click(System.Object sender, System.EventArgs e)
		{
			string check_in = System.Convert.ToString(Interaction.MsgBox("¿Cancelar Reservación?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
			if (check_in == Constants.vbYes.ToString())
			{
				Module1.con.Open();
				
				OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET Remarks = \'Cancelado\' WHERE TransID = " + id.ToString() + "", Module1.con);
				update_trans.ExecuteNonQuery();
				
				OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Disponible\' WHERE ID = " + guest_id.ToString() + "", Module1.con);
				update_guest.ExecuteNonQuery();

                OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Disponible\' WHERE RoomNumber =\'" + room_num.ToString() + "\'", Module1.con);
				update_room.ExecuteNonQuery();
				
				Module1.con.Close();
				display_reserve();
				Interaction.MsgBox("¡Reservación Cancelada!", Constants.vbInformation, "Cancelar");
			}
		}
		
		public void lvlreserve_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			
		}
	}
}
