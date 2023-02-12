namespace Services.Interfaces
{
    public interface ICoinGeckoApiClient
    {
        ICoinsApiClient CoinsApiClient { get; }
    }
}
