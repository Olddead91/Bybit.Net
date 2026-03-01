using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IBybitRestClientApiExchangeData
    {
        /// <summary>
        /// Get server announcements
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/announcement" /><br />
        /// Endpoint:<br />
        /// GET /v5/announcements/index
        /// </para>
        /// </summary>
        /// <param name="locale">Language, for example en-US</param>
        /// <param name="type">Filter by type</param>
        /// <param name="tag">Filter by tag</param>
        /// <param name="page">Page</param>
        /// <param name="limit">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitAnnouncement>>> GetAnnouncementsAsync(string locale, string? type = null, string? tag = null, int? page = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get server time
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v3/server-time" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/time
        /// </para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get delivery price
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/delivery-price" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/delivery-price
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="settleAsset">Filter by settlement asset</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitDeliveryPrice>>> GetDeliveryPriceAsync(Category category, string? symbol = null, string? baseAsset = null, string? settleAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get funding rate history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/history-fund-rate" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/funding/history
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitFundingHistory>>> GetFundingRateHistoryAsync(Category category, string symbol, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get historical volatility
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/iv" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/historical-volatility
        /// </para>
        /// </summary>
        /// <param name="baseAsset">Filter by base asset, for example `ETH`</param>
        /// <param name="quoteAsset">Quote asset, `USD` or `USDT`</param>
        /// <param name="period">Period</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitHistoricalVolatility[]>> GetHistoricalVolatilityAsync(string? baseAsset = null, string? quoteAsset = null, int? period = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get index price klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/index-kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/index-price-kline
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get insurance pool data
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/insurance" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/insurance
        /// </para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitInsurance>>> GetInsuranceAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/kline
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitKline>>> GetKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get linear/inverse symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/instruments-info
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Base asset, for example `ETH`</param>
        /// <param name="status">Filter by status</param>
        /// <param name="symbolType">Filter by symbol type</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitLinearInverseSymbol>>> GetLinearInverseSymbolsAsync(
            Category category,
            string? symbol = null,
            string? baseAsset = null,
            SymbolStatus? status = null,
            SymbolType? symbolType = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get linear/inverse tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/tickers
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Base asset, for example `ETH`</param>
        /// <param name="expirationDate">Expiration date</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitLinearInverseTicker>>> GetLinearInverseTickersAsync(Category category, string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default);

        /// <summary>
        /// Get mark price klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/mark-kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/mark-price-kline
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetMarkPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get open interest
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/open-interest" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/open-interest
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interestInterval">Interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitOpenInterest>>> GetOpenInterestAsync(Category category, string symbol, OpenInterestInterval interestInterval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get option symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/instruments-info
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Base asset, for example `ETH`</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitOptionSymbol>>> GetOptionSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get option tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by asset, for example `ETH`</param>
        /// <param name="expirationDate">Expiration date</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitOptionTicker>>> GetOptionTickersAsync(string? symbol = null, string? baseAsset = null, string? expirationDate = null, CancellationToken ct = default);

        /// <summary>
        /// Get order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/orderbook" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/orderbook
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Limit of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOrderbook>> GetOrderbookAsync(Category category, string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get RPI order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/rpi-orderbook" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/rpi_orderbook
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Limit of results, max 50</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderbook>> GetRpiOrderbookAsync(Category category, string symbol, int limit, CancellationToken ct = default);

        /// <summary>
        /// Get premium index klines
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/preimum-index-kline" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/premium-index-price-kline
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="interval">Kline interval</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitBasicKline>>> GetPremiumIndexPriceKlinesAsync(Category category, string symbol, KlineInterval interval, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get risk limits
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="cursor">Next page cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitRiskLimit>>> GetRiskLimitAsync(Category category, string? symbol = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/instruments-info
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitSpotSymbol>>> GetSpotSymbolsAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Spot tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitSpotTicker>>> GetSpotTickersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get trade history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/recent-trade" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/recent-trade
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Base asset, for example `ETH`</param>
        /// <param name="optionType">Option type</param>
        /// <param name="limit">Limit of results</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitTradeHistory>>> GetTradeHistoryAsync(Category category, string symbol, string? baseAsset = null, OptionType? optionType = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get leverage token info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/leverage-token-info" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-lever-token/info
        /// </para>
        /// </summary>
        /// <param name="leverageToken">Filter by token</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLeverageToken[]>> GetLeverageTokensAsync(string? leverageToken = null, CancellationToken ct = default);

        /// <summary>
        /// Get leveraged token market info
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/lt/leverage-token-reference" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-lever-token/reference
        /// </para>
        /// </summary>
        /// <param name="leverageToken">Token</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLeverageTokenMarket>> GetLeverageTokenMarketAsync(string leverageToken, CancellationToken ct = default);

        /// <summary>
        /// Get long/short ratio history
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/long-short-ratio" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/account-ratio
        /// </para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="period">Data recording period</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Limit for data size per page</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLongShortRatio[]>> GetLongShortRatioAsync(Category category, string symbol, DataPeriod period, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get UTA loan tiered collateral ratio
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/tier-collateral-ratio" /><br />
        /// Endpoint:<br />
        /// GET /v5/spot-margin-trade/collateral
        /// </para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotMarginCollateralRatio[]>> GetSpotMarginTieredCollateralRatioAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread trading symbols
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/instrument" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/instrument
        /// </para>
        /// </summary>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset</param>
        /// <param name="limit">Max number of results, max 500</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitSpreadSymbol[]>> GetSpreadSymbolsAsync(string? symbol = null, string? baseAsset = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread trading order book
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/orderbook" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/orderbook
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Max number of results, max 25</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderbook>> GetSpreadOrderBookAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get spread tickers
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/tickers" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/tickers
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitSpreadTicker>> GetSpreadTickersAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get spread symbol recent trades
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/spread/market/recent-trade" /><br />
        /// Endpoint:<br />
        /// GET /v5/spread/recent-trade
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="limit">Max number of results, max 1000</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitSpreadTrade[]>> GetSpreadRecentTradesAsync(string symbol, int? limit = null, CancellationToken ct = default);

        /// <summary>
        /// Get order price limits
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/order-price-limit" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/price-limit
        /// </para>
        /// </summary>
        /// <param name="symbol">Symbol name, for example `ETHUSDT`</param>
        /// <param name="category">Category. Defaults to Linear</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitOrderPriceLimit>> GetOrderPriceLimitAsync(string symbol, Category? category = null, CancellationToken ct = default);

        /// <summary>
        /// Get the system status messages
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/system-status" /><br />
        /// Endpoint:<br />
        /// GET /v5/system/status
        /// </para>
        /// </summary>
        /// <param name="id">Filter by id</param>
        /// <param name="status">Filter by status</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitSystemStatus[]>> GetSystemStatusAsync(string? id = null, SystemStatus? status = null, CancellationToken ct = default);

        /// <summary>
        /// Get ADL alerts
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/adl-alert" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/adlAlert
        /// </para>
        /// </summary>
        /// <param name="symbol">The symbol, for example `ETHUSDT`</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitAdlAlert[]>> GetAdlAlertsAsync(string symbol, CancellationToken ct = default);

        /// <summary>
        /// Get components which make up the index price
        /// <para>
        /// Docs:<br />
        /// <a href="https://bybit-exchange.github.io/docs/v5/market/index-components" /><br />
        /// Endpoint:<br />
        /// GET /v5/market/index-price-components
        /// </para>
        /// </summary>
        /// <param name="indexName">Index name</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebCallResult<BybitIndexComponents>> GetIndexPriceComponentsAsync(string indexName, CancellationToken ct = default);
    }
}
