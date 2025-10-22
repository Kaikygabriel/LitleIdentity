using System.Linq.Expressions;
using LitleIdentity.Data.Context;
using LittleIdentity.Abstractions.Interfaces.IdentityRole.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LitleIdentity.IdentityRole.Repository;

public class RepositoryRole<TUser>  : IRepositoryRole where
    TUser : LittleIdentity.Abstractions.Entities.IdentityUser

{
    private readonly LittleIdentityDbContext<TUser> _context;

    public RepositoryRole(LittleIdentityDbContext<TUser> context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<LittleIdentity.Abstractions.ObjectValue.IdentityRole>> GetAllAsync()
    {
        return await _context.Roles.AsNoTracking().ToListAsync();
    }

    public async Task<LittleIdentity.Abstractions.ObjectValue.IdentityRole?> GetByPredicate(Expression<Func<LittleIdentity.Abstractions.ObjectValue.IdentityRole, bool>> predicate)
    {
        return await _context.Roles.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task Create(LittleIdentity.Abstractions.ObjectValue.IdentityRole role)
    {
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
    }

    public async Task Update(LittleIdentity.Abstractions.ObjectValue.IdentityRole role)
    {
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();

    }

    public async Task Delete(LittleIdentity.Abstractions.ObjectValue.IdentityRole role)
    {
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        await _context.SaveChangesAsync();

    }
}