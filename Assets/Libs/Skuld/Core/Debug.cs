using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Skuld
{
#if UNITY_EDITOR
    public class Debug
    {
        public static void Log(object message) => UnityEngine.Debug.Log(message);
        public static void Log(object message, UnityEngine.Object context) => UnityEngine.Debug.Log(message, context);

        public static void LogWarning(object message) => UnityEngine.Debug.LogWarning(message);
        public static void LogWarning(object message, UnityEngine.Object context) => UnityEngine.Debug.LogWarning(message, context);

        public static void LogError(object message) => UnityEngine.Debug.LogError(message);
        public static void LogError(object message, UnityEngine.Object context) => UnityEngine.Debug.LogError(message, context);

        public static void LogAssertion(object message) => UnityEngine.Debug.LogAssertion(message);
        public static void LogAssertion(object message, UnityEngine.Object context) => UnityEngine.Debug.LogAssertion(message, context);

        public static void LogException(Exception exception) => UnityEngine.Debug.LogException(exception);
        public static void LogException(Exception exception, UnityEngine.Object context) => UnityEngine.Debug.LogException(exception, context);

        public static void Break() => UnityEngine.Debug.Break();

        public static void DisplayDialog(string title, string description, string ok) => UnityEditor.EditorUtility.DisplayDialog(title, description, ok);
        public static void DisplayDialog(string title, string description, string ok, string cancel) => UnityEditor.EditorUtility.DisplayDialog(title, description, ok, cancel);
        public static void DisplayDialog(string title, string description, string ok, string cancel, string alt) => UnityEditor.EditorUtility.DisplayDialogComplex(title, description, ok, cancel, alt);
    }
#endif
}
