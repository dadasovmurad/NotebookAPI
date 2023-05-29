using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
            var businessResult = BusinessRules.Run(CheckLastCreatedNoteDifference());
            if (businessResult is null)
            {
                _noteDal.Add(note);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(businessResult.Message);
        }

        public IResult Delete(Note note)
        {
            _noteDal.Delete(note);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Note>> GetAll()
        {
            return new SuccessDataResult<List<Note>>(_noteDal.GetAll());
        }

        public IDataResult<Note> GetById(long id)
        {
            return new SuccessDataResult<Note>(_noteDal.Get(x => x.Id == id));
        }
        [ValidationAspect(typeof(NoteValidator))]
        public IResult Update(Note note)
        {
            _noteDal.Update(note);
            return new SuccessResult(Messages.Updated);
        }
        private IResult CheckLastCreatedNoteDifference()
        {
            Note lastData = _noteDal.GetLastNote().Data;
            DateTime? differenceDate = lastData?.CreatedDate.AddMinutes(2);
            if (differenceDate is null || differenceDate <= DateTime.Now)
                return new SuccessResult();
            else
                return new ErrorResult(Messages.ErrorDifferenceNote);
        }
    }
}
