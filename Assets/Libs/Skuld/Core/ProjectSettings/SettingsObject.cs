using System.IO;
using UnityEditor;
using UnityEngine;

namespace Skuld.Core.CustomProjectSettings
{
    public class SettingsObject<T> : ScriptableObject
        where T : ScriptableObject
    {
#if UNITY_EDITOR
        public static T GetOrCreate(string settingsName)
        {
            var dir = "Assets/CustomProjectSettings/Resources/";
            var path = string.Format($"{dir}{settingsName}.asset");
            var settings = AssetDatabase.LoadAssetAtPath<T>(path);

            if (settings != null)
            {
                return settings;
            }

            settings = CreateInstance<T>();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            AssetDatabase.CreateAsset(settings, path);
            AssetDatabase.SaveAssets();

            return settings;
        }
#endif

#if UNITY_EDITOR
        public static SerializedObject GetSerializedObject()
        {
            return new SerializedObject(GetOrCreate(typeof(T).Name));
        }
#endif
    }
}
