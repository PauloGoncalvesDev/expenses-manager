namespace ExpensesManager.Web.Utilities.Interfaces
{
    public interface IMapper<TModel, TEntity>
    {
        TEntity Map(TModel model);
    }
}
