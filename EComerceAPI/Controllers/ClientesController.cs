﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EComerce.ClasesFunciones;
using EComerce.ClasesModelo;

namespace EComerceAPI.Controllers
{
    public class ClientesController : BaseAPIController
    {
        [System.Web.Http.HttpGet]
        [ActionName("ObtenerTodos")]
        public HttpResponseMessage ObtenerTodos()
        {
            try
            {
                if (ValidarAutorizacion())
                {
                    var x = ClientesFunciones.ObtenerTodos();
                    return OkResponse(x);
                }
                else
                {
                    return OkResponse("No tiene acceso");
                }
            }
            catch (Exception)
            {
                return ErrorResponse("Ha ocurrido un error al Obtener Todos");
                throw;
            }
        }

        [System.Web.Http.HttpPost]
        [ActionName("Guardar")]
        public HttpResponseMessage Guardar([FromBody] M_Clientes c)
        {
            try
            {
                if (ValidarAutorizacion())
                {

                    var x = ClientesFunciones.Guardar(c);

                    if (x == false)
                    {
                        return OkResponse("Hubo un error al recuperar el registro");
                    }
                    else
                    {
                        return OkResponse(x);
                    }
                }
                else
                {
                    return OkResponse("No tiene acceso");
                }

            }
            catch (Exception)
            {
                return ErrorResponse("Ha ocurrido un error");
                throw;
            }
        }

        [System.Web.Http.HttpGet]
        [ActionName("ObtenerxId")]
        public HttpResponseMessage ObtenerxID([FromUri] int id)
        {
            try
            {

                if (ValidarAutorizacion())
                {
                    var x = ClientesFunciones.ObtenerxId(id);

                    if (x == null)
                    {
                        return OkResponse("Hubo un error al recuperar el registro");
                    }
                    else
                    {
                        return OkResponse(x);
                    }
                }
                else
                {
                    return OkResponse("No tiene acceso");
                }
            }
            catch (Exception)
            {
                return ErrorResponse("Ha ocurrido un error");
                throw;
            }
        }


        [System.Web.Http.HttpPost]
        [ActionName("Actualizar")]
        public HttpResponseMessage Actualizar([FromBody] M_Clientes a)
        {
            try
            {

                if (ValidarAutorizacion())
                {
                    var x = ClientesFunciones.Actualizar(a);

                    if (x == false)
                    {
                        return OkResponse("Hubo un error al tratar de actualizar");
                    }
                    else
                    {
                        return OkResponse(x);
                    }
                }
                else
                {
                    return OkResponse("No tiene acceso");
                }

            }
            catch (Exception)
            {
                return ErrorResponse("Ha ocurrido un error");
                throw;
            }
        }
    }

}
