using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CamelCase {
    class Model {
        public string Name { set; get; }
        public string Value { set; get; }
        public Dictionary<string, string> Properties { set; get; } = new Dictionary<string, string>();
    }
    class Program {
        static void Main(string[] args) {
            var obj = new Model();
            obj.Name = "Name";
            obj.Value = "Value";
            obj.Properties.Add("A:A", "V:V");

            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            Console.WriteLine(json);
        }
    }
}
