using System;
using FluentValidation;

namespace Core.Domain.Shared
{
    public static class ValidatorExtension
    {
        public static void ValidateAndThrow<TClass>(this TClass objeto, AbstractValidator<TClass> validator)
        {            
            var results = validator.Validate(objeto);

            if (!results.IsValid) 
            {
                foreach (var failure in results.Errors) 
                {
                    throw new ArgumentException($"{failure.ErrorMessage}");
                }
            }
        }        
    }
}
