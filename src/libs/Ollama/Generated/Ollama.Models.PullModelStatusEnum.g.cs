
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum PullModelStatusEnum
    {
        /// <summary>
        /// 
        /// </summary>
        PullingManifest,
        /// <summary>
        /// 
        /// </summary>
        DownloadingDigestname,
        /// <summary>
        /// 
        /// </summary>
        VerifyingSha256Digest,
        /// <summary>
        /// 
        /// </summary>
        WritingManifest,
        /// <summary>
        /// 
        /// </summary>
        RemovingAnyUnusedLayers,
        /// <summary>
        /// 
        /// </summary>
        Success,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class PullModelStatusEnumExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this PullModelStatusEnum value)
        {
            return value switch
            {
                PullModelStatusEnum.PullingManifest => "pulling manifest",
                PullModelStatusEnum.DownloadingDigestname => "downloading digestname",
                PullModelStatusEnum.VerifyingSha256Digest => "verifying sha256 digest",
                PullModelStatusEnum.WritingManifest => "writing manifest",
                PullModelStatusEnum.RemovingAnyUnusedLayers => "removing any unused layers",
                PullModelStatusEnum.Success => "success",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static PullModelStatusEnum? ToEnum(string value)
        {
            return value switch
            {
                "pulling manifest" => PullModelStatusEnum.PullingManifest,
                "downloading digestname" => PullModelStatusEnum.DownloadingDigestname,
                "verifying sha256 digest" => PullModelStatusEnum.VerifyingSha256Digest,
                "writing manifest" => PullModelStatusEnum.WritingManifest,
                "removing any unused layers" => PullModelStatusEnum.RemovingAnyUnusedLayers,
                "success" => PullModelStatusEnum.Success,
                _ => null,
            };
        }
    }
}