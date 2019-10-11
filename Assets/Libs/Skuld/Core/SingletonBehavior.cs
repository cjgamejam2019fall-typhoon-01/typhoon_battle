using UnityEngine;

namespace Skuld.Core
{
    public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        virtual protected void Awake()
        {
            Instance = this as T;
        }
    }
}
