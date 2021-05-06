
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


using Microsoft.VisualBasic.CompilerServices;

namespace HBRS
{
	public partial class frmMain
	{
		public frmMain()
		{
			InitializeComponent();

		}
		
#region Default Instance
		
		private static frmMain defaultInstance;

		public static frmMain Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmMain();
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
		
		public void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			string exit_app = System.Convert.ToString(Interaction.MsgBox("�Salir del Sistema?", (int) Constants.vbQuestion + Constants.vbYesNo, "Salir"));
			if (exit_app == Constants.vbNo.ToString())
			{
				e.Cancel = true;
			}
			else
			{
				ProjectData.EndApp();
			}
		}
		
		public void toolbarCheckIn_Click(System.Object sender, System.EventArgs e)
		{
			frmCheckin.Default.ShowDialog();
		}
		
		public void ToolStripButton13_Click(System.Object sender, System.EventArgs e)
		{
			string exit_app = System.Convert.ToString(Interaction.MsgBox("�Salir del Sistema?", (int) Constants.vbQuestion + Constants.vbYesNo, "Salir"));
			if (exit_app == Constants.vbYes.ToString())
			{
				ProjectData.EndApp();
			}
		}
		
		public void ToolStripButton12_Click(System.Object sender, System.EventArgs e)
		{
			string out_app = System.Convert.ToString(Interaction.MsgBox("�Cerrar Sesi�n?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cerrar Sesi�n"));
			if (out_app == Constants.vbYes.ToString())
			{
				Module1.con.Close();
				this.Hide();
                frmLogin.Default.ShowDialog();
			}
		}
		
		public void ToolStripButton10_Click(System.Object sender, System.EventArgs e)
		{
			frmGuest.Default.ShowDialog();
		}
		
		public void toolbarRoom_Click(System.Object sender, System.EventArgs e)
		{
			frmRoom.Default.ShowDialog();
		}
		
		public void toolbarReserve_Click(System.Object sender, System.EventArgs e)
		{
			frmReserve.Default.ShowDialog();
		}
		
		public void NewCheckInToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmCheckin.Default.ShowDialog();
		}
		
		public void NewReservationToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmReserve.Default.ShowDialog();
		}
		
		public void LogoutToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			string out_app = System.Convert.ToString(Interaction.MsgBox("�Cerrar Sesi�n del Sistema?", (int) Constants.vbQuestion + Constants.vbYesNo, "Cerrar Sesi�n"));
			if (out_app == Constants.vbYes.ToString())
			{
				this.Hide();
				frmLogin.Default.Show();
			}
		}
		
		public void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void toolbarCheckOut_Click(System.Object sender, System.EventArgs e)
		{
			frmCheckout.Default.ShowDialog();
		}
		
		public void SettingsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void FileToolStripMenuItem1_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void CheckedInListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmCheckinListMonitor.Default.ShowDialog();
		}
		
		public void RoomStatusToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmRoomListMonitor.Default.ShowDialog();
		}
		
		public void ReservedListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmReserveListMonitor.Default.ShowDialog();
		}
		
		public void CheckedOutListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmCheckOutList.Default.ShowDialog();
		}
		
		public void Timer1_Tick(System.Object sender, System.EventArgs e)
		{
			DateTime datenow = DateTime.Now;
			status.Items[2].Text = "Fecha y Hora : " + datenow.ToString() + " ";
            //status.Items[2].Text = "Fecha y Hora : " + datenow.ToString() + " " + DateAndTime.TimeOfDay;
		}
		
		public void DiscountToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmDiscount.Default.ShowDialog();
		}
		
		public void RoomToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmRoom.Default.ShowDialog();
			frmRoom.Default.TabPage2.Select();
		}
		
		public void GuestToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			frmGuest.Default.ShowDialog();
		}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/platea21");


        }

        
	}
	
}
