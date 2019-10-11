using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Skuld.Core.CustomProjectSettings
{
    [Serializable]
    public class ApplicationSettings : SettingsObject<ApplicationSettings>
    {
        public Skuld.Core.ResidentSceneList ResidentSceneList;
    }
}
