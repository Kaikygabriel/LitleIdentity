using LittleIdentity.Abstractions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LitleIdentity.Services;

public class StartupValidator<TUser,TContext>
    where TUser : LittleIdentity.Abstractions.Entities.IdentityUser
    where TContext : DbContext
{
    public StartupValidator(TContext context)
    {

        if (context.Model.FindEntityType(typeof(TUser)) == null)
            throw new LittleIdentityException
                ($"Type {typeof(TUser).Name} does not exist in dbset from dbcontext");
    }
}