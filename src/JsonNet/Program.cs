using System;
using Newtonsoft.Json;

namespace JsonNet {

    class Program {
        static void Main(string[] args) {
            var settings = new JsonSerializerSettings();
            // settings.ContractResolver = new IgnoreContractResolver(new[] { "Name" });

            var json = @"
                {
                    ""id"": ""1"",
                }
            ";

            var obj = JsonConvert.DeserializeObject<Student>(json, settings);
            Console.WriteLine(obj.Name);
        }
    }
}
