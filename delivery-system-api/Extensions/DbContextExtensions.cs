

using Microsoft.EntityFrameworkCore;

namespace delivery_system_api.Extensions
{
    public static  class DbContextExtensions
    {
        public static void DetachLocal<T>(this DbContext context, T t, int entryId)
    where T : class, IIdentity
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id == entryId);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
