using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _role;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string role)
        {
            _role = role.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var claimRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _role)
            {
                if (claimRoles.Contains(role))
                    return;
            }
            throw new Exception(Messages.AuthError);
        }
    }
}