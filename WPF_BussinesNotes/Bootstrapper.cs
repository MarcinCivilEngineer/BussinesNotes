using Caliburn.Micro;
using System.Windows;
using WPF_BussinesNotes.ViewModels;

namespace WPF_BussinesNotes
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
