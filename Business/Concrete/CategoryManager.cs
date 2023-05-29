using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new Result(true,Messages.Added);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new Result(true, Messages.Added);    
        }
        public IResult Update(Category category)
        {
            _categoryDal.Delete(category);
            return new Result(true, Messages.Updated);
        }
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<List<string>> GetNames()
        {
            return new SuccessDataResult<List<string>>(_categoryDal.GetAll().Select(x => x.Name).ToList());
        }
    }
}
