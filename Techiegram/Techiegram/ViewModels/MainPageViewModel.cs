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
using Techiegram.Models;
using Techiegram.Services;

namespace Techiegram.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IFeedsService _feedsService;

        public bool IsLoading { get; set; }
        public ObservableCollection<Post> Posts { get; set; }
        public ICommand RefreshCommand => new DelegateCommand(async() =>
        {
            await RefreshItems();
        });

        public MainPageViewModel(IFeedsService feedsService)
        {
            _feedsService = feedsService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Task.Run(async()=> await RefreshItems());
        }

        private async Task RefreshItems()
        {
            IsLoading = true;

            var post = await _feedsService.GetPostsForUserAsync("jesus-angulo");

            Posts = new ObservableCollection<Post>(post);

            IsLoading = false;
        }
    }
}
