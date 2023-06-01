using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class TestAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            Debug.WriteLine($"[{invocation.Method.Name}] method is starting...");
        }
        protected override void OnAfter(IInvocation invocation)
        {
            Debug.WriteLine($"[{invocation.Method.Name}] method is finished."); 
        }
        
    }
}
