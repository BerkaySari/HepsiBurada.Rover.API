using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Data.Models.Mapping.Responses
{
    public class Response<T>
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ApiResponseStatus Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ErrorCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}
