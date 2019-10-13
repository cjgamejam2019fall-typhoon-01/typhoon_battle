using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Apps.UI
{
    public class LoadTitle : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(1);
            SceneManager.LoadScene(0, LoadSceneMode.Additive);
        }
    }
}
