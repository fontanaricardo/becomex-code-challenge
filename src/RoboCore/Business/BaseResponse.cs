using System.Linq;
using FluentValidation.Results;

namespace RoboCore.Business
{
    public abstract class BaseResponse
    {
        private readonly ValidationResult _result;

        public BaseResponse()
        {
            _result = new ValidationResult();
        }

        public bool IsValid
        {
            get
            {
                return _result.IsValid;
            }
        }

        public void AddError(string propertyName, string errorMessage)
        {
            _result.Errors.Add(
                new ValidationFailure(
                    propertyName: propertyName,
                    errorMessage: errorMessage
                )  
            );
        }

        public string[] Errors
        {
            get
            {
                return _result.Errors.Select(e => e.ErrorMessage).ToArray();
            }
        }
    }
}