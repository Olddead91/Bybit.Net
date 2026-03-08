using System.Text.Json.Serialization;
using System;

namespace Bybit.Net.Objects.Models.V5
{
    [SerializationModel]
    internal record BybitConvertAssetWrapper
    {
        /// <summary>
        /// ["<c>coins</c>"] Coins
        /// </summary>
        [JsonPropertyName("coins")]
        public BybitConvertAsset[] Assets { get; set; } = Array.Empty<BybitConvertAsset>();
    }

    /// <summary>
    /// Convert asset info
    /// </summary>
    [SerializationModel]
    public record BybitConvertAsset
    {
        /// <summary>
        /// ["<c>coin</c>"] Asset
        /// </summary>
        [JsonPropertyName("coin")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>fullName</c>"] Full name
        /// </summary>
        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>icon</c>"] Icon
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>iconNight</c>"] Icon night
        /// </summary>
        [JsonPropertyName("iconNight")]
        public string IconNight { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>accuracyLength</c>"] The max amount of decimal places to use
        /// </summary>
        [JsonPropertyName("accuracyLength")]
        public int Precision { get; set; }
        /// <summary>
        /// ["<c>coinType</c>"] Asset type
        /// </summary>
        [JsonPropertyName("coinType")]
        public string AssetType { get; set; } = string.Empty;
        /// <summary>
        /// ["<c>balance</c>"] Balance
        /// </summary>
        [JsonPropertyName("balance")]
        public decimal? Balance { get; set; }
        /// <summary>
        /// ["<c>uBalance</c>"] Balance USDT value
        /// </summary>
        [JsonPropertyName("uBalance")]
        public decimal? BalanceValue { get; set; }
        /// <summary>
        /// ["<c>singleFromMinLimit</c>"] The minimum quantity of fromAsset per transaction
        /// </summary>
        [JsonPropertyName("singleFromMinLimit")]
        public decimal FromAssetMinQuantity { get; set; }
        /// <summary>
        /// ["<c>singleFromMaxLimit</c>"] The maximum quantity of fromAsset per transaction
        /// </summary>
        [JsonPropertyName("singleFromMaxLimit")]
        public decimal FromAssetMaxQuantity { get; set; }
        /// <summary>
        /// ["<c>disableFrom</c>"] true: the asset is disabled to be fromAsset, false: the asset is allowed to be fromAsset
        /// </summary>
        [JsonPropertyName("disableFrom")]
        public bool DisableFrom { get; set; }
        /// <summary>
        /// ["<c>disableTo</c>"] true: the asset is disabled to be toAsset, false: the asset is allowed to be toAsset
        /// </summary>
        [JsonPropertyName("disableTo")]
        public bool DisableTo { get; set; }
    }
}
