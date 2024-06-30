using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class TransactionMapper : IMapper<TransactionModel, Transaction>, IMapperModel<Transaction, TransactionModel>
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

        public TransactionModel Map(Transaction transaction)
        {
            return new TransactionModel
            {
                Description = transaction.Description,
                Amount = transaction.Amount,
                CategoryId = transaction.CategoryId,
                TransactionDate = transaction.TransactionDate,
                Type = (EnumModel.TransactionType)transaction.Type
            };
        }
    }
}
