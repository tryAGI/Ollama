
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum PullModelStatusVariant2
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
    public static class PullModelStatusVariant2Extensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this PullModelStatusVariant2 value)
        {
            return value switch
            {
                PullModelStatusVariant2.PullingManifest => "pulling manifest",
                PullModelStatusVariant2.DownloadingDigestname => "downloading digestname",
                PullModelStatusVariant2.VerifyingSha256Digest => "verifying sha256 digest",
                PullModelStatusVariant2.WritingManifest => "writing manifest",
                PullModelStatusVariant2.RemovingAnyUnusedLayers => "removing any unused layers",
                PullModelStatusVariant2.Success => "success",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static PullModelStatusVariant2? ToEnum(string value)
        {
            return value switch
            {
                "pulling manifest" => PullModelStatusVariant2.PullingManifest,
                "downloading digestname" => PullModelStatusVariant2.DownloadingDigestname,
                "verifying sha256 digest" => PullModelStatusVariant2.VerifyingSha256Digest,
                "writing manifest" => PullModelStatusVariant2.WritingManifest,
                "removing any unused layers" => PullModelStatusVariant2.RemovingAnyUnusedLayers,
                "success" => PullModelStatusVariant2.Success,
                _ => null,
            };
        }
    }
}