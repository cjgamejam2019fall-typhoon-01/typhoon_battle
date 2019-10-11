using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using System;

namespace Skuld.Core.CustomProjectSettings.Editor
{
    public class SettingsProvider<T, U> : SettingsProvider
        where U : SettingsProvider
    {
        private SerializedObject _Settings;

        public SettingsProvider() :base(null, SettingsScope.Project) { throw new NotSupportedException(); }

        public SettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            _Settings = GetSerializedObject();
        }

        private static SerializedObject GetSerializedObject()
        {
            return (SerializedObject)typeof(T).GetMethod("GetSerializedObject", BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.FlattenHierarchy).Invoke(null, null);
        }

        protected static SettingsProvider CreateProvider()
        {
            var settingsName = typeof(T).Name.RemoveLast("Settings");
            var path = string.Format($"Project/{settingsName}");
            var provider = (SettingsProvider)typeof(U).GetConstructor(new Type[] { typeof(string), typeof(SettingsScope), typeof(IEnumerable<string>) }).Invoke(new object[] {path, SettingsScope.Project, null});
            var settings = GetSerializedObject();
            provider.keywords = GetSearchKeywordsFromSerializedObject(settings);
            return provider;
        }

        protected virtual void OnGUIHeader()
        {
        }

        protected virtual void OnGUIFooter()
        {
        }

        protected void OnGUIProperty()
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var info in fields)
            {
                EditorGUILayout.PropertyField(_Settings.FindProperty(info.Name));
            }
#if false
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (var info in properties)
            {
                EditorGUILayout.PropertyField(_Settings.FindProperty(info.Name));
            }
#endif
        }

        protected void OnGUIAfter()
        {
            _Settings.ApplyModifiedProperties();
        }

        protected void OnGUIDefault()
        {
            OnGUIHeader();
            OnGUIProperty();
            OnGUIAfter();
            OnGUIFooter();
        }

        public override void OnGUI(string searchContext)
        {
            OnGUIDefault();
        }
    }
}
