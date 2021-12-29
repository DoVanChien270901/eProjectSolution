using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.ViewModel.System.Admin
{
    public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryRequestValidator()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name is at least 50 characters");
        }
    }
}
