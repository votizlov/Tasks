using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Task7
{
    public class RuntimeLoader
    {
        public static bool test(string path,out string error)
        {
            // Get a path to the file(s) to compile.
            FileInfo sourceFile = new FileInfo("Task1.cs");
            Console.WriteLine("Loading file: " + sourceFile.Exists);

            // Prepary a file path for the compiled library.
            string outputName = string.Format(@"{0}\{1}.dll",
                Environment.CurrentDirectory,
                Path.GetFileNameWithoutExtension(sourceFile.Name));

            // Compile the code as a dynamic-link library.
            bool success = Compile(sourceFile, new CompilerParameters()
            {
                GenerateExecutable = false, // compile as library (dll)
                OutputAssembly = outputName,
                GenerateInMemory = false, // as a physical file
            });

            if (success)
            {
                // Load the compiled library.
                Assembly assembly = Assembly.LoadFrom(outputName);

                // Now, since we didn't have reference to the library when building
                // the RuntimeCompile program, we can use reflection to create 
                // and use the dynamically created objects.
                Type commandType = assembly.GetType("Task1");
                //Type[] types = assembly.GetTypes();

                // Create an instance of the loaded class from its type information.
                object commandInstance = Activator.CreateInstance(commandType);

                // Invoke the method by name.
                MethodInfo sayHelloMethod =
                    commandType.GetMethod("test", BindingFlags.Public | BindingFlags.Instance);
                sayHelloMethod.Invoke(commandInstance, null); // no arguments, no return type
            }
            else
            {
                //error = "failed ro load library";
                error = sourceFile.FullName;
                return false;
            }

            Console.WriteLine("Press any key to exit...");
            //Console.Read();
            error = String.Empty;
            return true;
        }

        private static bool Compile(FileInfo sourceFile, CompilerParameters options)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            CompilerResults results = provider.CompileAssemblyFromFile(options, sourceFile.FullName);

            if (results.Errors.Count > 0)
            {
                Console.WriteLine("Errors building {0} into {1}", sourceFile.Name, results.PathToAssembly);
                foreach (CompilerError error in results.Errors)
                {
                    Console.WriteLine("  {0}", error.ToString());
                    Console.WriteLine();
                }
                return false;
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.", sourceFile.Name, results.PathToAssembly);
                return true;
            }
        }
    }
}