using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
namespace Application.Core.Utilities.Interceptors
{
    //metodu nasıl yorumlayacağını anlatılan yerdir. 
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //bir metodun nasıl ele alınması gerektiğini yazdık.
        protected virtual void OnBefore(IInvocation invocation) { }//metodun çalışmasının önünde
        protected virtual void OnAfter(IInvocation invocation) { }//metod çalıştıktan sonra
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }//metot hata verirse sen çalış
        protected virtual void OnSuccess(IInvocation invocation) { }// metot başarılıysa sen çalış demek
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();//bu operasyonu çalıştır demek.
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //eğer hata oluşursa OnExceptionı çalıştır
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//hata yoksa onsuccess çalıştır demek.
                }
            }
            OnAfter(invocation);
        }
    }
}
