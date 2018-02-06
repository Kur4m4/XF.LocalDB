using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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
            if(Usuario.IsValidUser(Usuario))
                App.Current.MainPage.Navigation.PushAsync(new MainPage() { BindingContext = App.AlunoVM });
            else
                App.Current.MainPage.DisplayAlert("Usuário inválido", "Usuário e/ou senha incorreto(s)", "OK");
        }
    }
}
