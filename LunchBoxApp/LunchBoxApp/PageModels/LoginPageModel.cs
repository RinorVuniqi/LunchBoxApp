using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using LunchBoxApp.Domain.Services.Abstract;
using Xamarin.Forms;

namespace LunchBoxApp.PageModels
{
    public class LoginPageModel : FreshBasePageModel
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private string _errorMessage;
        private string _username;
        private string _password;

        public LoginPageModel(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public string LoginErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(nameof(LoginErrorMessage));
                RaisePropertyChanged(nameof(LoignErrorMessageVisible));
            }
        }

        public bool LoignErrorMessageVisible => !string.IsNullOrWhiteSpace(LoginErrorMessage);

        /// <summary>
        /// Log user in command
        /// </summary>
        public ICommand LogUserIn => new Command(
            async () =>
            {
                try
                {
                    LoginErrorMessage = null;
                    var user = await _userService.GetLoginUser(Username, Password);
                    Debug.WriteLine($"{user.UserId.ToString()} {user.UserName} {user.UserPassword} {user.UserEmail}");

                    //Username = "";
                    //Password = "";
                    await CoreMethods.PushPageModel<MainPageModel>(user);
                }

                catch
                {
                    LoginErrorMessage = "Verkeerde login informatie";
                    Username = "Rinor";
                    Password = "rinor";
                }
            });

        /// <summary>
        /// Register new user command
        /// </summary>
        public ICommand RegisterNewUser => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<RegisterPageModel>();
            });

        public async Task ClearOrderedProducts()
        {
            await _orderService.ClearOrderProducts();
        }
    }
}
