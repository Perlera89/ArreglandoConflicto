using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioProgramacionUno.Dominio
{
    class ClsDescriptorTablaDescuentos
    {
        private double iva;
        private string nombreProducto;
        private double precio;
        private int cantidad;

        public double Iva { get => iva; set => iva = value; }
        public string NombreProducto { get => nombreProducto; set => nombreProducto = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

    }
}
