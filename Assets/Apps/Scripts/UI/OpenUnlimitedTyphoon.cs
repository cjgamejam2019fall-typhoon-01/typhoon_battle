using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.UI
{
    public class OpenUnlimitedTyphoon : HID.ActionsManagement.Components.GameActionsComponent
    {
        public GameObject TyphoonGenerator;

        protected override void OnUTMode(InputAction.CallbackContext context)
        {
            TyphoonGenerator.SetActive(true);
        }
    }
}
