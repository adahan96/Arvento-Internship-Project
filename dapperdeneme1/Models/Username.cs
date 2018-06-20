using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dapperdeneme1.Models
{
    public class Username
    {
        [JsonProperty("username")]
        public string name { get; set; }
    }
}