using Bybit.Net.Enums;
using Bybit.Net.Objects.Models.V5;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Interfaces.Clients.V5
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and changing account settings
    /// </summary>
    public interface IBybitRestClientApiAccount
    {
        /// <summary>
        /// Cancel a withdrawal
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/cancel-withdraw" /></para>
        /// </summary>
        /// <param name="id">The id of the withdrawal to cancel</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOperationResult>> CancelWithdrawalAsync(string id, CancellationToken ct = default);

        /// <summary>
        /// Create an internal transfer between different account types
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/create-inter-transfer" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="fromAccountType">From account type</param>
        /// <param name="toAccountType">To account type</param>
        /// <param name="transferId">Client id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransferId>> CreateInternalTransferAsync(string asset, decimal quantity, AccountType fromAccountType, AccountType toAccountType, string? transferId = null, CancellationToken ct = default);

        /// <summary>
        /// Transfer between main/sub accounts
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/unitransfer" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="fromMemberId">From member id</param>
        /// <param name="toMemberId">To member id</param>
        /// <param name="fromAccountType">From account type</param>
        /// <param name="toAccountType">To account type</param>
        /// <param name="transferId">Client id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransferId>> CreateUniversalTransferAsync(string asset, decimal quantity, string fromMemberId, string toMemberId, AccountType fromAccountType, AccountType toAccountType, string? transferId = null, CancellationToken ct = default);

        /// <summary>
        /// Get margin configuration info
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/account-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitAccountInfo>> GetMarginAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Get all balances
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/all-balance" /></para>
        /// </summary>
        /// <param name="accountType">Account type</param>
        /// <param name="memberId">Member id</param>
        /// <param name="asset">Asset, for example `ETH`. Can be specify multiple comma separated assets. Required for Unified account.</param>
        /// <param name="withBonus">Include bonus</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitAllAssetBalances>> GetAllAssetBalancesAsync(AccountType accountType, string? memberId = null, string? asset = null, bool? withBonus = null, CancellationToken ct = default);

        /// <summary>
        /// Get allowed deposit asset info
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/deposit-coin-spec" /></para>
        /// </summary>
        /// <param name="asset">Filter on asset, for example `ETH`</param>
        /// <param name="network">Filter on network</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitAllowedDepositInfoResponse>> GetAllowedDepositAssetInfoAsync(string? asset = null, string? network = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get api key info for the current api key
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/apikey-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitApiKeyInfo>> GetApiKeyInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Edit master API key settings
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/modify-master-apikey" /></para>
        /// </summary>
        /// <param name="readOnly">Readonly</param>
        /// <param name="ipRestrictions">IP restrictions, comma seperated</param>
        /// <param name="permissionContractTradeOrder">Has contract order permission</param>
        /// <param name="permissionContractTradePosition">Has contract position permission</param>
        /// <param name="permissionSpotTrade">Has spot trade permission</param>
        /// <param name="permissionWalletTransfer">Has wallet transfer permission</param>
        /// <param name="permissionWalletSubAccountTransfer">Has permission wallet subaccount transfer permission</param>
        /// <param name="permissionOptionsTrade">Has option trade permission</param>
        /// <param name="permissionExchangeHistory">Has exchange history permission</param>
        /// <param name="permissionCopyTrading">Has copy trade permission</param>
        /// <param name="permissionBlockTrading">Has block trade permission</param>
        /// <param name="permissionNftProductList">Has NFT product list permission</param>
        /// <param name="permissionAffiliate">Has affiliate permission</param>
        /// <param name="ct">Cancelation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitApiKeyInfo>> EditApiKeyAsync(
            bool? readOnly = null,
            string? ipRestrictions = null,
            bool? permissionContractTradeOrder = null,
            bool? permissionContractTradePosition = null,
            bool? permissionSpotTrade = null,
            bool? permissionWalletTransfer = null,
            bool? permissionWalletSubAccountTransfer = null,
            bool? permissionOptionsTrade = null,
            bool? permissionCopyTrading = null,
            bool? permissionBlockTrading = null,
            bool? permissionExchangeHistory = null,
            bool? permissionNftProductList = null,
            bool? permissionAffiliate = null,
            CancellationToken ct = default);

        /// <summary>
        /// Delete the current API Key
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/rm-master-apikey" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> DeleteApiKeyAsync(CancellationToken ct = default);

        /// <summary>
        /// Get account types
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/user/wallet-type" /></para>
        /// </summary>
        /// <param name="subAccountIds">Master id can request subaccount info</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitAccountTypeInfo[]>> GetAccountTypesAsync(IEnumerable<string>? subAccountIds = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset balance
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/account-coin-balance" /></para>
        /// </summary>
        /// <param name="accountType">Account type</param>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="memberId">Member id</param>
        /// <param name="withBonus">Include bonus</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSingleAssetBalance>> GetAssetBalanceAsync(AccountType accountType, string asset, string? memberId = null, bool? withBonus = null, CancellationToken ct = default);

        /// <summary>
        /// Get current account greek info
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/coin-greeks" /></para>
        /// </summary>
        /// <param name="baseAsset">Base asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitGreeks>>> GetAssetGreeksAsync(string? baseAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get coin info including chain info and withdrawal and deposit status
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/coin-info" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitUserAssetInfos>> GetAssetInfoAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset information
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/asset-info" /></para>
        /// </summary>
        /// <param name="accountType">Account type (spot only atm)</param>
        /// <param name="asset">Filter asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitAccountAssetInfo>> GetAssetInfoAsync(AccountType accountType, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get wallet balance and account info
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/wallet-balance" /></para>
        /// </summary>
        /// <param name="accountType">Account info</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitBalance>>> GetBalancesAsync(AccountType accountType, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get borrow history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/borrow-history" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitBorrowHistory>>> GetBorrowHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get the collateral information of the current unified margin account, including loan interest rate, loanable amount, collateral conversion rate, whether it can be mortgaged as margin, etc.
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/collateral-info" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitCollateralInfo>>> GetCollateralInfoAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Get delayed withdrawal amount
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/delay-amount" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDelayedWithdrawal>> GetDelayedWithdrawQuantityAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get the master deposit address for an asset
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/master-deposit-addr" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="networkType">Network type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDepositAddress>> GetDepositAddressAsync(string asset, string? networkType = null, CancellationToken ct = default);

        /// <summary>
        /// Get list of deposits
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/deposit-record" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="id">Filter by id</param>
        /// <param name="transactionId">Filter by transaction id</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitDeposits>> GetDepositsAsync(string? asset = null, string? id = null, string? transactionId = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get a list of internal deposits
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/deposit/internal-deposit-record" /></para>
        /// </summary>
        /// <param name="transactionId">Filter by transaction id</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Max results</param>
        /// <param name="cursor">Next page cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitInternalDeposit>>> GetInternalDepositsAsync(
            string? transactionId = null,
            string? asset = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get fee rates
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/fee-rate" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Filter by symbol, for example `ETHUSDT`</param>
        /// <param name="baseAsset">Filter by base asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitFeeRate>>> GetFeeRateAsync(Category category, string? symbol = null, string? baseAsset = null, CancellationToken ct = default);

        /// <summary>
        /// Get internal transfer history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/inter-transfer-list" /></para>
        /// </summary>
        /// <param name="transferId">Filter by tansfer id</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="transferStatus">Filter by status</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitTransfer>>> GetInternalTransfersAsync(string? transferId = null, string? asset = null, TransferStatus? transferStatus = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get transaction logs in Unified account.
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/transaction-log" /></para>
        /// </summary>
        /// <param name="accountType">Filter by account type</param>
        /// <param name="category">Filter by category</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="baseAsset">Filter by base asset</param>
        /// <param name="type">Filter by type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitTransactionLog>>> GetTransactionHistoryAsync(AccountType? accountType = null, Category? category = null, string? asset = null, string? baseAsset = null, TransactionLogType? type = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get classic account, contract transaction logs
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/contract-transaction-log" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="baseAsset">Filter by base asset</param>
        /// <param name="type">Filter by type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitTransactionLog>>> GetClassicContractTransactionHistoryAsync(
            string? asset = null,
            string? baseAsset = null,
            TransactionLogType? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            int? limit = null,
            string? cursor = null,
            CancellationToken ct = default);

        /// <summary>
        /// Get a list of transferable assets between accounts
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/transferable-coin" /></para>
        /// </summary>
        /// <param name="fromAccountType">From account type</param>
        /// <param name="toAccountType">To account type</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<string>>> GetTransferableAssetsAsync(AccountType fromAccountType, AccountType toAccountType, CancellationToken ct = default);

        /// <summary>
        /// Get universal transfer history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/unitransfer-list" /></para>
        /// </summary>
        /// <param name="transferId">Filter by tansfer id</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="transferStatus">Filter by status</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitTransfer>>> GetUniversalTransfersAsync(string? transferId = null, string? asset = null, TransferStatus? transferStatus = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/withdraw/withdraw-record" /></para>
        /// </summary>
        /// <param name="withdrawId">Filter by withdrawal id</param>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="type">Filter by type</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="limit">Number of results per page</param>
        /// <param name="cursor">Pagination cursor</param>
        /// <param name="transactionId">Transaction hash ID</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitResponse<BybitWithdrawal>>> GetWithdrawalsAsync(string? withdrawId = null, string? asset = null, WithdrawalType? type = null, DateTime? startTime = null, DateTime? endTime = null, int? limit = null, string? cursor = null, string? transactionId = null, CancellationToken ct = default);

        /// <summary>
        /// Set auto add margin
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/add-margin" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="autoAddMargin">Auto add margin or not</param>
        /// <param name="positionIdx">Position idx</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetAutoAddMarginAsync(Category category, string symbol, bool autoAddMargin, PositionIdx? positionIdx = null, CancellationToken ct = default);

        /// <summary>
        /// Set the account deposits are credited to
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/set-deposit-acct" /></para>
        /// </summary>
        /// <param name="accountType">The account</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitOperationResult>> SetDepositAccountAsync(AccountType accountType, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/leverage" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="buyLeverage">Buy leverage. Must be the same as sellLeverage under one-way mode</param>
        /// <param name="sellLeverage">Sell leverage. Must be the same as sellLeverage under one-way mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetLeverageAsync(Category category, string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);

        /// <summary>
        /// Set whether an asset should be used for collateral
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/set-collateral" /></para>
        /// </summary>
        /// <param name="asset">The asset. USDT and USDC can't be switched off</param>
        /// <param name="useForCollateral">Use the asset for collateral</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetCollateralAssetAsync(
            string asset,
            bool useForCollateral,
            CancellationToken ct = default);

        /// <summary>
        /// Set whether assets should be used for collateral
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/batch-set-collateral" /></para>
        /// </summary>
        /// <param name="assets">The assets configuration</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetMultipleCollateralAssetsAsync(
            IEnumerable<BybitSetCollateralAssetRequest> assets,
            CancellationToken ct = default);

        /// <summary>
        /// Set the margin mode
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/set-margin-mode" /></para>
        /// </summary>
        /// <param name="marginMode">Margin mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSetMarginModeResult>> SetMarginModeAsync(MarginMode marginMode, CancellationToken ct = default);

        /// <summary>
        /// DEPRECATED, SEE https://announcements.bybit.com/en/article/risk-limit-update-transitioning-from-manual-to-auto-adjustment-bltf0fa535064561d9d/
        /// Set the risk limit
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/set-risk-limit" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="riskId">Risk id</param>
        /// <param name="positionIdx">Position idx</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSetRiskLimit>> SetRiskLimitAsync(Category category, string symbol, int riskId, PositionIdx? positionIdx = null, CancellationToken ct = default);

        /// <summary>
        /// Set take profit/stop loss mode
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/tpsl-mode" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="tpSlMode">Mode</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTakeProfitStopLossMode>> SetTakeProfitStopLossModeAsync(Category category, string symbol, StopLossTakeProfitMode tpSlMode, CancellationToken ct = default);

        /// <summary>
        /// Switch cross or isolated margin mode
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/cross-isolate" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="tradeMode">Trade mode</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SwitchCrossIsolatedMarginAsync(Category category, string symbol, TradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default);

        /// <summary>
        /// Switch position mode
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/position-mode" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="mode">Mode</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="asset">Asset</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SwitchPositionModeAsync(Category category, PositionMode mode, string? symbol = null, string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Withdraw funds
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/withdraw" /></para>
        /// </summary>
        /// <param name="asset">Asset, for example `ETH`</param>
        /// <param name="network">Network to use</param>
        /// <param name="toAddress">Target address</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="tag">Tag</param>
        /// <param name="forceNetwork">Force on-chain withdrawal</param>
        /// <param name="accountType">Account type to withdraw from</param>
        /// <param name="feeType">Handling fee option</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitId>> WithdrawAsync(string asset, string network, string toAddress, decimal quantity, string? tag = null, bool? forceNetwork = null, AccountType? accountType = null, bool? feeType = null, CancellationToken ct = default);

        /// <summary>
        /// Manually add or reduce margin for isolated margin position
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/position/manual-add-margin" /></para>
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="symbol">Symbol, for example `ETHUSDT`</param>
        /// <param name="margin">Margin. Positive for adding, negative for reducing</param>
        /// <param name="positionIdx">Position idx</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPosition>> AddOrReduceMarginAsync(
            Category category,
            string symbol,
            decimal margin,
            PositionIdx? positionIdx = null,
            CancellationToken ct = default);

        /// <summary>
        /// Set the user's maximum leverage in spot cross margin
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/set-leverage" /></para>
        /// </summary>
        /// <param name="leverage">New leverage</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetSpotMarginLeverageAsync(decimal leverage, CancellationToken ct = default);

        /// <summary>
        /// Query the Spot margin status and leverage of Unified account
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/status" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotMarginLeverageStatus>> GetSpotMarginStatusAndLeverageAsync(CancellationToken ct = default);

        /// <summary>
        /// Turn on / off spot margin trade
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/status" /></para>
        /// </summary>
        /// <param name="spotMarginMode">True to enable, false to disable</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotMarginStatus>> SetSpotMarginTradeModeAsync(bool spotMarginMode, CancellationToken ct = default);

        /// <summary>
        /// Get spot margin data
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/vip-margin" /></para>
        /// </summary>
        /// <param name="asset">Filter by asset, for example `ETH`</param>
        /// <param name="vipLevel">Filter by VIP level</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotMarginVipMarginList[]>> GetSpotMarginDataAsync(string? asset = null, string? vipLevel = null, CancellationToken ct = default);

        /// <summary>
        /// Get spot margin interest rate history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/spot-margin-uta/vip-margin" /></para>
        /// </summary>
        /// <param name="asset">The asset, for example `ETH`</param>
        /// <param name="vipLevel">VIP level. If not set uses the account VIP level</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitSpotMarginBorrowRate[]>> GetSpotMarginInterestRateHistoryAsync(string asset, string? vipLevel = null, DateTime? startTime = null, DateTime? endTime = null, CancellationToken ct = default);

        /// <summary>
        /// Get broker earnings
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/broker/exchange-earning" /></para>
        /// </summary>
        /// <param name="bizType">Filter by bizType</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="subAccountId">Filter by sub account id</param>
        /// <param name="limit">Max number of results</param>
        /// <param name="cursor">Next page cursor</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitBrokerEarnings>> GetBrokerEarningsAsync(string? bizType = null, DateTime? startTime = null, DateTime? endTime = null, string? subAccountId = null, int? limit = null, string? cursor = null, CancellationToken ct = default);

        /// <summary>
        /// Get broker account info
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/broker/account-info" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitBrokerAccountInfo>> GetBrokerAccountInfoAsync(CancellationToken ct = default);

        /// <summary>
        /// Set spot hedging mode
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/set-spot-hedge" /></para>
        /// </summary>
        /// <param name="spotHedgingMode">Hedging mode on or not</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetSpotHedgingModeAsync(bool spotHedgingMode, CancellationToken ct = default);

        /// <summary>
        /// Manually repay the liabilities of Unified account
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/repay-liability" /></para>
        /// </summary>
        /// <param name="asset">Only repay this asset; if null repay all assets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitLiabilityRepayment[]>> RepayLiabilitiesAsync(string? asset = null, CancellationToken ct = default);

        /// <summary>
        /// Request funds for demo trading
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/demo#request-demo-trading-funds" /></para>
        /// </summary>
        /// <param name="funds">Dictionary of the asset and amount you want to receive. Only BTC, ETH, USDT or USDC supported</param>
        /// <param name="addOrReduce">Whether to add(true, default) or reduce (false) the funds with the amounts</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> RequestDemoFundsAsync(Dictionary<string, decimal> funds, bool? addOrReduce = null, CancellationToken ct = default);

        /// <summary>
        /// Get convert assets list
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/convert/convert-coin-list" /></para>
        /// </summary>
        /// <param name="accountType">Account type</param>
        /// <param name="asset">Filter by asset, for example `USDT`</param>
        /// <param name="side">Request side, from or to list</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConvertAsset[]>> GetConvertAssetsAsync(ConvertAccountType accountType, string? asset = null, ConvertAssetSide? side = null, CancellationToken ct = default);

        /// <summary>
        /// Get a convert quote for 2 assets
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/convert/apply-quote" /></para>
        /// </summary>
        /// <param name="accountType">Account type</param>
        /// <param name="fromAsset">From asset (selling)</param>
        /// <param name="toAsset">To asset (buying)</param>
        /// <param name="quantity">Quantity to sell</param>
        /// <param name="clientOrderId">Request id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConvertQuote>> GetConvertQuoteAsync(ConvertAccountType accountType, string fromAsset, string toAsset, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// Confirm a convert quote and start the conversion
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/convert/confirm-quote" /></para>
        /// </summary>
        /// <param name="quoteTransactionId">The quote transaction id to confirm</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConvertTransactionResult>> ConvertConfirmQuoteAsync(string quoteTransactionId, CancellationToken ct = default);

        /// <summary>
        /// Get status of a convert transaction
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/convert/get-convert-result" /></para>
        /// </summary>
        /// <param name="accountType">Account type</param>
        /// <param name="quoteTransactionId">Transaction id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConvertTransaction>> GetConvertStatusAsync(ConvertAccountType accountType, string quoteTransactionId, CancellationToken ct = default);

        /// <summary>
        /// Get convert history
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/asset/convert/get-convert-history" /></para>
        /// </summary>
        /// <param name="accountType">Filter by account type</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitConvertTransaction[]>> GetConvertHistoryAsync(ConvertAccountType? accountType = null, int? page = null, int? pageSize = null, CancellationToken ct = default);

        /// <summary>
        /// Get quantity available for withdrawal/transfer from unified wallet
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/unified-trans-amnt" /></para>
        /// </summary>
        /// <param name="asset">Asset name</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransferable>> GetTransferableAsync(string asset, CancellationToken ct = default);

        /// <summary>
        /// Get quantity available for withdrawal/transfer from unified wallet
        /// <para><a href="https://bybit-exchange.github.io/docs/v5/account/unified-trans-amnt" /></para>
        /// </summary>
        /// <param name="assets">Asset names, can request up to 20 assets</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTransferable>> GetTransferableAsync(IEnumerable<string> assets, CancellationToken ct = default);
    }
}
