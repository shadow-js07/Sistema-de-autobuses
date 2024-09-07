using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using capaEntidad;

namespace CapaPresentacio
{
    public partial class P_SAutobuses_Asignar : Form
    {
        public P_SAutobuses_Asignar()
        {
            InitializeComponent();
            
        }

        E_SAutobuses objEntidad = new E_SAutobuses();
        N_SAutobuses objNegocio = new N_SAutobuses();

        public void ListarAsignados()
        {
            DataTable dt = objNegocio.N_Asignado();
            dataGridView1.DataSource = dt;
        }

        public void ListarConductores()
        {
            DataTable dc = objNegocio.N_LISTARCONDUCTORES();
            dataGridView2.DataSource = dc;
            dataGridView2.Columns["Estado"].Visible = false;
        }

        public void ListarAutobuses()
        {
            DataTable da = objNegocio.N_LISTARAUTOBUSES();
            dataGridView3.DataSource = da;
            dataGridView3.Columns["Estado"].Visible = false;
        }

        public void ListarRutas()
        {
            DataTable dr = objNegocio.N_LISTARRUTAS();
            dataGridView4.DataSource = dr;
            dataGridView4.Columns["Estado"].Visible = false;
        }

        public void Asignar()
        {
            try
            {
                int conductor = int.Parse(cID.Text);
                int autobus = int.Parse(aID.Text);
                int ruta = int.Parse(rID.Text);

                int resultado = objNegocio.N_Asignar(conductor, autobus, ruta);

                switch (resultado)
                {
                    case 1:
                        MessageBox.Show("El conductor ya está asignado.");
                        break;
                    case 2:
                        MessageBox.Show("El autobús ya está asignado.");
                        break;
                    case 3:
                        MessageBox.Show("La ruta ya está asignada.");
                        break;
                    case 4:
                        MessageBox.Show("Asignación exitosa.");
                        ListarAsignados();
                        ListarConductores();
                        ListarAutobuses();
                        ListarRutas();
                        break;
                    default:
                        MessageBox.Show("Todos los elementos ya están asignados.");
                        break;
                }

                cID.Text = "";
                aID.Text = "";
                rID.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AsignarCAR_Click(object sender, EventArgs e)
        {
            Asignar();
        }

        private void P_SAutobuses_Asignar_Load(object sender, EventArgs e)
        {
            ListarConductores();
            ListarAsignados();
            ListarAutobuses();
            ListarRutas();
        }
    }
}
