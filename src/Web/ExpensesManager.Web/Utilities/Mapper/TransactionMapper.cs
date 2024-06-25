using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class TransactionMapper : IMapper<TransactionModel, Transaction>
    {
        public Transaction Map(TransactionModel model)
        {
            return new Transaction
            {
                Description = model.Description,
                Amount = Convert.ToDecimal(model.Amount),
                CategoryId = model.CategoryId,
                TransactionDate = model.TransactionDate,
                Type = (TransactionType)model.Type,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }
    }
}
