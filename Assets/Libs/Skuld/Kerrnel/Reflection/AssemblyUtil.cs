using System;
using System.Reflection;
using System.Linq;

namespace Skuld.Kernel.Reflection
{
    public class AssemblyUtil
    {
        public static Assembly GetAssembly(string assemblyName)
        {
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var asm in asms)
            {
                if (asm.GetName().Name == assemblyName)
                {
                    return asm;
                }
            }
            return null;
        }

        public static Type GetType(string assemblyName, string typeName)
        {
            var asm = GetAssembly(assemblyName);
            if (asm == null)
            {
                return null;
            }

            var types = asm.GetTypes().Where(p => p.Name == typeName);
            return asm.GetTypes().FirstOrDefault(p => p.Name == typeName);
        }
    }
}
