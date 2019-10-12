using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
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
        }

        protected override void OnGUIFooter()
        {
        }
    }
}
#endif
