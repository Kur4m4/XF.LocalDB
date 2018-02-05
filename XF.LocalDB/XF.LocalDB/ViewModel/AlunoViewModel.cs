using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.LocalDB.Model;
using XF.LocalDB.View.Aluno;

namespace XF.LocalDB.ViewModel
{
    public class AlunoViewModel
    {
        #region Propriedades
        public Aluno Aluno { get; set; }
        public ObservableCollection<Aluno> Alunos { get; set; }
        public ICommand OnNovoCMD { get; private set; }
        public ICommand OnEditarCMD { get; private set; }
        public ICommand OnRemoverCMD { get; private set; }
        public ICommand OnSalvarCMD { get; private set; }
        public ICommand OnCancelarCMD { get; private set; }
        #endregion

        public AlunoViewModel()
        {
            Aluno = new Aluno();
            Alunos = new ObservableCollection<Aluno>();
            OnNovoCMD = new Command(OnNovo);
            OnEditarCMD = new Command<Aluno>(OnEditar);
            OnRemoverCMD = new Command<Aluno>(OnRemover);
            OnSalvarCMD = new Command(OnSalvar);
            OnCancelarCMD = new Command(OnCancelar);
        }

        public void CarregarAlunos()
        {
            var alunos = App.AlunoModel.GetAlunos().OrderBy(a => a.Nome).ToList();
            Alunos.Clear();
            for (int index = 0; index < alunos.Count; index++)
                Alunos.Add(alunos[index]);
        }

        private void OnNovo()
        {
            App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        private void OnEditar(Aluno aluno)
        {
            Aluno = aluno;
            App.Current.MainPage.Navigation.PushAsync(new NovoAlunoView() { BindingContext = App.AlunoVM });
        }

        private void OnRemover(Aluno aluno)
        {
            App.AlunoModel.RemoverAluno(aluno.Id);
            CarregarAlunos();
        }

        public void OnSalvar()
        {
            if (string.IsNullOrWhiteSpace(Aluno.Nome) || string.IsNullOrWhiteSpace(Aluno.RM) || string.IsNullOrWhiteSpace(Aluno.Email))
            {
                App.Current.MainPage.DisplayAlert("Cadastro inválido!", "Preencha todos os campos.", "OK");
            }
            else
            {
                var aluno = Aluno;
                Limpar();

                App.AlunoModel.SalvarAluno(aluno);
                App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private void OnCancelar()
        {
            Limpar();
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void Limpar()
        {
            Aluno = new Aluno();
        }
    }
}
