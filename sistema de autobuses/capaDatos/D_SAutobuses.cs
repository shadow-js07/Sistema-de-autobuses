using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using capaEntidad;
using System.Data;

namespace capaDatos
{
    public class D_SAutobuses
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conect"].ConnectionString);

        public void RegistrarConductor(string nombre, string apellido, DateTime fechaN, string cedula, int estado)
        {
            SqlCommand cmd = new SqlCommand("SP_REGISTRARCONDUCTOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@Apellido", apellido);
            cmd.Parameters.AddWithValue("@FechaN", fechaN);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            cmd.Parameters.AddWithValue("@Estado", estado);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar el conductor.", ex);
            }
        }

        public DataTable D_ListarConductores()
        {
            DataTable dc = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_LISTARCONDUCTORES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexion.Open();
                SqlDataAdapter co = new SqlDataAdapter(cmd);
                co.Fill(dc);
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los conductores registrados.", ex);
            }
            return dc;
        }

        public void RegistrarAutobus(string marca, string modelo, string placa, int año, string color, int estado)
        {
            SqlCommand cmd = new SqlCommand("SP_REGISTRARAUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Marca", marca);
            cmd.Parameters.AddWithValue("@Modelo", modelo);
            cmd.Parameters.AddWithValue("@Placa", placa);
            cmd.Parameters.AddWithValue("@Año", año);
            cmd.Parameters.AddWithValue("@Color", color);
            cmd.Parameters.AddWithValue("@Estado", estado);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error alregistrar el autobus.", ex);
            }
        }

        public DataTable D_ListarAutobuses()
        {
            DataTable dA = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_LISTARAUTOBUSES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexion.Open();
                SqlDataAdapter au = new SqlDataAdapter(cmd);
                au.Fill(dA);
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los autobuses registrados.", ex);
            }
            return dA;
        }

        public void RegistrarRuta(string ruta, int Estado)
        {
            SqlCommand cmd = new SqlCommand("SP_REGISTRARRUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ruta", ruta);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al registrar la ruta.", ex);
            }
        }

        public DataTable D_ListarRutas()
        {
            DataTable dr = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_LISTARRUTAS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexion.Open();
                SqlDataAdapter ru = new SqlDataAdapter(cmd);
                ru.Fill(dr);
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener las rutas registradas.", ex);
            }
            return dr;
        }

        public int Asignar(int conductor, int autobus, int ruta)
        {
            SqlCommand cmd = new SqlCommand("SP_ASIGNAR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ConductorID", conductor);
            cmd.Parameters.AddWithValue("@AutobusID", autobus);
            cmd.Parameters.AddWithValue("@RutaID", ruta);

            SqlParameter outputParam = new SqlParameter("@Resultado", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();

                int resultado = (int)cmd.Parameters["@Resultado"].Value;
                return resultado;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al asignar los datos.", ex);
            }
        }

        public DataTable D_Asignados()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_ASIGNADO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexion.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conexion.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los datos de Asignados.", ex);
            }
            return dt;
        }
    }
}
