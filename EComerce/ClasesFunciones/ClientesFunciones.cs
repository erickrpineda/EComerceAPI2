﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComerce.ClasesModelo;
using EComerce.BD;

namespace EComerce.ClasesFunciones
{
    public class ClientesFunciones
    {
        public static bool Guardar(M_Clientes c)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = ConvertirHaciaBaseDatos(c);
                db.Clientes.Add(x);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static M_Clientes ObtenerxId(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var x = db.Clientes.Where(k => k.ID == id).FirstOrDefault();
                return x == null ? null : ConvertiraModelo(x);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static List<M_Clientes> ObtenerTodos()
        {
            try
            {
                var db = new EcomerceEntities();
                var Lista = db.Clientes.ToList();

                List<M_Clientes> MiLista = new List<M_Clientes>();

                foreach (var item in Lista)
                {
                    MiLista.Add(new M_Clientes
                    {
                        ID = item.ID,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Telefono = item.Telefono,
                        CorreoE = item.CorreoE
                    });
                }
                return MiLista == null ? null : MiLista;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static bool Actualizar(M_Clientes c)
        {
            var result = false;
            try
            {
                var db = new EcomerceEntities();
                var x = db.Clientes.SingleOrDefault(k => k.ID == c.ID);

                if (x != null)
                {
                    x.Nombre = c.Nombre;
                    x.Apellido = c.Apellido;
                    x.Telefono = c.Telefono;
                    x.CorreoE = c.CorreoE;
                    db.SaveChanges();
                    result = true;
                    return result;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

        }

        public static bool Existe(int id)
        {
            try
            {
                var db = new EcomerceEntities();
                var e = db.Clientes.Any(x => x.ID == id);
                return e;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Clientes ConvertirHaciaBaseDatos(M_Clientes c)
        {
            return new Clientes
            {
                ID= c.ID,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                CorreoE = c.CorreoE
            };
        }

        public static M_Clientes ConvertiraModelo(Clientes c)
        {
            return new M_Clientes
            {
                ID = c.ID,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                CorreoE = c.CorreoE
            };
        }
    }
}
