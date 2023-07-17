using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] //allow ile çoklu kullanıma izin veriyoruz. inherited ise miras alınan methodlarda da çalışmasına olanak tanıyoruz.
    public abstract class MethodInterceptorBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //öncelik sırasıdır.
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
