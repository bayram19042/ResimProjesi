using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Models.Validation
{
    public class ProductValidator:AbstractValidator<AddProduct>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez");
            RuleFor(x => x.Dosyalar).NotEmpty().WithMessage("{PropertyName} alanı boş geçilemez");
        }
    }
}
