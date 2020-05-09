using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.CrossCuttingConcers.Validation
{
    public static class ValidationTool
    {
        //IEntity olabilirdi ama Dto kullanabilemk için object tanmladım.
        public static void Validate(IValidator validator, object entity)
        {        
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors); //sarı uyarı veriyo düzeltmeye çalış
               // new ValidationException(result.Errors); //sarı uyarı veriyo düzeltmeye çalış
            }
        }
    }
}
