using Bogus;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;

namespace ExpensesManager.TestUtility.Entities
{
    public class CategoryBuilder
    {
        public static Category GenerateCategory(CategoryType categoryType = CategoryType.Expenses)
        {
            Category category = new Faker<Category>()
                .RuleFor(r => r.Title, f => f.Commerce.ProductName())
                .RuleFor(r => r.Type, _ => categoryType);

            return category;
        }
    }
}
