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

namespace capaPresentacion
{
    public partial class P_SAutobuses : Form
    {
        public P_SAutobuses()
        {
            InitializeComponent();
        }

        E_SAutobuses objEntidad = new E_SAutobuses();
        N_SAutobuses objNegocio = new N_SAutobuses();

        private void asignados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void actualizar_Click(object sender, EventArgs e)
        {
            DataTable dt = objNegocio.N_Asignado();
            asignados.DataSource = dt;
        }
    }
}
