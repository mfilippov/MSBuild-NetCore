using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Please specify the full path to an MSBuild project to load.");
                return 1;
            }

            string projectPath = Path.GetFullPath(args[0]);

            if (!File.Exists(projectPath))
            {
                Console.Error.WriteLine($"The project file '{projectPath}' does not exist or is inaccessible.");
                return 2;
            }

            IDictionary<string,string> globalProperties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "MSBuildExtensionsPath", AppContext.BaseDirectory } // Workaround the MSBuildExtensionsPath being set wrong by MSBuild
            };

            Project project = new Project(projectPath, globalProperties, toolsVersion: null);

            Console.WriteLine($"Successfully loaded project file '{projectPath}'.");

            while (true)
            {
                Console.Write("Please entry a property to read, or press Enter to exit: ");

                string propertyName = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(propertyName))
                {
                    break;
                }

                Console.WriteLine();

                Console.WriteLine($"  {propertyName} = '{project.GetPropertyValue(propertyName)}'");

                Console.WriteLine();
            }

            return 0;
        }
    }
}