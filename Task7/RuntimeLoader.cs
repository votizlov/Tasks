using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Task7
{
    public class RuntimeLoader
    {
        private static List<string>
            validExtensions = new List<string>
            {
                ".cs"
            }; 

        public static bool test(string path, out string error)
        {
            var info = new DirectoryInfo(path);
            FileInfo[] sourceFiles = info.GetFiles()
                .Where(f => IsValidFileType(f.Name))
                .ToArray();
            //FileInfo sourceFile = new FileInfo("Task1.cs");
            string[] sourceFileNames = new string[sourceFiles.Length];
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                sourceFileNames[i] = sourceFiles[i].FullName;
            }

            // Prepary a file path for the compiled library.
            string outputName = string.Format(@"{0}\{1}.dll",
                Environment.CurrentDirectory,
                Path.GetFileNameWithoutExtension(path+"temp"));

            bool IsValidFileType(string fileName)
            {
                return validExtensions.Contains(Path.GetExtension(fileName));
                // Alternatively, you could go fileName.SubString(fileName.LastIndexOf('.') + 1); that way you don't need the '.' when you add your extensions
            }

            // Compile the code as a dynamic-link library.
            bool success = Compile(sourceFileNames, new CompilerParameters()
            {
                GenerateExecutable = false, // compile as library (dll)
                OutputAssembly = outputName,
                GenerateInMemory = false, // as a physical file
            });

            if (success)
            {
                // Load the compiled library.
                Assembly assembly = Assembly.LoadFile(outputName);

                // Now, since we didn't have reference to the library when building
                // the RuntimeCompile program, we can use reflection to create 
                // and use the dynamically created objects.
                Type commandType = assembly.GetType("Task6.PartTimeStudent");
                //Type[] types = assembly.GetTypes();

                // Create an instance of the loaded class from its type information.
                object commandInstance = Activator.CreateInstance(commandType);

                // Invoke the method by name.
                MethodInfo sayHelloMethod =
                    commandType.GetMethod("DoLiterallyNothing", BindingFlags.Public | BindingFlags.Instance);
                sayHelloMethod.Invoke(commandInstance, null); // no arguments, no return type
            }
            else
            {
                error = "failed ro load library";
                return false;
            }

            Console.WriteLine("Press any key to exit...");
            //Console.Read();
            error = String.Empty;
            return true;
        }

        private static bool Compile(string[] sourceFiles, CompilerParameters options)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            CompilerResults results = provider.CompileAssemblyFromFile(options, sourceFiles);

            if (results.Errors.Count > 0)
            {
                // Console.WriteLine("Errors building {0} into {1}", sourceFile.Name, results.PathToAssembly);
                foreach (CompilerError error in results.Errors)
                {
                    Console.WriteLine("  {0}", error.ToString());
                    Console.WriteLine();
                }

                return false;
            }

            return true;
        }
    }
}