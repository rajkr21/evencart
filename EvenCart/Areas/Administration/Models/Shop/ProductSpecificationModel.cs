﻿using System.Collections.Generic;
using System.Linq;
using EvenCart.Data.Extensions;
using EvenCart.Infrastructure.Helpers;
using EvenCart.Infrastructure.Mvc.Models;
using EvenCart.Infrastructure.Mvc.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvenCart.Areas.Administration.Models.Shop
{
    public class ProductSpecificationModel : FoundationEntityModel, IRequiresValidations<ProductSpecificationModel>
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsVisible { get; set; }

        public bool IsFilterable { get; set; }

        public int ProductSpecificationGroupId { get; set; }

        public ProductSpecificationGroupModel ProductSpecificationGroup { get; set; }

        public List<ProductSpecificationValueModel> Values { get; set; } = new List<ProductSpecificationValueModel>();

        public List<SelectListItem> ValuesAsSelectListItems => SelectListHelper.GetSelectItemList(Values, x => x.Id,
            x => x.AttributeValue);

        public void SetupValidationRules(ModelValidator<ProductSpecificationModel> v)
        {
            v.RuleFor(x => x.Name).NotEmpty().When(x => x.Id == 0);
            v.RuleFor(x => x.Values).Custom((list, context) =>
            {
                if (!list.Any())
                {
                    context.AddFailure(nameof(ProductSpecificationValueModel.AttributeValue), "At least one specification value must be provided");
                }
            });
            v.RuleForEach(x => x.Values)
                .Custom((model, context) =>
                {
                    if (model.AttributeValue.IsNullEmptyOrWhiteSpace())
                    {
                        context.AddFailure(nameof(ProductSpecificationValueModel.AttributeValue), "Can't add empty values");
                    }
                });
        }

    }
}