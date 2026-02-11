using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Loan term
    /// </summary>
    [JsonConverter(typeof(EnumConverter<LoanTerm>))]
    public enum LoanTerm
    {
        /// <summary>
        /// 7 days
        /// </summary>
        [Map("7")]
        Days7,
        /// <summary>
        /// 14 days
        /// </summary>
        [Map("14")]
        Days14,
        /// <summary>
        /// 30 days
        /// </summary>
        [Map("30")]
        Days30,
        /// <summary>
        /// 90 days
        /// </summary>
        [Map("90")]
        Days90,
        /// <summary>
        /// 180 days
        /// </summary>
        [Map("180")]
        Days180
    }
}
