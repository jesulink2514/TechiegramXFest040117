using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Services;
using Techiegram.Models;
using Techiegram.Services;

namespace Techiegram.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IFeedsService _feedsService;
        private readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;

        public bool IsLoading { get; set; }
        public ObservableCollection<Post> Posts { get; set; }
        public ICommand RefreshCommand => new DelegateCommand(async() =>
        {
            await RefreshItems();
        });

        public ICommand TakePhotoCommand => new DelegateCommand(async () =>
        {
            await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                Directory = "techigramphotos",
                Name = $"post-{DateTime.Now:yy-MM-dd}.jpg"
            });

            var parameter = new NavigationParameters {{"photo", file.Path}};
            await _navigationService.NavigateAsync("PostPhotoPage", parameter);
        });

        public MainPageViewModel(
            IFeedsService feedsService, 
            IPageDialogService dialogService, 
            INavigationService navigationService)
        {
            _feedsService = feedsService;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        private async Task RefreshItems()
        {
            IsLoading = true;

            var post = await _feedsService.GetPostsForUserAsync("jesus-angulo");

            Posts = new ObservableCollection<Post>(post);

            IsLoading = false;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Task.Run(async () => await RefreshItems());
        }
    }
}
