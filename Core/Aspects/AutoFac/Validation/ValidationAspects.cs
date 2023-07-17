using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationAspects : MethodInterception
    {
        private Type _validatorType; //örnek AgentaValidator, CenterValidator.
        public ValidationAspects(Type validatorType)//burada validator type kontrol ediyoruz. Eğer IValidator tipinde değilse hata veriyoruz.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("hatalı tip");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)//burada attribute işlevini yapıyoruz. yani method çalışmadan önce araya girip kontrolu yapıyoruz.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //hangi validatorun calışacagını alıyoruz.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//sonrasında entity alıyoruz. agenta mı center mı gibi.
            var entities = invocation.Arguments.Where(a => a.GetType() == entityType);//birden fazla olması durumunda liste atıp foreach ile kontrol eidyoruz.

            foreach (var item in entities)
            {
                ValidationTool.Validate(validator, item); //koontrol sağlandı.
            }
        }
    }
}
