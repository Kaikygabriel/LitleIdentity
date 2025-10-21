using System.Linq.Expressions;

namespace LittleIdentity.Abstractions.Interfaces.IdentityRole.Repositories;

public interface IRepositoryRole
{
 
    Task<IEnumerable<ObjectValue.IdentityRole>> GetAllAsync();
    Task<ObjectValue.IdentityRole> GetByPredicate(Expression<Func<ObjectValue.IdentityRole, bool>> predicate);
    Task Create(ObjectValue.IdentityRole user);
    Task Update(ObjectValue.IdentityRole user);
    Task Delete(ObjectValue.IdentityRole user);
}