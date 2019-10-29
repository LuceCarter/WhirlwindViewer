using System;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WhirlwindViewer
{    
    public partial class RandomDogMessage
    {
        [JsonProperty("message")]
        public Uri Message { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class RandomDogMessage
    {
        public static RandomDogMessage FromJson(string json) => JsonConvert.DeserializeObject<RandomDogMessage>(json, WhirlwindViewer.Converter.Settings);
    }   

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
