using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class N_SAutobuses
    {
        D_SAutobuses ObjDato = new D_SAutobuses();

        public void N_RegistrarConductores(string nombre, string apellido, DateTime fecha, string cedula, int estado)
        {
            ObjDato.RegistrarConductor(nombre, apellido, fecha, cedula, estado);
        }

        public void N_RegistrarAutobuses(string marca, string modelo, string placa, int año, string color, int estado)
        {
            ObjDato.RegistrarAutobus(marca, modelo, placa, año, color, estado);
        }

        public void N_RegistrarRutas(string ruta, int estado)
        {
            ObjDato.RegistrarRuta(ruta, estado);
        }

        public int N_Asignar(int conductorID, int autobusID, int rutaID)
        {
            return ObjDato.Asignar(conductorID, autobusID, rutaID);
        }

        public DataTable N_LISTARCONDUCTORES()
        {
            DataTable dt = ObjDato.D_ListarConductores();

            if (!dt.Columns.Contains("Estados"))
            {
                dt.Columns.Add("Estados", typeof(string));
            }

            foreach (DataRow row in dt.Rows)
            {
                row["Estados"] = (bool)row["Estado"] ? "Ocupado" : "Disponible";
            }

            return dt;
        }

        public DataTable N_LISTARAUTOBUSES()
        {
            DataTable dt = ObjDato.D_ListarAutobuses();

            if (!dt.Columns.Contains("Estados"))
            {
                dt.Columns.Add("Estados", typeof(string));
            }

            foreach (DataRow row in dt.Rows)
            {
                row["Estados"] = (bool)row["Estado"] ? "Ocupado" : "Disponible";
            }

            return dt;
        }

        public DataTable N_LISTARRUTAS()
        {
            DataTable dt = ObjDato.D_ListarRutas();

            if (!dt.Columns.Contains("Estados"))
            {
                dt.Columns.Add("Estados", typeof(string));
            }

            foreach (DataRow row in dt.Rows)
            {
                row["Estados"] = (bool)row["Estado"] ? "Ocupado" : "Disponible";
            }

            return dt;
        }

        public DataTable N_Asignado()
        {
            return ObjDato.D_Asignados();
        }
    }
}
