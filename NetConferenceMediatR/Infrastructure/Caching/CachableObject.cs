namespace NetConferenceMediatR.Infrastructure
{
    public record CachableObject
    {
        public CacheInfo CacheInfo { get; init; } = new();
    }

    public record CacheInfo(
        bool IsObjectFromCache = false,
        string Key = "",
        TimeSpan CacheTime = default,
        DateTime ExpirationDateTimeUtc = default);
}
