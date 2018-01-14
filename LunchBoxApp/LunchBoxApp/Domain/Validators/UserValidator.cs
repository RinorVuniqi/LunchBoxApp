using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(item => item.UserName)
                .NotEmpty()
                .WithMessage("Gebruikersnaam mag niet leeg zijn")
                .Length(5, 20)
                .WithMessage("Gebruikersnaam moet tussen de 5 & 20 karakters zijn");

            RuleFor(item => item.UserFirstName)
                .NotEmpty()
                .WithMessage("Voornaam mag niet leeg zijn")
                .Length(2, 50)
                .WithMessage("Voornaam moet tussen de 2 & 50 karakters zijn");

            RuleFor(item => item.UserLastName)
                .NotEmpty()
                .WithMessage("Achternaam mag niet leeg zijn")
                .Length(2, 50)
                .WithMessage("Achternaam moet tussen de 2 & 50 karakters zijn");

            RuleFor(item => item.UserEmail)
                .NotEmpty()
                .WithMessage("Email mag niet leeg zijn")
                .EmailAddress()
                .WithMessage("Gelieve een geldig email formaat te gebruiken");

            RuleFor(item => item.UserPassword)
                .NotEmpty()
                .WithMessage("Wachtwoord mag niet leeg zijn")
                .Length(5, 50)
                .WithMessage("Wachtwoord moet tussen de 5 & 50 karakters zijn");
        }
    }
}
