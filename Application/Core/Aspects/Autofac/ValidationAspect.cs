using Application.Core.CrossCuttingConcers.Validation;
using Application.Core.Utilities.Interceptors;
using Application.Core.Utilities.Messages;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //gonderilen validatorType Ivaldator türünde değilse 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //metodun argumanlarına bak (servicede ki Category category'den )=
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //entity içindeki parametrelere bak ValitadioTool daki kurallara uyup uymadığını kontrol et demek.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
