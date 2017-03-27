using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Techiegram.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new DelegateCommand(OnLogin,CanLogin)
            .ObservesProperty(()=> UserName)
            .ObservesProperty(()=> Password);

        private bool CanLogin()
        {
           return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            UserName = "jesus.angulo";
            Password = "mipassword";
        }
        private async void OnLogin()
        {
            UserDialogs.Instance.ShowLoading("Authenticating...");

            await Task.Delay(1500);

            UserDialogs.Instance.HideLoading();

            await _navigationService.NavigateAsync("NavigationPage/MainPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
