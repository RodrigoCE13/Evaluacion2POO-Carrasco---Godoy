using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosLibrary
{
    public class empleadosEntity
    {
        private string rut;
        private string nombre;
        private string apellido;
        private string mail;
        private string telefono;

        Datos data = new Datos();

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public empleadosEntity()
        {

        }

        public empleadosEntity(string rut, string nombre, string apellido, string mail, string telefono)
        {
            this.rut = rut;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;
        }

        public DataSet listadoClientes()
        {
            return data.listado("SELECT * FROM EMPLEADO");
        }
        public DataSet listadoClientes(string rut)
        {
            return data.listado("SELECT * FROM EMPLEADO WHERE RUT= '" + rut + "'");
        }

        public int guardar(empleadosEntity empleado)
        {
            return data.ejecutar("INSERT INTO EMPLEADO(rut, nombre, apellido, mail, telefono) values('" + empleado.Rut + "','" + empleado.Nombre + "'," +
                "'" + empleado.Apellido + "','"+ empleado.mail +"','" + empleado.Telefono + "')");
        }
        public int guardar()
        {
            return data.ejecutar("INSERT INTO EMPLEADO(rut, nombre, apellido, mail, telefono) values('" + this.rut + "','" + this.nombre + "'," +
                "'" + this.apellido + "','" + this.mail + "','" + this.telefono + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM EMPLEADO WHERE RUT = '" + this.rut + "'");
        }
    }
}
