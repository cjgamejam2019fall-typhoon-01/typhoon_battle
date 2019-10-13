using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Apps.UI
{
    public class StartTimer : MonoBehaviour
    {
        public Text Text = null;

        public AudioClip CountDown321Audio = null;
        public AudioClip CountDownUpAudio = null;
        private AudioSource audioSource = null;

        public GameObject EnableOn2 = null;
        public GameObject EnableOn1 = null;
        public GameObject EnableOn0 = null;

        private bool IsWaiting = true;
        public float WaitTime = 1.5f;
        private float WaitTimer = 1.5f;

        public float TransparentTime = 1;
        private float TransparentTimer = 1;
        private bool IsTransparentUpdate = false;

        private int CurrentTime = 3;

        public void OnStartGame()
        {
            enabled = true;
        }

        void Start()
        {
            WaitTimer = WaitTime;
            TransparentTimer = TransparentTime;
            Text.text = "";

            EnableOn2.SetActive(false);
            EnableOn1.SetActive(false);
            EnableOn0.SetActive(false);

            audioSource = GetComponent<AudioSource>();

            enabled = false;
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
                    audioSource.PlayOneShot(CountDown321Audio);
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
                    if (CurrentTime == 2)
                    {
                        EnableOn2.SetActive(true);
                        Text.text = CurrentTime.ToString();
                        audioSource.PlayOneShot(CountDown321Audio);
                    }
                    else if (CurrentTime == 1)
                    {
                        EnableOn1.SetActive(true);
                        Text.text = CurrentTime.ToString();
                        audioSource.PlayOneShot(CountDown321Audio);
                    }
                    else if (CurrentTime == 0)
                    {
                        EnableOn0.SetActive(true);
                        Text.text = "Start";
                        audioSource.PlayOneShot(CountDownUpAudio);
                    }
                    else if (CurrentTime == -1)
                    {
                        Text.text = "";
                        enabled = false;
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
