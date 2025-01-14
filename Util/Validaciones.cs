﻿using Business.Logic;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Util
{
    public static class Validaciones
    {
        public static bool ValidarRegexEmail(string email)
        {
            return Regex.IsMatch(email, @"^[a-z0-9!#$%&'""*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'""*+/=?^_`{|}~-]+)*" +
                    @"@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        }

        public static bool ValidarRegexClave(string clave)
        {
            return Regex.IsMatch(clave, ".{4,50}");
        }

        public static bool ValidarClaveConfirmada(string clave, string conf)
        {
            return clave.Equals(conf);
        }

        public static bool ValidarRegexNyA(string texto)
        {
            return Regex.IsMatch(texto, @"^[A-Za-zÀ-ú]+([-' ][A-Za-zÀ-ú]+)*$");
        }

        public static bool FormularioCompleto(List<string> txts)
        {
            bool rta = true;
            txts.ForEach(t =>
            {
                if (string.IsNullOrEmpty(t))
                {
                    rta = false;
                }
            });
            return rta;
        }

        public static bool ValidarClave(string clave_usr, string txt_clave)
        {
            if (string.IsNullOrEmpty(clave_usr) || !clave_usr.Equals(txt_clave))
            {
                return false;
            }
            return true;
        }

        public static bool UsuarioNoExiste(string nombreUsuario)
        {
            if (new UsuarioLogic().GetOneNombreUsuario(nombreUsuario) != null)
            {
                return false;
            }
            return true;
        }

        public static bool UsuarioLengthValido(string nombreUsuario)
        {
            if (nombreUsuario.Length > 15)
            {
                return false;
            }
            return true;
        }
    }
}
