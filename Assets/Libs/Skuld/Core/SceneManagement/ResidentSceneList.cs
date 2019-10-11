using System;
using System.Collections.Generic;
using Trisibo;
using UnityEngine;

namespace Skuld.Core
{
    [Serializable]
    public class SceneInfo
    {
        public bool IsAsyncLoad = false;
        public SceneField Scene = null;
    }

    [CreateAssetMenu(menuName = "ScriptableObject/Skuld/ResidentSceneList")]
    public class ResidentSceneList : ScriptableObject
    {
        [SerializeField]
        private List<SceneInfo> _SceneInfoList = null;

        [HideInInspector]
        public List<SceneInfo> SceneInfoList => _SceneInfoList;
    }
}
