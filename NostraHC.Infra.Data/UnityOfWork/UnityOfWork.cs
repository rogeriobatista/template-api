using Microsoft.AspNetCore.Mvc.Filters;
using NostraHC.Infra.Data.Contexts;

namespace NostraHC.Infra.Data.UnityOfWork
{
    public class UnitOfWork : IAsyncActionFilter, IUnityOfWork
    {
        private readonly NostraHCContext _context;

        public UnitOfWork(NostraHCContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                var result = await next();
                if ((result.Exception == null || result.ExceptionHandled) && _context.ChangeTracker.HasChanges())
                {
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
