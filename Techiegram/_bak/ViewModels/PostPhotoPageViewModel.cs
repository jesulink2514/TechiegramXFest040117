using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Navigation;
using Techiegram.Services;

namespace Techiegram.ViewModels
{
    public class PostPhotoPageViewModel : BindableBase, INavigationAware
    {
        private readonly IFeedsService _feedsService;
        private readonly INavigationService _navigationService;
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public ICommand PostCommand => new DelegateCommand(OnPostingPhoto);

        private async void OnPostingPhoto()
        {
            UserDialogs.Instance.ShowLoading("Posting to techiegram...");

            await _feedsService.PostPhotoAsync(PhotoUrl, Description);

            UserDialogs.Instance.HideLoading();

            await _navigationService.GoBackAsync();
        }

        public PostPhotoPageViewModel(IFeedsService feedsService,INavigationService navigationService)
        {
            _feedsService = feedsService;
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var photo = parameters.GetValue<string>("photo");
            PhotoUrl = photo;
        }
    }
}
