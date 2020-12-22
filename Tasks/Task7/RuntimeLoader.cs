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
        private static Assembly loadedAssembly;
        private static List<string>
            validExtensions = new List<string>
            {
                ".cs"
            };

        public static bool ExecuteMethod(string className, string methodName)
        {
            Type commandType = loadedAssembly.GetType(className);

            object commandInstance = Activator.CreateInstance(commandType);

            MethodInfo sayHelloMethod =
                commandType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            sayHelloMethod.Invoke(commandInstance, null);
            return false;
        }

        public static Type[] GetTypes()
        {
            return loadedAssembly.GetTypes();
        }

        public static bool LoadAssembly(string path, out string error)
        {
            var info = new DirectoryInfo(path);
            FileInfo[] sourceFiles = info.GetFiles()
                .Where(f => IsValidFileType(f.Name))
                .ToArray();
            string[] sourceFileNames = new string[sourceFiles.Length];
            for (int i = 0; i < sourceFiles.Length; i++)
            {
                sourceFileNames[i] = sourceFiles[i].FullName;
            }

            string outputName = string.Format(@"{0}\{1}.dll",
                Environment.CurrentDirectory,
                Path.GetFileNameWithoutExtension(path+"temp"));

            bool IsValidFileType(string fileName)
            {
                return validExtensions.Contains(Path.GetExtension(fileName));
            }

            bool success = Compile(sourceFileNames, new CompilerParameters()
            {
                GenerateExecutable = false,
                OutputAssembly = outputName,
                GenerateInMemory = false,
            });

            if (success)
            {
                loadedAssembly = Assembly.LoadFile(outputName);
            }
            else
            {
                error = "failed ro load library";
                return false;
            }
            error = String.Empty;
            return true;
        }

        private static bool Compile(string[] sourceFiles, CompilerParameters options)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            CompilerResults results = provider.CompileAssemblyFromFile(options, sourceFiles);

            if (results.Errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}