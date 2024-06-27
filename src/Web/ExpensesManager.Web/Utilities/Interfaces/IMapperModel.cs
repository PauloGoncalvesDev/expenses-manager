namespace ExpensesManager.Web.Utilities.Interfaces
{
    public interface IMapperModel<TEntity, TModel>
    {
        TModel Map(TEntity entity);
    }
}
