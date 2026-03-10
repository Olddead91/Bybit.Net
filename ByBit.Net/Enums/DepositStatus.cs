using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Deposit status
    /// </summary>
    [JsonConverter(typeof(EnumConverter<DepositStatus>))]
    public enum DepositStatus
    {
        /// <summary>
        /// ["<c>0</c>"] Unknown
        /// </summary>
        [Map("0")]
        Unknown,
        /// <summary>
        /// ["<c>1</c>"] Awaiting confirmations
        /// </summary>
        [Map("1")]
        ToBeConfirmed,
        /// <summary>
        /// ["<c>2</c>"] Processing
        /// </summary>
        [Map("2")]
        Processing,
        /// <summary>
        /// ["<c>3</c>"] Success
        /// </summary>
        [Map("3")]
        Success,
        /// <summary>
        /// ["<c>4</c>"] Failed
        /// </summary>
        [Map("4")]
        DepositFailed
    }
}
