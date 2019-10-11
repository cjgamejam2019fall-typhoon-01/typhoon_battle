using System.Diagnostics;
using UnityEngine;

namespace Skuld.Core
{
    public class Localization
    {
#if UNITY_EDITOR
        public static SystemLanguage GetEditorLanguage()
        {
            var type = Skuld.Kernel.Reflection.AssemblyUtil.GetType("UnityEditor", "LocalizationDatabase");
            if (type != null)
            {
                var lang = (SystemLanguage)type.GetProperty("currentEditorLanguage").GetValue(null);
                return lang;
            }
            return SystemLanguage.English;
        }
#endif
    }
}
