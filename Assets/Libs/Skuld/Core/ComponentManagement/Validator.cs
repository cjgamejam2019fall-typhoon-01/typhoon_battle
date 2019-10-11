using System.Reflection;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Skuld.Core.ComponentManagement
{
    public class ComponentValidator
    {
        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        public static void RequireInterface<T>(MonoBehaviour target, Assembly assembly = null)
        {
#if UNITY_EDITOR
            System.Type[] assemblyTtypes;
            if (assembly == null)
            {
                var typeList = new List<System.Type>();
                var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
                foreach (var asm in assemblies)
                {
                    var asmTypes = asm.GetTypes().Where(c => c.GetInterfaces().Any(t => t == typeof(T))).ToArray();
                    typeList.AddRange(asmTypes);
                }
                assemblyTtypes = typeList.ToArray();
            }
            else
            {
                assemblyTtypes = assembly.GetTypes();
            }
            var types = assemblyTtypes.Where(c => c.GetInterfaces().Any(t => t == typeof(T))).ToArray();
            var description = new StringBuilder($"You can choose from the following components that inherit from {typeof(T).Name}.\n");
            foreach (var type in types)
            {
                description.Append($"  - {type.Name}");
            }

            string title = $"Add Component to {target.name}";
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                Debug.LogError($"{title}\n{description.ToString()}", target);
            }
            else
            {
                Debug.DisplayDialog(title, description.ToString(), "OK");
            }
#endif
        }
    }
}
