using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Common.Interfaces.Authentication;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Behavior
{
    public class ValidationBehaviour<TRequest,TResponse> : 
    IPipelineBehavior<TRequest,TResponse>
    where TRequest:IRequest<TResponse>
    where TResponse:IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaviour(IValidator<TRequest>? validator=null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle
        (TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
        {
            if(_validator is null)
            {
                return await next();
            }
            var validationResult= await _validator.ValidateAsync(request,cancellationToken);
            if(validationResult.IsValid){
                return await next();
            }
            var errors = validationResult.Errors
            .ConvertAll(validationFailure=>Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage
            ));
            return (dynamic)errors;
        }
    }
}