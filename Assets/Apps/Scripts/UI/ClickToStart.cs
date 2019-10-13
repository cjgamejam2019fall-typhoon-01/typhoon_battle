using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.UI
{
    public class ClickToStart : HID.ActionsManagement.Components.GameActionsComponent
    {
        public AudioClip StartAudio;
        public StartTimer StartTimer;
        public GameObject TitleUI;

        protected override void OnGenerateWind(InputAction.CallbackContext context)
        {
            StartTimer.OnStartGame();
            TitleUI.SetActive(false);
        }
    }
}
