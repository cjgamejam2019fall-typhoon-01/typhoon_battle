using UnityEngine;

namespace Skuld.Core.CustomProjectSettings
{
    public sealed class ApplicationSettingsLoader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnLoadRuntime()
        {
            var settings = Resources.Load<ApplicationSettings>("ApplicationSettings");
            if (settings == null)
            {
                return;
            }

            LoadResidentScenes(settings.ResidentSceneList);
        }

        private static void LoadResidentScenes(ResidentSceneList list)
        {
            SceneManagement.ResidentSceneLoader.Load(list);
        }
    }
}
