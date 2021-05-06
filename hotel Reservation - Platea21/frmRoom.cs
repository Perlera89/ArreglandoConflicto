
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
    public partial class frmRoom
    {
        public frmRoom()
        {
            InitializeComponent();


        }

        #region Default Instance

        private static frmRoom defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static frmRoom Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmRoom();
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
        int id;
        public void frmRoom_Load(System.Object sender, System.EventArgs e)
        {
            TabControl1.SelectTab(0);
            display_room();
        }
        private void display_room()
        {
            Module1.con.Open();
            /*DataTable Dt = new DataTable("tblRoom");
            OleDbDataAdapter rs = default(OleDbDataAdapter);
			
            rs = new OleDbDataAdapter("Select * from tblRoom", Module1.con);
			
            rs.Fill(Dt);
            int indx = default(int);
            lvRoom.Items.Clear();
            for (indx = 0; indx <= Dt.Rows.Count - 1; indx++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = (string) (Dt.Rows[indx]["ID"]);
                lv.SubItems.Add(Dt.Rows[indx]["RoomNumber"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["RoomType"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["RoomRate"].ToString());
                lv.SubItems.Add(Dt.Rows[indx]["NoOfOccupancy"].ToString());
                lvRoom.Items.Add(lv);
            }
            rs.Dispose();*/
            OleDbDataAdapter adaptador = new OleDbDataAdapter("Select * from tblRoom", Module1.con);

            DataSet ds = new DataSet();
            DataTable tablaRoom = new DataTable();

            adaptador.Fill(ds);
            tablaRoom = ds.Tables[0];
            this.lvRoom.Items.Clear();
            for (int i = 0; i < tablaRoom.Rows.Count; i++)
            {

                DataRow filas = tablaRoom.Rows[i];
                ListViewItem elementos = new ListViewItem(filas["ID"].ToString());
                elementos.SubItems.Add(filas["RoomNumber"].ToString());
                elementos.SubItems.Add(filas["RoomType"].ToString());
                elementos.SubItems.Add(filas["RoomRate"].ToString());
                elementos.SubItems.Add(filas["NoOfOccupancy"].ToString());
                lvRoom.Items.Add(elementos);
            }
            Module1.con.Close();
        }

        public void bttnCancel_Click(System.Object sender, System.EventArgs e)
        {
            txtID.Clear();
            txtRoomType.Clear();
            txtRoomRate.Clear();
            txtNoOfOccupancy.Clear();
            bttnSave.Text = "&Guardar";
        }

        public void bttnSave_Click(System.Object sender, System.EventArgs e)
        {
            Module1.con.Open();
            string num = txtID.Text.Trim();
            string type = txtRoomType.Text.Trim();
            string rate = txtRoomRate.Text.Trim();
            string occupancy = txtNoOfOccupancy.Text.Trim();
            string stat = "Disponible";
            if (type == null || rate == null || occupancy == null)
            {
                Interaction.MsgBox("Por favor completar todos los campos", Constants.vbInformation, "Nota");
            }
            else
            {
                if (bttnSave.Text == "&Guardar")
                {
                    var sql = "SELECT * FROM tblRoom WHERE RoomNumber =\'" + Module1.SafeSqlLiteral(num, 2) + "\'";

                    var cmd = new OleDbCommand(sql, Module1.con);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    try
                    {
                        if (dr.Read() == false)
                        {
                            OleDbCommand add_room = new OleDbCommand("INSERT INTO tblRoom(RoomNumber,RoomType,RoomRate,NoOfOccupancy,Status) values (\'" +
                            Module1.SafeSqlLiteral(num, 2) + "\',\'" +
                            Module1.SafeSqlLiteral(type, 2) + "\',\'" +
                            Module1.SafeSqlLiteral(rate, 2) + "\',\'" +
                            Module1.SafeSqlLiteral(occupancy, 2) + "\',\'" +
                            stat + "\')", Module1.con);
                            add_room.ExecuteNonQuery();
                            add_room.Dispose();
                            Interaction.MsgBox("Habitación Agregada!", Constants.vbInformation, "Nota");
                            txtID.Clear();
                            txtRoomType.Clear();
                            txtRoomRate.Clear();
                            txtNoOfOccupancy.Clear();
                        }
                        else
                        {
                            Interaction.MsgBox("Ya Existe ese Número de Habitación!", Constants.vbExclamation, "Nota");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    OleDbCommand update_room = new OleDbCommand("UPDATE tblRoom SET RoomNumber= \'" + Module1.SafeSqlLiteral(num, 2) + "\',RoomType = \'" + Module1.SafeSqlLiteral(type, 2) + "\',RoomRate = \'" + Module1.SafeSqlLiteral(rate, 2) + "\',NoOfOccupancy = \'" + Module1.SafeSqlLiteral(occupancy, 2) + "\' WHERE ID = " + id.ToString() + "", Module1.con);
                    update_room.ExecuteNonQuery();
                    update_room.Dispose();
                    Interaction.MsgBox("Habitación Agregada!", Constants.vbInformation, "Nota");
                    bttnSave.Text = "&Guardar";
                    txtID.Clear();
                    txtRoomType.Clear();
                    txtRoomRate.Clear();
                    txtNoOfOccupancy.Clear();
                }
            }
            Module1.con.Close();
            display_room();
        }

        public void lvRoom_DoubleClick(object sender, System.EventArgs e)
        {
            string a = System.Convert.ToString(Interaction.MsgBox("¿Actualizar Habitación Selecionada?", (int)Constants.vbQuestion + Constants.vbYesNo, "Actualizar"));
            if (a == Constants.vbYes.ToString())
            {
                id = int.Parse(lvRoom.SelectedItems[0].Text);
                txtID.Text = lvRoom.SelectedItems[0].SubItems[1].Text;
                txtRoomType.Text = lvRoom.SelectedItems[0].SubItems[2].Text;
                txtRoomRate.Text = lvRoom.SelectedItems[0].SubItems[3].Text;
                txtNoOfOccupancy.Text = lvRoom.SelectedItems[0].SubItems[4].Text;

                TabControl1.SelectTab(0);
                bttnSave.Text = "&Actualizar";
            }
        }

        public void lvRoom_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }
    }
}
