using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NotebookDBContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NotebookDBContext())
            {
                return (from claims in context.OperationClaims
                        join userClaims in context.UserOperationClaims
                        on claims.Id equals userClaims.OperationClaimId
                        where userClaims.UserId == user.Id
                        select new OperationClaim { Id = claims.Id, Name = claims.Name }).ToList();
            }
        }
    }
}
