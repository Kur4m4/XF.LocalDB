using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.Forms;
using XF.LocalDB.Model;
using XF.LocalDB.View.Aluno;

namespace XF.LocalDB.ViewModel
{
    public class UsuarioViewModel
    {
        #region Propriedades
        public Usuario Usuario { get; set; }
        public ICommand OnLoginCMD { get; private set; }
        #endregion

        public UsuarioViewModel()
        {
            Usuario = new Usuario();
            OnLoginCMD = new Command(OnLogin);
        }

        private void OnLogin()
        {
            bool invalidUser = true;
            var usuarios = XDocument.Load("http://wopek.com.spiraea.arvixe.com/xml/usuarios.xml").Descendants("usuario");

            foreach (var usuario in usuarios)
            {
                if (Usuario.Username == usuario.Element("username").Value && Usuario.Password == usuario.Element("password").Value)
                {
                    invalidUser = false;
                    App.Current.MainPage.Navigation.PushAsync(new MainPage() { BindingContext = App.AlunoVM });
                }
            }
            if (invalidUser)
                App.Current.MainPage.DisplayAlert("Usuário inválido", "Usuário e/ou senha incorreto(s)", "OK");
        }
    }
}
