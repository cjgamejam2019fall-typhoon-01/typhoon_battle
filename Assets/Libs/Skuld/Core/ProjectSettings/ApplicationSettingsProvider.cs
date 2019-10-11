using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Skuld.Core.CustomProjectSettings.Editor
{
    public class ApplicationSettingsProvider : SettingsProvider<ApplicationSettings, ApplicationSettingsProvider>
    {
        public ApplicationSettingsProvider() { }
        public ApplicationSettingsProvider(string path, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords) { }

        [SettingsProvider]
        private static SettingsProvider Create()
        {
            return CreateProvider();
        }

        protected override void OnGUIHeader()
        {
#if UNITY_EDITOR
            var lang = Skuld.Core.Localization.GetEditorLanguage();
            //string message = "";
            switch (lang)
            {
                case SystemLanguage.Japanese:
                    break;
                default:
                    break;
            }

            //EditorGUILayout.HelpBox(message, MessageType.Info);
#endif
        }

        protected override void OnGUIFooter()
        {
#if UNITY_EDITOR
#endif
        }
    }
}
