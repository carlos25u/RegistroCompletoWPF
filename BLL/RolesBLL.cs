﻿using Microsoft.EntityFrameworkCore;
using RegistroCompletoWPF.DAL;
using RegistroCompletoWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCompletoWPF.BLL
{
    class RolesBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Roles roles)
        {
            if (!Existe(roles.RolID))
            {
                return Insertar(roles);
            }
            else
            {
                return Modificar(roles);
            }
        }

        private static bool Insertar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Roles.Add(roles);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;

        }

        public static bool Modificar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(roles).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var roles = contexto.Roles.Find(id);

                if (roles != null)
                {
                    contexto.Roles.Remove(roles);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Roles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roles roles;

            try
            {
                roles = contexto.Roles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return roles;
        }
    }
}
