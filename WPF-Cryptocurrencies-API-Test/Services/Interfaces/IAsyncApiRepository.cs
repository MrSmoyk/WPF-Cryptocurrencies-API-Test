namespace Services.Interfaces
{
    public interface IAsyncApiRepository
    {
        Task<T> GetAsync<T>(Uri resourceUri);
    }
}
