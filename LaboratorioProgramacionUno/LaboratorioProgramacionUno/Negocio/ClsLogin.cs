using LaboratorioProgramacionUno.DAO;
using LaboratorioProgramacionUno.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioProgramacionUno.Negocio
{
    class ClsLogin
    {
        ClsUsuarios clsUser = new ClsUsuarios();
        ClsAdministradores clsAdmin = new ClsAdministradores();
        public Boolean acceso1(ClsEntidades entidad)
        {
            Boolean b = false;

            //clsUser.usuarios = clsUser.usuarios.Distinct().ToArray();
            //clsUser.userPasswords = clsUser.userPasswords.Distinct().ToArray();

            for (int i = 0; i < clsUser.usuarios.Length; i++)
            {
                if (entidad.User.Equals(clsUser.usuarios[i]) && entidad.UserPass.Equals(clsUser.userPasswords[i]))
                {
                    b = true;
                }

            }

            return b;

        }

        public Boolean acceso2(ClsEntidades entidad)
        {
            Boolean a = false;
            for (int i = 0; i < clsAdmin.administradores.Length; i++)
            {
                if (entidad.Admin.Equals(clsAdmin.administradores[i]) && entidad.AdminPass.Equals(clsAdmin.adminPasswords[i]))
                {
                    a = true;
                }

            }

            return a;
        }
    }
}
