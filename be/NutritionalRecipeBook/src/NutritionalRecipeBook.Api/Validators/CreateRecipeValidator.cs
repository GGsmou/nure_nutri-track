﻿using FluentValidation;
using NutritionalRecipeBook.Application.Common.Models.Recipe;
using System.Text.RegularExpressions;

namespace NutritionalRecipeBook.Api.Validators
{
    public class CreateRecipeValidator : AbstractValidator<CreateRecipeRequest>
    {
        public CreateRecipeValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(cr => cr.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 128)
                .WithMessage("Length ({TotalLength}) of {PropertyName} is invalid.");

            RuleFor(cr => cr.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty.")
                .Length(2, 500)
                .WithMessage("Length ({TotalLength}) of {PropertyName} is invalid.");
        }
    }
}
