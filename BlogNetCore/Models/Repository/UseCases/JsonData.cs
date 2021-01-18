using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlogNetCore.Models.Repository.UseCases
{
    public class JsonData
    {
        public string Article { get; internal set; }

        public class OtpData
        {
            [JsonPropertyName("Article")]
            public string Article { get; set; }

            [JsonPropertyName("Categories")]
            public List<Category> Categories { get; set; }

        }
    }
}
