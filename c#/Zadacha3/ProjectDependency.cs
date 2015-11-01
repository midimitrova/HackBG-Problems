using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha2
{
    public class ProjectDependency
    {
        [JsonProperty("projectName")]
        public string projectName { get; set; }

        [JsonProperty("dependencies")]
        public List<string> dependencies { get; set; }
    }
}
