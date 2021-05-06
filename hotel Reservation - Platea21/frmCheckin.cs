
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
    public partial class frmCheckin
    {
        public frmCheckin()
        {
            InitializeComponent();
        }

        #region Default Instance

        private static frmCheckin defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static frmCheckin Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmCheckin();
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
        int guestID;
        int roomID;
        int trans_ID;

        public void frmCheckin_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            string a = System.Convert.ToString(Interaction.MsgBox("�Cancelar Transacci�n?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cancelar"));
            if (a == Constants.vbNo.ToString())
            {
                e.Cancel = true;
            }
            else
            {
                clear_text();
            }
        }
        public void frmCheckin_Load(System.Object sender, System.EventArgs e)
        {
            clear_text();
            DateTime time = DateTime.Now;
            string format = "d/MM/yyyy HH:mm:ss";
            txtCheckInDate.Text = time.ToString(format);
            dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
            transID();
            pop_discount();
            display_checkin();
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
                trans_ID = value;
            }
            Module1.rs.Dispose();
             */
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
                trans_ID = value;
            }

            Module1.con.Close();
        }

        public void bttnCheckIn_Click_1(System.Object sender, System.EventArgs e)
        {
            int children = (int)(Conversion.Val(txtChildren.Text));
            int adult = (int)(Conversion.Val(txtAdults.Text));
            int advance = (int)(Conversion.Val(txtAdvance.Text));
            int discount = (int)(Conversion.Val(lblDiscountID.Text));
            string reserve = "0";
            string remarks = "Checkin";
            string stat = "Activo";

            if (lblGuestID.Text == "GuestID" || lblGuestID.Text == null || txtRoomNumber.Text == null || Conversion.Val(System.Convert.ToString(children + adult)) == null || advance == null || discount == null)
            {
                Interaction.MsgBox("Por favor complete todos los campos", Constants.vbInformation, "Nota");
            }
            else
            {
                if (Conversion.Val(System.Convert.ToString(Conversion.Val(txtSubTotal.Text) * 0.5)) > Conversion.Val(txtAdvance.Text))
                {
                    MessageBox.Show("Ops");
                    return;
                }
                string a = System.Convert.ToString(Interaction.MsgBox("�Confirmar Checkin?", (int)Constants.vbQuestion + Constants.vbYesNo, "Check In"));
                if (a == Constants.vbYes.ToString())
                {
                    Module1.con.Open();
                    OleDbCommand checkin = new OleDbCommand("INSERT INTO tblTransaction(GuestID,RoomNum,CheckInDate,CheckOutDate,NoOfChild,NoOfAdult,AdvancePayment,DiscountID,Remarks,Status) values (\'" +
                    lblGuestID.Text + "\',\'" +
                    txtRoomNumber.Text + "\',\'" +
                    txtCheckInDate.Text + "\',\'" +
                    dtCheckOutDate.Text + "\',\'" +
                    txtChildren.Text + "\',\'" +
                    txtAdults.Text + "\',\'" +
                    txtAdvance.Text + "\',\'" +
                    lblDiscountID.Text + "\',\'" +
                    remarks + "\',\'" +
                    stat + "\')", Module1.con);
                    checkin.ExecuteNonQuery();

                    OleDbCommand update_guest = new OleDbCommand("UPDATE tblGuest SET Remarks = \'Checkin\' WHERE ID = " + lblGuestID.Text + "", Module1.con);
                    update_guest.ExecuteNonQuery();

                    OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET Status = \'Ocupado\' WHERE RoomNumber = \'" + txtRoomNumber.Text + "\'", Module1.con);
                    update_room.ExecuteNonQuery();

                    if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
                    {
                        Interaction.MsgBox("Checkin de Hu�sped Exitoso! " + "Cambiar: $ " + Conversion.Val(System.Convert.ToString(Conversion.Val(txtAdvance.Text) - Conversion.Val(txtSubTotal.Text))).ToString("00.00"), Constants.vbInformation, "Check In");
                        string change = System.Convert.ToString(Interaction.MsgBox("�Devolvio el Cambio al cliente?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cambiar"));
                        if (change == Constants.vbYes.ToString())
                        {
                            OleDbCommand update_trans = new OleDbCommand("UPDATE tblTransaction SET AdvancePayment = " + Conversion.Val(txtSubTotal.Text) + " WHERE TransID = " + trans_ID.ToString() + "", Module1.con);
                            update_trans.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Interaction.MsgBox("Checkin de Hu�sped Exitoso!", Constants.vbInformation, "Check In");
                    }

                    clear_text();
                    Module1.con.Close();
                    transID();
                    display_checkin();
                }
            }
        }

        public void bttnCancel_Click(System.Object sender, System.EventArgs e)
        {
            clear_text();
        }

        public void dtCheckOutDate_ValueChanged_1(System.Object sender, System.EventArgs e)
        {
            TimeSpan T = dtCheckOutDate.Value - DateTime.Now;
            if (T.Days < 1)
            {
                dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
                txtDaysNumber.Text = "1";
            }
            else
            {
                txtDaysNumber.Text = System.Convert.ToString(T.Days + 1);
            }
            lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
            txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
        }

        public void bttnSearchGuest_Click(System.Object sender, System.EventArgs e)
        {
            frmSelectGuest.Default.ShowDialog();
        }

        public void bttnSearchRoom_Click(System.Object sender, System.EventArgs e)
        {
            frmSelectRoom.Default.ShowDialog();
        }

        public void txtRoomRate_TextChanged(System.Object sender, System.EventArgs e)
        {
            lblTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
            txtSubTotal.Text = System.Convert.ToString((Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text)).ToString("00.00"));
        }

        public void bttnAddAdult_Click(System.Object sender, System.EventArgs e)
        {
            int tao;
            tao = (int)(Conversion.Val(txtAdults.Text) + Conversion.Val(txtChildren.Text));
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
            tao = (int)(Conversion.Val(txtAdults.Text) + Conversion.Val(txtChildren.Text));
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

        private void pop_discount()
        {
            Module1.con.Open();

            /*DataTable dt = new DataTable();
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

        public void cboDiscount_TextChanged(object sender, System.EventArgs e)
        {
            Module1.con.Open();

            /*DataTable dt = new DataTable();
            Module1.rs = new OleDbDataAdapter("SELECT * FROM tblDiscount WHERE DiscountType = \'" + cboDiscount.Text + "\'", Module1.con);
            Module1.rs.Fill(dt);
			
            lblDiscountID.Text = (string) (dt.Rows[0]["ID"]);
            lblDiscountRate.Text = (string) (dt.Rows[0]["DiscountRate"]);
			
            //lblTotal.Text = Val(txtSubTotal.Text) - (Val(txtSubTotal.Text) * Val(lblDiscountRate.Text))
            txtSubTotal.Text = System.Convert.ToString((Conversion.Val(lblTotal.Text) - (Conversion.Val(lblTotal.Text) * Conversion.Val(lblDiscountRate.Text))).ToString("00.00"));
            lblAdvancePayment.Text = "Advance payment must be atleast Php " + (Conversion.Val(txtSubTotal.Text) * 0.5).ToString("00.00");
            Module1.rs.Dispose();
            */
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
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != ControlChars.Back && e.KeyChar != '.')
            {
                //cancel keys
                e.Handled = true;
            }
        }

        public void txtAdvance_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
            {
                txtTotal.Text = "0.00";
            }
            else
            {
                txtTotal.Text = System.Convert.ToString((Conversion.Val(txtSubTotal.Text) - Conversion.Val(txtAdvance.Text)).ToString("00.00"));
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
            txtCheckInDate.Text = time.ToString(format);
            dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
        }

        private void display_checkin()
        {
            Module1.con.Open();

            /*DataTable Dt = new DataTable("tblGuest");
            OleDbDataAdapter rs = default(OleDbDataAdapter);
			
            rs = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Checkin\' AND tblTransaction.Status = \'Active\'", Module1.con);
			
            rs.Fill(Dt);
            int indx = default(int);
            lvlcheckin.Items.Clear();
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
                total = System.Convert.ToInt32(((Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"])).ToString("00.00")));
				
                if (Conversion.Val(subtotal.ToString()) > Conversion.Val(Dt.Rows[indx]["AdvancePayment"]))
                {
                    lv.SubItems.Add(System.Convert.ToString(Conversion.Val(total.ToString())));
                }
                else
                {
                    lv.SubItems.Add("0");
                }
				
                lvlcheckin.Items.Add(lv);
            }
            rs.Dispose();*/

            OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Checkin\' AND tblTransaction.Status = \'Activo\'", Module1.con);

            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();

            adaptador.Fill(ds);
            tabla = ds.Tables[0];
            this.lvlcheckin.Items.Clear();
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

                //total = System.Convert.ToInt32(Conversion.Val(Conversion.Val(subtotal.ToString()) - Conversion.Val(ap.ToString())).ToString("00.00")     );

                //total = System.Convert.ToInt32(((Conversion.Val(subtotal.ToString()) - Conversion.Val(filas["AdvancePayment"])).ToString()));
                total = System.Convert.ToInt32(Conversion.Val(subap).ToString());

                if (Conversion.Val(subtotal.ToString()) > Conversion.Val(filas["AdvancePayment"]))
                {
                    elementos.SubItems.Add(System.Convert.ToString(Conversion.Val(total.ToString())));
                }
                else
                {
                    elementos.SubItems.Add("0");
                }

                lvlcheckin.Items.Add(elementos);
            }
            Module1.con.Close();
        }

                 
    }
}
