using System.Linq.Expressions;
using LittleIdentity.Abstractions.Entities;

namespace LittleIdentity.Abstractions.Interfaces.IdentityUsers.Repositories;

public interface IRepositoryUser<TUser> where TUser : IIdentityUser
{
    Task<IEnumerable<TUser>> GetAllAsync();
    Task<TUser> GetByPredicate(Expression<Func<TUser, bool>> predicate);
    Task Create(TUser user);
    Task Update(TUser user);
    Task Delete(TUser user);
}