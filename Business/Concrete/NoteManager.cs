using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NoteManager : INoteService
    {
        private readonly INoteDal _noteDal;

        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public IDataResult<Note> Get(Expression<Func<Note, bool>> predicate)
        {
            return new SuccessDataResult<Note>(_noteDal.Get(predicate));
        }

        public IDataResult<List<Note>> GetAll(Expression<Func<Note, bool>> filter = null)
        {
            return new SuccessDataResult<List<Note>>(_noteDal.GetAll(filter));
        }
    }
}
