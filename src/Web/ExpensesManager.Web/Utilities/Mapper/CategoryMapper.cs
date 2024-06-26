﻿using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class CategoryMapper : IMapper<CategoryModel, Category>, IMapperModel<CategoryModel, Category>
    {
        public Category Map(CategoryModel model)
        {
            return new Category
            {
                Title = model.Title,
                Type = (CategoryType)model.Type,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        public CategoryModel Map(Category category)
        {
            return new CategoryModel
            {
                Title = category.Title,
                Type = (EnumModel.CategoryType)category.Type,
                CreationDate = category.CreationDate
            };
        }
    }
}
