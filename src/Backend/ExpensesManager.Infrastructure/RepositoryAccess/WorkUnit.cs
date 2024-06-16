using ExpensesManager.Domain.Repositories;

namespace ExpensesManager.Infrastructure.RepositoryAccess
{
    public sealed class WorkUnit : IDisposable, IWorkUnit
    {
        private readonly ExpensesManagerContext _expensesManagerContext;
        
        private bool _dispose;

        public WorkUnit(ExpensesManagerContext expensesManagerContext)
        {
            _expensesManagerContext = expensesManagerContext;
        }

        public async Task Commit()
        {
            await _expensesManagerContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing) 
        {
            if (disposing && !_dispose)
                _expensesManagerContext.Dispose();

            _dispose = true;
        }
    }
}
