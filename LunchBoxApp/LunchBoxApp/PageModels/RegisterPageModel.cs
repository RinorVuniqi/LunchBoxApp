using System;
using System.Collections.ObjectModel;
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
    class RegisterPageModel : FreshBasePageModel
    {
        private readonly IUserService _userService;
        private User _user;
        private readonly IValidator _userValidator;

        private string _userUsernameError;
        private string _userEmailError;
        private string _userFirstNameError;
        private string _userLastNameError;
        private string _userPasswordError;
        private string _password1;
        private string _password2;
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }

        public RegisterPageModel(IUserService userService)
        {
            _userService = userService;
            _userValidator = new UserValidator();
        }

        public string Username { get; set; }
        public string Email { get; set; }
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

        public string UserUsernameError
        {
            get => _userUsernameError;
            set
            {
                _userUsernameError = value;
                RaisePropertyChanged(nameof(UserUsernameError));
                RaisePropertyChanged(nameof(UserUsernameErrorVisible));
            }
        }

        public bool UserUsernameErrorVisible => !string.IsNullOrWhiteSpace(UserUsernameError);

        public string UserEmailError
        {
            get => _userEmailError;
            set
            {
                _userEmailError = value;
                RaisePropertyChanged(nameof(UserEmailError));
                RaisePropertyChanged(nameof(UserEmailErrorVisible));
            }
        }

        public bool UserEmailErrorVisible => !string.IsNullOrWhiteSpace(UserEmailError);

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
        }

        /// <summary>
        /// Return to LogInPage command
        /// </summary>
        public ICommand PopCurrentPage => new Command(
            async () =>
            {
                await CoreMethods.PopPageModel();
            });

        /// <summary>
        /// Create new user command
        /// </summary>
        public ICommand CreateNewUser => new Command(
            async () =>
            {
                try
                {
                    _user = new User()
                    {
                        UserId = Guid.NewGuid(),
                        UserName = Username,
                        UserFirstName = FirstName,
                        UserLastName = LastName,
                        UserEmail = Email,
                        UserPassword = Password1
                    };

                    UserUsernameError = null;
                    UserFirstNameError = null;
                    UserLastNameError = null;
                    UserEmailError = null;
                    UserPasswordError = null;

                    if (Validate(_user))
                    {
                        await _userService.CreateNewUser(_user);
                        await CoreMethods.PopPageModel();
                        await CoreMethods.PushPageModel<MainPageModel>(_user);
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

            if (!acv.IsValidUsername(Username, Users))
            {
                validationResult.Errors.Add(new ValidationFailure(nameof(user.UserName), "Deze gebruikersnaam is al in gebruik"));
            }

            if (!acv.IsValidEmail(Email, Users))
            {
                validationResult.Errors.Add(new ValidationFailure(nameof(user.UserEmail), "Dit email adres is al in gebruik"));
            }

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(user.UserName))
                {

                    UserUsernameError = error.ErrorMessage;
                }

                if (error.PropertyName == nameof(user.UserEmail))
                {
                    UserEmailError = error.ErrorMessage;
                }

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
