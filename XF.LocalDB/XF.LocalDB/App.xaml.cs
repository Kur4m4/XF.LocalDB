using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.LocalDB.Model;
using XF.LocalDB.View.Login;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB
{
    public partial class App : Application
    {
        public static UsuarioViewModel UsuarioVM { get; set; }
        public static AlunoViewModel AlunoVM { get; set; }

        public App()
        {
            if (UsuarioVM == null) UsuarioVM = new UsuarioViewModel();
            if (AlunoVM == null) AlunoVM = new AlunoViewModel();

            // The root page of your application
            MainPage = new NavigationPage(new LoginView() { BindingContext = UsuarioVM });
        }

        static Aluno alunoModel;
        public static Aluno AlunoModel
        {
            get
            {
                if (alunoModel == null)
                {
                    alunoModel = new Aluno();
                }
                return alunoModel;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
