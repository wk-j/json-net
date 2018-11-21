using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace JsonNet {
    class Student {
        public string Id { set; get; }

        [Newtonsoft.Json.JsonProperty(Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { set; get; }
    }

    public class RequireObjectPropertiesContractResolver : DefaultContractResolver {
        protected override JsonObjectContract CreateObjectContract(Type objectType) {
            var contract = base.CreateObjectContract(objectType);
            contract.ItemRequired = Required.Always;
            return contract;
        }
    }

    public class DynamicContractResolver : DefaultContractResolver {
        private readonly string _propertyNameToExclude;

        public DynamicContractResolver(string propertyNameToExclude) {
            _propertyNameToExclude = propertyNameToExclude;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            // only serializer properties that are not named after the specified property.
            properties =
                properties.Where(p => string.Compare(p.PropertyName, _propertyNameToExclude, true) != 0).ToList();

            return properties;
        }
    }

    class Program {
        static void Main(string[] args) {
            var settings = new JsonSerializerSettings();
            // settings.MissingMemberHandling = MissingMemberHandling.Ignore;
            // settings.ContractResolver = new RequireObjectPropertiesContractResolver();
            settings.ContractResolver = new DynamicContractResolver("Name");

            var json = @"
                {
                    ""id"": ""1""
                }
            ";

            var obj = JsonConvert.DeserializeObject<Student>(json, settings);
            Console.WriteLine(obj.Name);
        }
    }
}
