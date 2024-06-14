using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;

namespace NetConferenceMediatR.Infrastructure;

public static class AddRoleServiceExtension
{
    public static void AddRoleService(this IServiceCollection services)
    {
        services.AddSingleton<IRoleService, RoleService>();
    }
}

public interface IRoleService
{
    Task<long> AddRoleAsync(string name, string description, List<string> actions);
    Task<Role> GetRoleByIdAsync(long roleId);
    Task<ImmutableList<Role>> GetRolesAsync();
    Task<bool> DeleteRoleById(long roleId);
    Task<ImmutableList<string>> GetRoleActionsById(long roleId);
    Task<ImmutableList<string>> AddActionToRoleById(long roleId, string actionName);
    Task<ImmutableList<string>> DeleteActionFromRoleById(long roleId, string actionName);
}

public class RoleService : IRoleService
{
    private readonly List<Role> _roles =
    [
        new Role
        {
            Id = 1,
            Name = "Manager",
            Description ="Role with all permissions",
            Actions = new List<string>{"Read", "Write", "Delete"}
        }
    ];

    public Task<long> AddRoleAsync(string name, string description, List<string> actions)
    {
        throw new NotImplementedException();
    }

    public Task<Role> GetRoleByIdAsync(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableList<Role>> GetRolesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRoleById(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableList<string>> GetRoleActionsById(long roleId)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableList<string>> AddActionToRoleById(long roleId, string actionName)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableList<string>> DeleteActionFromRoleById(long roleId, string actionName)
    {
        throw new NotImplementedException();
    }

    private long GetId()
    {
        if (_roles.Any())
        {
            return _roles.Max(u => u.Id) + 1;
        }

        return 1;
    }
}