using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apps.UI
{
    public class TyphoonSpawnedUI : MonoBehaviour
    {
        public Text Text = null;
        public float HideTime = 3;
        private float HideTimer = 0;

        private void Awake()
        {
            UIManager.TyphoonSpawnedUI = this;
        }

        public void OnTyphoonSpawned()
        {
            ++GameSystem.GameManager.Level.TyphoonNumber;
            var num = GameSystem.GameManager.Level.TyphoonNumber;

            Text.enabled = true;
            Text.text = string.Format($"災害速報:台風{(uint)num}号が発生しました。");
            HideTimer = HideTime;
        }

        void Start()
        {
            Text.enabled = false;
        }

        void Update()
        {
            HideTimer -= Time.deltaTime;
            if (HideTimer <= 0)
            {
                Text.enabled = false;
            }
        }
    }
}
