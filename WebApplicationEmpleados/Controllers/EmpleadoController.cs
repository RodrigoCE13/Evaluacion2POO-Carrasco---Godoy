using EmpleadosLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationEmpleados.Models;

namespace WebApplicationEmpleados.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        [Route("api/empleados")]
        public respuesta listar(string rut = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<empleado> listado = new List<empleado>();
                empleadosEntity clienteData = new empleadosEntity();
                DataSet data = rut == "" ? clienteData.listadoClientes() : clienteData.listadoClientes(rut);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    empleado item = new empleado();
                    item.rut = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.apellido = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.mail = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[4].ToString();
                    listado.Add(item);
                }
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else

                    resp.data = "No se encontro empleado";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;

            }
        }
        //----------
        [HttpPost]
        [Route("api/setempleados")]
        public respuesta guardar(empleado empleados)
        {
            respuesta resp = new respuesta();
            try
            {
                empleadosEntity cli = new empleadosEntity (empleados.rut, empleados.nombre, empleados.apellido, empleados.mail,empleados.telefono);
                int estado = cli.guardar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Empleado ingresado";
                    resp.data = empleados;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo el ingreso";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        //-------------------
        [HttpDelete]
        [Route("api/deleteempleados")]
        public respuesta eliminar(string rut)
        {
            respuesta resp = new respuesta();
            try
            {
                empleadosEntity cli = new empleadosEntity();
                cli.Rut = rut;
                int estado = cli.eliminar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Empleado eliminado";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la eliminación";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        //-----------------------
        [HttpPut]
        [Route("api/updateempleados")]
        public respuesta actualizar(empleado empleados)
        {
            respuesta resp = new respuesta();
            try
            {
                empleadosEntity emp = new empleadosEntity(empleados.rut, empleados.nombre, empleados.apellido, empleados.mail, empleados.telefono);
                int estado = emp.actualizar(empleados.rut);
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Empleado Modificado";
                    resp.data = empleados;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizo la modificacion";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        //-----------------------      
    }
}
