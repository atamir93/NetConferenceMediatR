﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;

namespace NetConferenceMediatR.Infrastructure;

public static class AddUserServiceExtension
{
    public static void AddUserService(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();
    }
}
public interface IUserService
{
    Task<long> AddUserAsync(string firstName, string lastName, string email, DateTime birthDate);
    Task<User> GetUserByIdAsync(long userId);
    Task<ImmutableList<User>> GetUsersAsync();
    Task<User> UpdateUserByIdAsync(long userId, string firstName, string lastName, string email);
    Task<bool> DeleteUserByIdAsync(long userId);
}

public class UserService : IUserService
{
    private readonly List<User> _users =
    [
        new User
        {
            Id = 1, FirstName = "John", LastName = "Terry", Email = "john@gmail.com",
            Birthdate = new DateTime(2020, 12, 12)
        },
        new User
        {
            Id = 2, FirstName = "Frank", LastName = "Lampard", Email = "frank@gmail.com",
            Birthdate = new DateTime(1999, 01, 28)
        },
        new User
        {
            Id = 3, FirstName = "Michael", LastName = "Ballack", Email = "ballack@gmail.com",
            Birthdate = new DateTime(1998, 06, 19)
        }
    ];

    public Task<long> AddUserAsync(string firstName, string lastName, string email, DateTime birthDate)
    {
        var autoGeneratedId = GetId();
        var user = new User
        {
            Id = autoGeneratedId,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Birthdate = birthDate
        };

        _users.Add(user);

        return Task.FromResult(autoGeneratedId);
    }

    public Task<User> GetUserByIdAsync(long userId)
    {
        var user = _users.SingleOrDefault(u => u.Id == userId);
        if (user == null)
        {
            throw new KeyNotFoundException($"The user with id '{userId}' could not be found");
        }

        return Task.FromResult(user);
    }

    public Task<ImmutableList<User>> GetUsersAsync()
    {
        return Task.FromResult(_users.ToImmutableList());
    }

    public async Task<User> UpdateUserByIdAsync(long userId, string firstName, string lastName, string email)
    {
        var user = await GetUserByIdAsync(userId);

        var newUser = user with
        {
            FirstName = string.IsNullOrEmpty(firstName) ? user.FirstName : firstName, 
            LastName = string.IsNullOrEmpty(lastName) ? user.LastName : lastName, 
            Email = string.IsNullOrEmpty(email) ? user.Email : email
        };
        _users.Remove(user);
        _users.Add(newUser);

        return newUser;
    }

    public async Task<bool> DeleteUserByIdAsync(long userId)
    {
        var user = await GetUserByIdAsync(userId);
        _users.Remove(user);

        return true;
    }

    private long GetId()
    {
        if (_users.Any())
        {
            return _users.Max(u => u.Id) + 1;
        }

        return 1;
    }
}