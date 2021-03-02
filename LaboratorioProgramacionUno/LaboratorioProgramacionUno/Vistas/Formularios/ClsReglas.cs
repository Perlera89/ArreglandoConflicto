using System;
using System.Collections.Generic;
using System.Text;

namespace Formularios
{
    class ClsReglas
    {
        public String[] regla = new string[6] { "SI EL PRODUCTO TIENE UN PRECIO MENOR o IGUAL 50 NO TENDRÁ DESCUENTO", "<=50",
            "SI EL PRODUCTO TIENE UN PRECIO MAYOR A 50 Y MENOR QUE 100 TENDRÁ UN DESCUENTO DEL 0.05 ",
            "SI EL PRODUCTO TIENE UN PRECIO MAYOR o IGUAL A 100 O MENOR QUE 101 TENDRÁ UN DESCUENTO DEL 0.10 ",
            "SI EL PRODUCTO TIENE UN PRECIO MAYOR o IGUAL 101 Y MENOR QUE 150 TENDRÁ UN DESCUENTO DEL 0.20 ",
            "SI EL PRODUCTO TIENE UN PRECIO MAYOR A 150 TENDRÁ UN DESCUENTO DEL 0.50 ", };

        //public String[] accion = new string[4] {">50 and <100",">= 100 and <101",">101 and <150",">150",};
    }   
}
