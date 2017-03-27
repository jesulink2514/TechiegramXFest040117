﻿using Microsoft.Practices.Unity;
using Prism.Unity;
using Techiegram.Services;
using Techiegram.Views;
using Xamarin.Forms;

namespace Techiegram
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IFeedsService,FakeFeedsService>();

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<PostPhotoPage>();
            Container.RegisterTypeForNavigation<PostPhotoPage>();
        }
    }
}
