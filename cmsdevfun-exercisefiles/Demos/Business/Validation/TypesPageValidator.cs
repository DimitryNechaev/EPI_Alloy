﻿using AlloyTraining.Models.Pages;
using EPiServer.Validation;
using System.Collections.Generic;

namespace AlloyTraining.Business.Validation
{
    public class TypesPageValidator : IValidate<TypesPage>
    {
        public IEnumerable<ValidationError> Validate(TypesPage instance)
        {
            var errors = new List<ValidationError>();

            if ((string.IsNullOrWhiteSpace(instance.ShortText)) || (instance.ShortText.Length < 10))
            {
                errors.Add(new ValidationError
                {
                    PropertyName = "ShortText",
                    ErrorMessage = "Short text should be at least 10 chars.",
                    Severity = ValidationErrorSeverity.Warning
                });
            }

            if (instance.ShortText == instance.LongText)
            {
                errors.Add(new ValidationError
                {
                    PropertyName = "ShortText",
                    ErrorMessage = "Short text should NOT be the same as Long text.",
                    Severity = ValidationErrorSeverity.Error,
                    RelatedProperties = new string[] { "LongText" }
                });
            }

            if (instance.ShortText == "Kermit")
            {
                errors.Add(new ValidationError
                {
                    PropertyName = "ShortText",
                    ErrorMessage = "Kermit is green.",
                    Severity = ValidationErrorSeverity.Info
                });
            }

            return errors; // return an empty list if validation is okay
        }
    }
}