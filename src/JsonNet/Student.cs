using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace JsonNet {
    class Student {
        public string Id { set; get; }

        [JsonProperty(Required = Required.Always)]
        // [Required(AllowEmptyStrings = true)]
        public string Name { set; get; }
    }
}
