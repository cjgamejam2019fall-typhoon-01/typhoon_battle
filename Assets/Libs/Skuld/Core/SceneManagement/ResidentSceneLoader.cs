using UnityEngine;
using UnityEngine.SceneManagement;

namespace Skuld.Core.SceneManagement
{
    public sealed class ResidentSceneLoader
    {
        public static void Load(ResidentSceneList list)
        {
            foreach (var info in list.SceneInfoList)
            {
                var index = info.Scene.BuildIndex;
                if (index >= 0)
                {
                    SceneManager.LoadScene(index, LoadSceneMode.Additive);
                }
            }
        }
    }
}
