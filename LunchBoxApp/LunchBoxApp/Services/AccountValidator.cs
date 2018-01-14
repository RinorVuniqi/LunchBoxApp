using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Services
{
    public class AccountValidator
    {
        public bool IsValidUsername(string username,
            ObservableCollection<User> users)
        {
            var validUsername = true;

            foreach (var user in users)
            {
                if (String.Equals(user.UserName, username, StringComparison.CurrentCultureIgnoreCase))
                {
                    validUsername = false;
                }
            }
            return validUsername;
        }

        public bool IsValidEmail(string email,
            ObservableCollection<User> users)
        {
            var validEmail = true;

            foreach (var user in users)
            {
                if (String.Equals(user.UserEmail, email, StringComparison.CurrentCultureIgnoreCase))
                {
                    validEmail = false;
                }
            }
            return validEmail;
        }

        public bool IsSamePassword(string password1, string password2)
        {
            bool validPassword = password1 == password2;
            return validPassword;
        }

        public bool IsValidPasswordLength(string password1)
        {
            bool validPassword = !(password1.Length < 5);
            return validPassword;
        }
    }
}
