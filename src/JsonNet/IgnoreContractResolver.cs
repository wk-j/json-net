using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace JsonNet {
    public class IgnoreContractResolver : DefaultContractResolver {
        private readonly string[] excludes;

        public IgnoreContractResolver(string[] names) {
            excludes = names;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization ms) {
            return base.CreateProperties(type, ms)
                    .Where(p => !excludes.Contains(p.PropertyName))
                    .ToList();
        }
    }
}
