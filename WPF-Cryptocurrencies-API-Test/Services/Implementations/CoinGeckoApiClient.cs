using Services.Interfaces;

namespace Services.Implementations
{
    public class CoinGeckoApiClient : IDisposable, ICoinGeckoApiClient
    {
        private static readonly Lazy<CoinGeckoApiClient> Lazy = new(() => new CoinGeckoApiClient());

        private readonly HttpClient _httpClient;

        private bool _isDisposed;

        public CoinGeckoApiClient()
        {
            _httpClient = new HttpClient();
        }

        public static CoinGeckoApiClient Instance => Lazy.Value;

        public ICoinsApiClient CoinsApiClient => new CoinsApiClient(_httpClient);


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            _isDisposed = true;
        }
    }
}
