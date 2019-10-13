using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Apps.UI
{
    public class Reset : HID.ActionsManagement.Components.GameActionsComponent
    {
        protected override void OnReset(InputAction.CallbackContext context)
        {
            //SceneManager.UnloadScene(0);
            SceneManager.LoadScene(2);
            //SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }
    }
}
