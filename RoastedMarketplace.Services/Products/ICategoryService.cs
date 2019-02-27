﻿using System.Collections.Generic;
using RoastedMarketplace.Core.Services;
using RoastedMarketplace.Data.Entity.Shop;

namespace RoastedMarketplace.Services.Products
{
    public interface ICategoryService : IFoundationEntityService<Category>
    {
        IList<Category> GetFullCategoryTree();
    }
}