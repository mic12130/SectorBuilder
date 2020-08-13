using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SectorBuilder.Config
{
    public class FileListData
    {
        [JsonProperty("color")]
        public List<string> Color { get; set; }

        [JsonProperty("info")]
        public List<string> Info { get; set; }

        [JsonProperty("airport")]
        public List<string> Airport { get; set; }

        [JsonProperty("runway")]
        public List<string> Runway { get; set; }

        [JsonProperty("vor")]
        public List<string> VOR { get; set; }

        [JsonProperty("ndb")]
        public List<string> NDB { get; set; }

        [JsonProperty("fix")]
        public List<string> Fix { get; set; }

        [JsonProperty("highAirway")]
        public List<string> HighAirway { get; set; }

        [JsonProperty("lowAirway")]
        public List<string> LowAirway { get; set; }

        [JsonProperty("sid")]
        public List<string> SID { get; set; }

        [JsonProperty("star")]
        public List<string> STAR { get; set; }

        [JsonProperty("artcc")]
        public List<string> ARTCC { get; set; }

        [JsonProperty("artccHigh")]
        public List<string> ARTCCHigh { get; set; }

        [JsonProperty("artccLow")]
        public List<string> ARTCCLow { get; set; }

        [JsonProperty("label")]
        public List<string> Label { get; set; }

        [JsonProperty("geo")]
        public List<string> Geo { get; set; }

        [JsonProperty("region")]
        public List<string> Region { get; set; }

        [JsonProperty("position")]
        public List<string> Position { get; set; }

        [JsonProperty("freetext")]
        public List<string> Freetext { get; set; }

        [JsonProperty("sidstar")]
        public List<string> SIDSTAR { get; set; }

        [JsonProperty("airspace")]
        public List<string> Airspace { get; set; }

        [JsonProperty("radar")]
        public List<string> Radar { get; set; }

        [JsonProperty("ground")]
        public List<string> Ground { get; set; }
    }
}
