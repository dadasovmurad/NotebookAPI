using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNoteDal : EfEntityRepositoryBase<Note, NotebookDBContext>, INoteDal
    {
        public IDataResult<Note> GetLastNote()
        {
            using (NotebookDBContext context = new NotebookDBContext())
            {
                var lastData = context.Set<Note>().OrderBy(x=>x.CreatedDate).LastOrDefault();
                return new DataResult<Note>(lastData, true);
            }
        }
    }
}
