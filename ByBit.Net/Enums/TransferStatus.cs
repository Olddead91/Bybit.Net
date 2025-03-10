﻿using CryptoExchange.Net.Attributes;
using System.Text.Json.Serialization;

namespace Bybit.Net.Enums
{
    /// <summary>
    /// Transfer status
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum TransferStatus
    {
        /// <summary>
        /// Success
        /// </summary>
        [Map("SUCCESS")]
        Success,
        /// <summary>
        /// Pending
        /// </summary>
        [Map("PENDING")]
        Pending,
        /// <summary>
        /// Failed
        /// </summary>
        [Map("FAILED")]
        Failed,
        /// <summary>
        /// Unknown
        /// </summary>
        [Map("STATUS_UNKNOWN")]
        Unknown
    }
}
