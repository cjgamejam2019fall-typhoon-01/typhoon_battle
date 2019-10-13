using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apps.UI
{
    public class StartTimer : MonoBehaviour
    {
        public Text Text = null;

        private bool IsWaiting = true;
        public float WaitTime = 1.5f;
        private float WaitTimer = 1.5f;

        public float TransparentTime = 1;
        private float TransparentTimer = 1;
        private bool IsTransparentUpdate = false;

        private int CurrentTime = 3;

        void Start()
        {
            WaitTimer = WaitTime;
            TransparentTimer = TransparentTime;
            Text.text = "";
        }

        void Update()
        {
            if (IsWaiting)
            {
                WaitTimer -= Time.deltaTime;
                if (WaitTimer <= 0)
                {
                    IsWaiting = false;
                    Text.text = CurrentTime.ToString();
                    return;
                }
            }
            else
            {
                if (IsTransparentUpdate)
                {
                    IsTransparentUpdate = false;
                    TransparentTimer = TransparentTime;
                    --CurrentTime;
                    if (CurrentTime == 0)
                    {
                        Text.text = "Start";
                    }
                    else if (CurrentTime == -1)
                    {
                        Text.text = "";
                        enabled = false;
                    }
                    else
                    {
                        Text.text = CurrentTime.ToString();
                    }

                    var color = Text.color;
                    color.a = 1;
                    Text.color = color;
                }

                TransparentTimer -= Time.deltaTime;
                if (TransparentTimer <= 0)
                {
                    TransparentTimer = 0;
                    IsTransparentUpdate = true;
                }

                {
                    var color = Text.color;
                    color.a = TransparentTimer / TransparentTime;
                    Text.color = color;
                }
            }
        }
    }
}
