using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Sistema_de_sanciones.Controladores
{
    public class Metodo_validacion
    {
        public void textKeyPress(KeyPressEventArgs e)
        {
            //Condición que solo nos permite ingresar datos tipo texto
            if(char.IsLetter(e.KeyChar)) { e.Handled = false; }  
            //Condición que permita a no dar saltos de lienea cuando se oprima Enter
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }
            //Condición que permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            //Condición que permite usar la tecla de espacio
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        public bool emialKeyPress(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public void validarNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool validadContrasena(string contrasena)
        {
            bool mayuscula = false, minuscula = false, numero = false, caraespecial = false;
            for(int i = 0; i < contrasena.Length; i++)
            {
                if(Char.IsUpper(contrasena, i))
                {
                    mayuscula = true;
                }
                else if (Char.IsLower(contrasena, i))
                {
                    minuscula = true;
                }
                else if(Char.IsDigit(contrasena, i))
                {
                    numero = true;
                }
                else
                {
                    caraespecial = true;
                }
            }

            if(mayuscula && minuscula && numero && caraespecial && contrasena.Length >= 8)
            {
                return true;
            }
            return false;
        }

    }
}
