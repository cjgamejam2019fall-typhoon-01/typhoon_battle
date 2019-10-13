using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apps.UI
{
    public class WindSlotRingUI : MonoBehaviour
    {
        private Image Image = null;
        private bool IsAnimating = false;
        private RectTransform rectTransform = null;

        public float ScalingRate = 1;
        public float TransparentRate = 1;

        private void Start()
        {
            Image = GetComponent<Image>();
            Image.enabled = false;

            rectTransform = GetComponent<RectTransform>();
        }

        public void StartAnimation()
        {
            if (IsAnimating)
            {
                return;
            }

            IsAnimating = true;

            // 表示
            Image.enabled = true;

            // 不透明
            var color = Image.color;
            color.a = 1.0f;
            Image.color = color;
        }

        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (!IsAnimating)
            {
                return;
            }

            var size = rectTransform.sizeDelta;
            size.x += ScalingRate * Time.deltaTime;
            size.y += ScalingRate * Time.deltaTime;
            rectTransform.sizeDelta = size;

            var color = Image.color;
            color.a = Mathf.Max(color.a - Time.deltaTime * TransparentRate, 0);
            if (color.a <= 0)
            {
                color.a = 1;
                IsAnimating = false;
                Image.enabled = false;
            }
            Image.color = color;
        }
    }
}
