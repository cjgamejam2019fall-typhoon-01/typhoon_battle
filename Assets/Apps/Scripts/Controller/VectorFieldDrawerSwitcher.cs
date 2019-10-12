using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.Controller
{
    public class VectorFieldDrawerSwitcher : HID.ActionsManagement.Components.GameActionsComponent
    {
        private bool IsDraw = false;

        protected override void OnVectorFieldDrawerSwitch(InputAction.CallbackContext context)
        {
            IsDraw = !IsDraw;
            var list = Actor.ActorManager.Earth.VectorField.VectorInfoList;
            foreach (var info in list)
            {
                info.Drawer._Renderer.enabled = IsDraw;
            }
        }
    }
}
