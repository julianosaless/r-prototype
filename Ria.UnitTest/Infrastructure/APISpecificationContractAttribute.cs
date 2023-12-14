using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using Xunit.Sdk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Ria.UnitTest.Unit.Tests.Infrastructure
{
    public sealed class APISpecificationContractAttribute : DataAttribute
    {
        private readonly Type _target;
        private readonly string _filePath;

        public APISpecificationContractAttribute(string filePath, Type target)
        {
            _filePath = filePath;
            _target = target;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

            var path = Path.IsPathRooted(_filePath)
                ? _filePath
                : Path.Combine(Directory.GetCurrentDirectory(), _filePath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            var fileData = File.ReadAllText(_filePath);
            var content = new APISpecificationContractResponse
            (
                new APIScpecificationContent(MapTo(fileData)),
                new APIScpecificationContent(MapTo(fileData, _target))
            );

            var contracts = new List<object> { content };
            yield return contracts.ToArray();
        }

        private static string MapTo(string content, Type type = default)
        {
            var settings = new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.DateTime,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var result = type == default ? JsonConvert.DeserializeObject(content, settings) : JsonConvert.DeserializeObject(content, type, settings);
            var jsonResult = JsonConvert.SerializeObject(result, settings);
            return JValue.Parse(jsonResult).ToString(Formatting.Indented);
        }
    }
}
