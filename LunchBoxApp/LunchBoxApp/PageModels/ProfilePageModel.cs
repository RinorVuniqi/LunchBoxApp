using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using FluentValidation.Results;
using FreshMvvm;
using LunchBoxApp.Domain.Models;
using LunchBoxApp.Domain.Services.Abstract;
using LunchBoxApp.Domain.Validators;
using LunchBoxApp.Services;
using Xamarin.Forms;

namespace LunchBoxApp.PageModels
{
    public class ProfilePageModel : FreshBasePageModel
    {
        private readonly IUserService _userService;
        private User _user;
        private readonly IValidator _userValidator;

        private string _userFirstNameError;
        private string _userLastNameError;
        private string _userPasswordError;
        private string _password1;
        private string _password2;
        private ObservableCollection<User> _users;
        private string _username;
        private string _email;
        
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        public ProfilePageModel(IUserService userService)
        {
            _userService = userService;
            _userValidator = new UserValidator();
        }

        public string Username
        {
            get => _username;
            set => _username = $"Gebruikersnaam: {value}";
        }

        public string Email
        {
            get => _email;
            set => _email = $"Email: {value}";
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password1
        {
            get => _password1;
            set
            {
                _password1 = value;
                RaisePropertyChanged(nameof(Password1));
            }
        }

        public string Password2
        {
            get => _password2;
            set
            {
                _password2 = value;
                RaisePropertyChanged(Password2);
            }
        }

        public string UserFirstNameError
        {
            get => _userFirstNameError;
            set
            {
                _userFirstNameError = value;
                RaisePropertyChanged(nameof(UserFirstNameError));
                RaisePropertyChanged(nameof(UserFirstNameErrorVisible));
            }
        }

        public bool UserFirstNameErrorVisible => !string.IsNullOrWhiteSpace(UserFirstNameError);

        public string UserLastNameError
        {
            get => _userLastNameError;
            set
            {
                _userLastNameError = value;
                RaisePropertyChanged(nameof(UserLastNameError));
                RaisePropertyChanged(nameof(UserLastNameErrorVisible));
            }
        }

        public bool UserLastNameErrorVisible => !string.IsNullOrWhiteSpace(UserLastNameError);

        public string UserPasswordError
        {
            get => _userPasswordError;
            set
            {
                _userPasswordError = value;
                RaisePropertyChanged(nameof(UserPasswordError));
                RaisePropertyChanged(nameof(UserPasswordErrorVisible));
            }
        }

        public bool UserPasswordErrorVisible => !string.IsNullOrWhiteSpace(UserPasswordError);


        public override async void Init(object initData)
        {
            await GetAllUsers();
            base.Init(initData);
            if (initData is User user)
            {
                Username = user.UserName;
                Email = user.UserEmail;
                FirstName = user.UserFirstName;
                LastName = user.UserLastName;
                _user = user;
            }
        }

        /// <summary>
        /// Back to previous page command
        /// </summary>
        public ICommand PopCurrentPage => new Command(
            async () =>
            {
                await CoreMethods.PopPageModel();
            });

        /// <summary>
        /// Update current user command (after validation)
        /// </summary>
        public ICommand SaveCurrentUser => new Command(
            async () =>
            {
                try
                {
                    UserFirstNameError = null;
                    UserLastNameError = null;
                    UserPasswordError = null;

                    if (Validate(new User() { UserName = _user.UserName, UserEmail = _user.UserEmail, UserFirstName = FirstName, UserLastName = LastName, UserPassword = Password1}))
                    {
                        _user.UserFirstName = FirstName;
                        _user.UserLastName = LastName;
                        _user.UserPassword = Password1;

                        await _userService.SaveExistingUser(_user);
                        await CoreMethods.PopPageModel(_user);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });

        /// <summary>
        /// Returns all existing users
        /// </summary>
        /// <returns></returns>
        private async Task GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            Users = null;
            Users = new ObservableCollection<User>(users);
        }

        /// <summary>
        /// Validator
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool Validate(User user)
        {
            var validationResult = _userValidator.Validate(user);

            AccountValidator acv = new AccountValidator();

            if (!acv.IsSamePassword(Password1, Password2))
            {
                validationResult.Errors.Add(new ValidationFailure(nameof(user.UserPassword), "Je wachtwoorden zijn niet gelijk"));
            }

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(user.UserFirstName))
                {
                    UserFirstNameError = error.ErrorMessage;
                }

                if (error.PropertyName == nameof(user.UserLastName))
                {
                    UserLastNameError = error.ErrorMessage;
                }

                if (error.PropertyName == nameof(user.UserPassword))
                {
                    UserPasswordError = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }
    }
}
