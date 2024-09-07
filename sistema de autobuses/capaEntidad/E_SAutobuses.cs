using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class E_SAutobuses
    {
        private int _ConductorID;
        private string _codigo;
        private string _Nombre;
        private string _Apellido;
        private DateTime _FechaN;
        private string _Cedula;

        private int _AutobusID;
        private string _Marca;
        private string _Modelo;
        private string _Placa;
        private string _Color;
        private int _año;

        private int _RutaID;
        private string _Ruta;

        public int ConductorID { get => _ConductorID; set => _ConductorID = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public DateTime FechaN { get => _FechaN; set => _FechaN = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public int AutobusID { get => _AutobusID; set => _AutobusID = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Placa { get => _Placa; set => _Placa = value; }
        public string Color { get => _Color; set => _Color = value; }
        public int Año { get => _año; set => _año = value; }
        public int RutaID { get => _RutaID; set => _RutaID = value; }
        public string Ruta { get => _Ruta; set => _Ruta = value; }
    }
}
