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

    public partial class P_SAutobuses : Form
    {
        private P_SAutobuses_Asignar form2Instance;
        public P_SAutobuses()
        {
            InitializeComponent();
            form2Instance = new P_SAutobuses_Asignar();
            ListarConductores();
            ListarAutobuses();
            ListarRutas();
        }

        E_SAutobuses objEntidad = new E_SAutobuses();
        N_SAutobuses objNegocio = new N_SAutobuses();

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void asignarConductoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2Instance.ShowDialog();
        }

        private void RegistrarConductor_Click(object sender, EventArgs e)
        {
            string Nombre = nombre.Text;
            string Apellido = apellido.Text;
            DateTime FechaN = fechaN.Value;
            string Cedula = cedula.Text;

            objNegocio.N_RegistrarConductores(Nombre, Apellido, FechaN, Cedula, 0);
            ListarConductores();

            nombre.Text = "";
            apellido.Text = "";
            cedula.Text = "";
        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrarAutobus_Click(object sender, EventArgs e)
        {
            string Marca = marca.Text;
            string Modelo = modelo.Text;
            string Placa = placa.Text;
            int year = int.Parse(año.Text);
            string Color = color.Text;

            objNegocio.N_RegistrarAutobuses(Marca, Modelo, Placa, year, Color, 0);
            ListarAutobuses();

            marca.Text = "";
            modelo.Text = "";
            placa.Text = "";
            año.Text = "";
            color.Text = "";
        }

        private void RegistrarRuta_Click(object sender, EventArgs e)
        {
            string Ruta = ruta.Text;

            objNegocio.N_RegistrarRutas(Ruta, 0);
            ListarRutas();

            ruta.Text = "";
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
