using MediatR;

namespace NetConferenceMediatR.Infrastructure
{
    public interface ICachedQuery<out TResult> : IQuery<TResult> where TResult : CachableObject
    {
        public TimeSpan CacheTime { get; }
        public string CacheKey { get; }
    }

    public record CachedQuery<TResult>(string CacheKey, TimeSpan CacheTime) : ICachedQuery<TResult> where TResult : CachableObject;
}
