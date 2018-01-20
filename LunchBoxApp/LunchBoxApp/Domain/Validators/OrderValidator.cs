using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LunchBoxApp.Domain.Models;

namespace LunchBoxApp.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(item => item.OrderCompanyName)
                .NotEmpty()
                .WithMessage("Bedrijfsnaam mag niet leeg zijn")
                .Length(5, 50)
                .WithMessage("Bedrijfsnaam moet tussen de 5 & 50 karakters zijn");
        }
    }
}
