using Application.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Application.Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception //Uygulamanınne zaman çalışacağını belirtmek için bundan implement ediyoruz
    {
        //
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();//işlemi kabul et (transaction commit)
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); //işlemi geri al (transaction rollback)
                    throw;
                }
            }
        }
    }
}
