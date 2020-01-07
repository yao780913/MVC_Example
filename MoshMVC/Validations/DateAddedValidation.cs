using MoshMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoshMVC.Validations
{
    public class DateAddedValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(validationContext.ObjectInstance is Movie movie))
                // UNDONE: if validationContext.ObjectInstance != Movie, we should write log.
                return ValidationResult.Success;

            return movie.DateAdded >= movie.ReleaseDate
                ? ValidationResult.Success
                : new ValidationResult("Release date must be earlier than date added");
        }
    }
}