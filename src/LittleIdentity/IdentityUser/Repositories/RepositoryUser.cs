using System.Linq.Expressions;
using LitleIdentity.Data;
using LitleIdentity.Data.Context;
using LittleIdentity.Abstractions.Interfaces.IdentityUsers.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LitleIdentity.Repositories.IdentityUser;

public class RepositoryUser<TUser>: IRepositoryUser<TUser> 
    where TUser : LittleIdentity.Abstractions.Entities.IdentityUser
{
    
    private readonly LittleIdentityDbContext<TUser> _context;

    public RepositoryUser(LittleIdentityDbContext<TUser> context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<TUser?> GetByPredicate(Expression<Func<TUser, bool>> predicate)
    {
        return await _context.Users.FirstOrDefaultAsync(predicate);
    }

    public async Task Create(TUser user)
    {
        if(user is null)
            throw new System.ArgumentNullException(nameof(user));
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TUser user)
    {
        if(user is null)
            throw new System.ArgumentNullException(nameof(user));
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(TUser user)
    {
        if(user is null)
            throw new System.ArgumentNullException(nameof(user));
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}