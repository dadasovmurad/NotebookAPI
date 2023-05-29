using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            base.RuleFor(x=>x.Header).NotNull().NotEmpty().MaximumLength(50);
            base.RuleFor(x=>x.Content).NotNull().NotEmpty().MaximumLength(500);
            base.RuleFor(x => x.CreatedDate).NotNull().NotEmpty();
        }
    }
}
