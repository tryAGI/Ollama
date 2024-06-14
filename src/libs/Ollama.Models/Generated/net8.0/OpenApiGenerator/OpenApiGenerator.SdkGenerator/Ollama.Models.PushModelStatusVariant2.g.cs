
#nullable enable

namespace Ollama
{
    /// <summary>
    /// 
    /// </summary>
    public enum PushModelStatusVariant2
    {
        /// <summary>
        /// 
        /// </summary>
        RetrievingManifest,
        /// <summary>
        /// 
        /// </summary>
        StartingUpload,
        /// <summary>
        /// 
        /// </summary>
        PushingManifest,
        /// <summary>
        /// 
        /// </summary>
        Success,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class PushModelStatusVariant2Extensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this PushModelStatusVariant2 value)
        {
            return value switch
            {
                PushModelStatusVariant2.RetrievingManifest => "retrieving manifest",
                PushModelStatusVariant2.StartingUpload => "starting upload",
                PushModelStatusVariant2.PushingManifest => "pushing manifest",
                PushModelStatusVariant2.Success => "success",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static PushModelStatusVariant2? ToEnum(string value)
        {
            return value switch
            {
                "retrieving manifest" => PushModelStatusVariant2.RetrievingManifest,
                "starting upload" => PushModelStatusVariant2.StartingUpload,
                "pushing manifest" => PushModelStatusVariant2.PushingManifest,
                "success" => PushModelStatusVariant2.Success,
                _ => null,
            };
        }
    }
}