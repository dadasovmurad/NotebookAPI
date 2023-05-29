using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(NoteValidator))]
        public IResult Add(Note note)
        {
            _noteDal.Add(note);
            return new Result(true, Messages.Added);
        }

        public IResult Delete(Note note)
        {
            _noteDal.Delete(note);
            return new Result(true, Messages.Deleted);
        }

        public IDataResult<List<Note>> GetAll()
        {
            return new SuccessDataResult<List<Note>>(_noteDal.GetAll());
        }

        public IDataResult<Note> GetById(long id)
        {
            return new SuccessDataResult<Note>(_noteDal.Get(x => x.Id == id));
        }

        public IResult Update(Note note)
        {
            _noteDal.Update(note);
            return new Result(true, Messages.Updated);
        }
    }
}
