namespace NetConferenceMediatR.Infrastructure;

public interface ICachingService
{
    Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> itemFactory, TimeSpan cachingTime) where T : CachableObject;
    T? Get<T>(string key) where T : CachableObject;
    Task<T> CreateAsync<T>(string key, Func<Task<T>> itemFactory, TimeSpan cachingTime) where T : CachableObject;

}

public class CachingService : ICachingService
{
    public Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> itemFactory, TimeSpan cachingTime) where T : CachableObject
    {
        return itemFactory.Invoke();
    }

    public T? Get<T>(string key) where T : CachableObject
    {
        return null;
    }

    public Task<T> CreateAsync<T>(string key, Func<Task<T>> itemFactory, TimeSpan cachingTime) where T : CachableObject
    {
        return itemFactory.Invoke();
    }
}