﻿
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
    public partial class frmCheckinList1 : Form
    {
        public frmCheckinList1()
        {
            InitializeComponent();
        }
       
        #region Default Instance

        private static frmCheckinList1 defaultInstance;


        public static frmCheckinList1 Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmCheckinList1();
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

        private void frmCheckinList1_Load(object sender, EventArgs e)
        {
            Module1.con.Open();

            /*DataTable Dt = new DataTable("tblTransaction");
            Module1.rs = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Checkin\' AND tblTransaction.Status = \'Active\'", Module1.con);
            Module1.rs.Fill(Dt);
			
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
                total = (int) (Conversion.Val(subtotal.ToString()) - Conversion.Val(Dt.Rows[indx]["AdvancePayment"]));
				
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
            Module1.rs.Dispose();
             */
            OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from tblTransaction, tblGuest, tblDiscount, tblRoom WHERE tblTransaction.GuestID = tblGuest.ID AND tblTransaction.DiscountID = tblDiscount.ID AND tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.Remarks = \'Checkin\' AND tblTransaction.Status = \'Activo\'", Module1.con);

            DataSet ds = new DataSet();
            DataTable tablaRoom = new DataTable();

            adaptador.Fill(ds);
            tablaRoom = ds.Tables[0];
            this.lvlcheckin.Items.Clear();
            for (int i = 0; i < tablaRoom.Rows.Count; i++)
            {

                TimeSpan getdate = new TimeSpan();
                int days = default(int);
                int subtotal = default(int);
                int total = default(int);
                int rate = default(int);
                double discount = default(double);

                DataRow filas = tablaRoom.Rows[i];
                int value = (int)(Conversion.Val(filas["TransID"].ToString()));

                ListViewItem elementos = new ListViewItem(filas["TransID"].ToString());

                Text = "TransID - " + value.ToString("0000");
                elementos.SubItems.Add(filas["GuestFName"].ToString() + " " + filas["GuestLName"].ToString());
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
                total = (int)(Conversion.Val(subtotal.ToString()) - Conversion.Val(filas["AdvancePayment"].ToString()));

                if (Conversion.Val(subtotal.ToString()) > Conversion.Val(filas["AdvancePayment"].ToString()))
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

        private void lvlcheckin_DoubleClick(object sender, EventArgs e)
        {
            dtIn.Value = DateTime.Parse(lvlcheckin.SelectedItems[0].SubItems[3].Text);
            dtOut.Value = DateTime.Now.Date;

            Module1.con.Open();
            DataTable dt = new DataTable("tblTransaction");
            Module1.rs = new OleDbDataAdapter("Select * from tblTransaction, tblRoom, tblDiscount WHERE tblTransaction.RoomNum = tblRoom.RoomNumber AND tblTransaction.DiscountID = tblDiscount.ID", Module1.con);
            Module1.rs.Fill(dt);
            int indx = default(int);
            double subtotal1 = Conversion.Val(frmCheckout.Default.txtDays.Text) * Conversion.Val(dt.Rows[indx]["RoomRate"]);
            subtotal1 = Conversion.Val(subtotal1.ToString()) - Conversion.Val(System.Convert.ToString(System.Convert.ToDouble((dt.Rows[indx]["DiscountRate"])) * Conversion.Val(subtotal1.ToString())));
            
            string guestid = (string)(dt.Rows[indx]["GuestID"].ToString());
                     
            for (indx = 0; indx <= dt.Rows.Count - 1; indx++)
            {
                double value = Conversion.Val(dt.Rows[indx]["TransID"].ToString());

                if (lvlcheckin.SelectedItems[0].Text == "TransID - " + value.ToString("0000"))
                {
                    frmCheckout.Default.txtTransID.Text = "TransID - " + value.ToString("0000");
                    frmCheckout.Default.lblTransID.Text = (string)(dt.Rows[indx]["TransID"].ToString());
                    frmCheckout.Default.lblGuestID.Text = (string)(dt.Rows[indx]["GuestID"].ToString());

                    DateTime time = DateTime.Now;
                    string format = "MM/d/yyyy";
                    TimeSpan getdate = new TimeSpan();
                    
                    if (dtIn.Value == dtOut.Value)
                    {
                        frmCheckout.Default.txtCheckout.Text = System.Convert.ToString(DateTime.Now.Date.AddDays(1));
                        frmCheckout.Default.txtDays.Text = "1";
                        double subtotal = Conversion.Val(frmCheckout.Default.txtDays.Text) * Conversion.Val(dt.Rows[indx]["RoomRate"]);
                        subtotal = Conversion.Val(subtotal.ToString()) - Conversion.Val(System.Convert.ToString(System.Convert.ToDouble((dt.Rows[indx]["DiscountRate"])) * Conversion.Val(subtotal.ToString())));

                        if (Conversion.Val(subtotal.ToString()) > Conversion.Val(dt.Rows[indx]["AdvancePayment"]))
                        {
                            double total = Conversion.Val(subtotal.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));

                            frmCheckout.Default.txtSubTotal.Text = (string)(Conversion.Val(subtotal.ToString()).ToString("N"));
                            frmCheckout.Default.txtTotal.Text = (string)(Conversion.Val(total.ToString()).ToString("N"));
                            frmCheckout.Default.txtCash.Text = (string)(Conversion.Val(total.ToString()).ToString("N"));
                            frmCheckout.Default.txtChange.Text = "0.00";
                        }
                        else
                        {
                            double total = System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"])) - Conversion.Val(subtotal.ToString());
                            double change = Conversion.Val(total.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));

                            frmCheckout.Default.txtSubTotal.Text = (string)(Conversion.Val(subtotal.ToString()).ToString("N"));
                            frmCheckout.Default.txtTotal.Text = "0.00";
                            frmCheckout.Default.txtCash.Text = "0.00";
                            frmCheckout.Default.txtChange.Text = (string)(Conversion.Val(total.ToString()).ToString("N"));
                        }

                    }
                    else
                    {
                        frmCheckout.Default.txtCheckout.Text = DateTime.Now.Date.ToString();

                        getdate = (dtOut.Value) - (dtIn.Value);
                        frmCheckout.Default.txtDays.Text = getdate.Days.ToString();

                        double subtotal = Conversion.Val(getdate.Days.ToString()) * Conversion.Val(dt.Rows[indx]["RoomRate"]);
                        subtotal = Conversion.Val(subtotal.ToString()) - Conversion.Val(System.Convert.ToString(System.Convert.ToDouble((dt.Rows[indx]["DiscountRate"])) * Conversion.Val(subtotal.ToString())));

                        if (Conversion.Val(subtotal.ToString()) > Conversion.Val(dt.Rows[indx]["AdvancePayment"]))
                        {
                            double total = Conversion.Val(subtotal.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));

                            frmCheckout.Default.txtSubTotal.Text = (string)(Conversion.Val(subtotal.ToString()).ToString("N"));
                            frmCheckout.Default.txtTotal.Text = (string)(Conversion.Val(total.ToString()).ToString("N"));
                            frmCheckout.Default.txtCash.Text = (string)(Conversion.Val(total.ToString()).ToString("N"));
                            frmCheckout.Default.txtChange.Text = "0.00";
                        }
                        else
                        {
                            double total = System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"])) - Conversion.Val(subtotal.ToString());
                            double change = Conversion.Val(total.ToString()) - System.Convert.ToDouble((dt.Rows[indx]["AdvancePayment"]));

                            frmCheckout.Default.txtSubTotal.Text = (string)(Conversion.Val(subtotal.ToString()).ToString("N"));
                            frmCheckout.Default.txtTotal.Text = "0.00";
                            frmCheckout.Default.txtCash.Text = "0.00";
                            frmCheckout.Default.txtChange.Text = (string)(Conversion.Val(total.ToString()).ToString("N"));
                        }
                    }

                    break;

                }
            }


            Module1.rs.Dispose();
            Module1.con.Close();
            
            //int value = (int)(Conversion.Val(tblTransaction.Rows[0]["TransID"].ToString()));
            //value++;
            //txtTransID.Text = "TransID - " + value.ToString("0000");
            //trans_ID = value;
         
            //frmCheckout.Default.txtTransID.Text = lvlcheckin.SelectedItems[0].Text;
            frmCheckout.Default.txtTransID.Text = lvlcheckin.SelectedItems[0].Text;
            frmCheckout.Default.txtGuestName.Text = lvlcheckin.SelectedItems[0].SubItems[1].Text;
            frmCheckout.Default.txtRoomNumber.Text = lvlcheckin.SelectedItems[0].SubItems[2].Text;
            frmCheckout.Default.txtCheckin.Text = lvlcheckin.SelectedItems[0].SubItems[3].Text;
            frmCheckout.Default.txtCheckout.Text = lvlcheckin.SelectedItems[0].SubItems[4].Text;
            frmCheckout.Default.txtDays.Text = lvlcheckin.SelectedItems[0].SubItems[5].Text;
            frmCheckout.Default.txtChildren.Text = lvlcheckin.SelectedItems[0].SubItems[6].Text;
            frmCheckout.Default.txtAdult.Text = lvlcheckin.SelectedItems[0].SubItems[7].Text;
            //frmCheckout.Default.txtSubTotal.Text = lvlcheckin.SelectedItems[0].SubItems[8].Text;
            frmCheckout.Default.txtSubTotal.Text = (string)(Conversion.Val(subtotal1.ToString()).ToString("N"));
            frmCheckout.Default.txtAdvance.Text = (string)(Conversion.Val(lvlcheckin.SelectedItems[0].SubItems[8].Text).ToString("N"));
            frmCheckout.Default.txtDiscountType.Text = lvlcheckin.SelectedItems[0].SubItems[9].Text;
            frmCheckout.Default.txtTotal.Text = lvlcheckin.SelectedItems[0].SubItems[10].Text;
            //frmCheckout.Default.lblTransID.Text = (string)(dt.Rows[indx]["TransID"].ToString());
            frmCheckout.Default.lblGuestID.Text = (string)(guestid.ToString());
            this.Close();
        }
    }
}
