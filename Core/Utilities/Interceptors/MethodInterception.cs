using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSucces(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation) //bu method aspectler çalışınca araya girer.
        {
            var isSuccess = true;
            OnBefore(invocation); //aspectlerin davranışını belirledik burda.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSucces(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
