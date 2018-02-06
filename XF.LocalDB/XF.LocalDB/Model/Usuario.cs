using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace XF.LocalDB.Model
{
    public class Usuario
    {
        #region Propriedades
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        public static bool IsValidUser(Usuario user)
        {
            var usuarios = XDocument.Load("http://wopek.com.spiraea.arvixe.com/xml/usuarios.xml").Descendants("usuario");

            foreach (var usuario in usuarios)
            {
                if (user.Username == usuario.Element("username").Value && user.Password == usuario.Element("password").Value)
                    return true;
            }
            return false;
        }
    }
}
