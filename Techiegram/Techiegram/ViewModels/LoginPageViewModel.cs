using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Techiegram.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new DelegateCommand(OnLogin);

        public LoginPageViewModel()
        {
        }
        private void OnLogin()
        {
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
