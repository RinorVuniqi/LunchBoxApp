using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using FreshMvvm;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using Xamarin.Forms;

namespace LunchBoxApp.PageModels
{
    public class MainPageModel : FreshBasePageModel
    {
        private IProductService _productService;
        private User _user;
        private string _welcomeMessage;

        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                _welcomeMessage = $"Welkom {value}";
                RaisePropertyChanged();
            }
        }

        public Product ProductOfTheWeek { get; set; }

        public MainPageModel(IProductService productService)
        {
            _productService = productService;
        }

        public override void Init(object initData)
        {
            if (initData is User user)
            {
                base.Init(user);
                _user = user;
                WelcomeMessage = _user.UserFirstName;
                ProductOfTheWeek = _productService.GetProductOfTheWeek().Result;
            }
        }

        public override void ReverseInit(object returnedData)
        {
            if (returnedData is User user)
            {
                base.ReverseInit(returnedData);
                _user = user;
                WelcomeMessage = _user.UserFirstName;
            }
        }

        /// <summary>
        /// Show menu command
        /// </summary>
        public ICommand PushMenuPage => new Command
        (
            async () =>
            {
                await CoreMethods.PushPageModel<MenuPageModel>();
            });

        /// <summary>
        /// Show profile command
        /// </summary>
        public ICommand PushProfilePage => new Command
        (
            async () =>
            {
                await CoreMethods.PushPageModel<ProfilePageModel>(_user);
            });

        /// <summary>
        /// Log out command
        /// </summary>
        public ICommand PopCurrentPage => new Command(
            async () =>
            {
                await CoreMethods.PopPageModel();
            });

        public ICommand PushProductPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<MenuPageModel>(ProductOfTheWeek);
            });
    }
}
