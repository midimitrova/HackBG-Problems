using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha3
{
    public static class DependencyManager
    {
        private static readonly string dependenciesFilePath = "json/dependencies.json";
        private static readonly string packagesFilePath = "json/all_packages.json";

        public static void Load()
        {
            string dependenciesJson = File.ReadAllText(dependenciesFilePath);
            string packagesJson = File.ReadAllText(packagesFilePath);

            ProjectDependency projDependency = JsonConvert.DeserializeObject<ProjectDependency>(dependenciesJson);
            Dictionary<string, List<string>> packages = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(packagesJson);

            ResolveDependencies(projDependency.dependencies, packages);
            Console.WriteLine("Done!");
        }

        private static void ResolveDependencies(List<string> dependencyList, Dictionary<string, List<string>> packages)
        {
            foreach (var dep in dependencyList)
            {
                string dirPath = string.Concat("installed_modules/", dep);

                if (!Directory.Exists(dirPath))
                {
                    Console.WriteLine("Installing {0}", dep);
                    Directory.CreateDirectory(dirPath);

                    List<string> childDependencies;

                    if (packages.TryGetValue(dep, out childDependencies))
                    {
                        if (childDependencies.Count > 0)
                        {
                            string allDependencies = string.Join(", ", childDependencies);
                            Console.WriteLine("Resolving dependencies for {0}", allDependencies);
                            ResolveDependencies(childDependencies, packages);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0} already installed." , dep);
                }
            }
        }
    }
}
