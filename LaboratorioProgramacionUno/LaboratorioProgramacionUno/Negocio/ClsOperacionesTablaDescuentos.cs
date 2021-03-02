using LaboratorioProgramacionUno.Dominio;
using LaboratorioProgramacionUno.VIstas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioProgramacionUno.Negocio
{
    class ClsOperacionesTablaDescuentos
    {
        public void funcionesTabla(ClsDescriptorTablaDescuentos tablaAtributos)
        {
            frmOperaciones frmTabla = new frmOperaciones();
            frmOperaciones frmTabla2 = new frmOperaciones();

            Double iva = tablaAtributos.Iva;
            string producto = tablaAtributos.NombreProducto;
            Double precio = tablaAtributos.Precio;
            int cantidad = tablaAtributos.Cantidad;


            if (tablaAtributos.Precio > 0 && tablaAtributos.Precio <= 50)
            {
                frmTabla.lbProductoNombre.Text = producto;
                frmTabla.lbTotalSinIVA.Text = (precio * cantidad).ToString();
                frmTabla.lbIVAaAgregar.Text = ((precio * cantidad) * iva).ToString();
                frmTabla.lbTotalSinDescuentoMasIVA.Text = ((precio * cantidad) + ((precio * cantidad)) * iva).ToString();
                double TotalSinDescuento = ((precio * cantidad) + ((precio * cantidad)) * iva);
                frmTabla.lbTotalConDescuento.Text = (TotalSinDescuento - (TotalSinDescuento)).ToString();
                MessageBox.Show((TotalSinDescuento - (TotalSinDescuento * 0.0)).ToString());

            }
            else if (tablaAtributos.Precio > 50 && tablaAtributos.Precio < 100)
            {
                frmTabla.lbProductoNombre.Text = producto;
                frmTabla.lbTotalSinIVA.Text = (precio * cantidad).ToString();
                frmTabla.lbIVAaAgregar.Text = ((precio * cantidad) * iva).ToString();
                frmTabla.lbTotalSinDescuentoMasIVA.Text = ((precio * cantidad) + ((precio * cantidad)) * iva).ToString();
                double TotalSinDescuento = ((precio * cantidad) + ((precio * cantidad)) * iva);
                frmTabla.lbTotalConDescuento.Text = (TotalSinDescuento - (TotalSinDescuento * 0.05)).ToString();
                MessageBox.Show((TotalSinDescuento - (TotalSinDescuento * 0.05)).ToString());
            }
            else if (tablaAtributos.Precio >= 100 && tablaAtributos.Precio < 101)
            {
                frmTabla.lbProductoNombre.Text = producto;
                frmTabla.lbTotalSinIVA.Text = (precio * cantidad).ToString();
                frmTabla.lbIVAaAgregar.Text = ((precio * cantidad) * iva).ToString();
                frmTabla.lbTotalSinDescuentoMasIVA.Text = ((precio * cantidad) + ((precio * cantidad)) * iva).ToString();
                double TotalSinDescuento = ((precio * cantidad) + ((precio * cantidad)) * iva);
                frmTabla.lbTotalConDescuento.Text = (TotalSinDescuento - (TotalSinDescuento * 0.10)).ToString();
                MessageBox.Show((TotalSinDescuento - (TotalSinDescuento * 0.10)).ToString());
            }
            else if (tablaAtributos.Precio >= 101 && tablaAtributos.Precio < 150)
            {
                frmTabla.lbProductoNombre.Text = producto;
                frmTabla.lbTotalSinIVA.Text = (precio * cantidad).ToString();
                frmTabla.lbIVAaAgregar.Text = ((precio * cantidad) * iva).ToString();
                frmTabla.lbTotalSinDescuentoMasIVA.Text = ((precio * cantidad) + ((precio * cantidad)) * iva).ToString();
                double TotalSinDescuento = ((precio * cantidad) + ((precio * cantidad)) * iva);
                frmTabla.lbTotalConDescuento.Text = (TotalSinDescuento - (TotalSinDescuento * 0.20)).ToString();
                MessageBox.Show((TotalSinDescuento - (TotalSinDescuento * 0.20)).ToString());
            }
            else
            {
                frmTabla.lbProductoNombre.Text = producto;
                frmTabla.lbTotalSinIVA.Text = (precio * cantidad).ToString();
                frmTabla.lbIVAaAgregar.Text = ((precio * cantidad) * iva).ToString();
                frmTabla.lbTotalSinDescuentoMasIVA.Text = ((precio * cantidad) + ((precio * cantidad)) * iva).ToString();
                double TotalSinDescuento = ((precio * cantidad) + ((precio * cantidad)) * iva);
                frmTabla.lbTotalConDescuento.Text = (TotalSinDescuento - (TotalSinDescuento * 0.50)).ToString();
                MessageBox.Show((TotalSinDescuento - (TotalSinDescuento * 0.50)).ToString());
            }
            frmTabla.Show();
        }
    }
}
