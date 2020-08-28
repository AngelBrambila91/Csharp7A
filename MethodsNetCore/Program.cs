using System;
using static System.Console;
using System.Linq;
using System.Reflection;
namespace MethodsNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                var a = Assembly.Load(new AssemblyName(r.FullName));
                int countMethod = 0;

                foreach (var t in a.DefinedTypes)
                {
                    countMethod += t.GetMethods().Count();
                }
                WriteLine(
                "{0:N0} types with {1:N0} methods in {2} assembly",
                arg0: a.DefinedTypes.Count(),
                arg1: countMethod,
                arg2: r.Name);
                
            }
        }
    }
}
