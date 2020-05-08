
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Interceptors
{
    //classın tepesinde kullanılabilir, metotlarda ve birden fazla, ve inheritediliği alt classlarda kullanılablir olmasını söyledik(Attribitue)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor //()IInerceptor dynmaicproxy alt yapısını kullanıyor.
    {
        //Cache, log, transaction gibi işlemleri de yapacağı ve bunlara aspect verirken çalışma sırası önceliği vermek için priotry propu oluşturduk.
        //aspect normalde yukarıdan aşağıya çalışır.
        public int Priority { get; set; } //

        //kodun değiştrilebilme imkanı olması için virtual tanımaldık.
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
