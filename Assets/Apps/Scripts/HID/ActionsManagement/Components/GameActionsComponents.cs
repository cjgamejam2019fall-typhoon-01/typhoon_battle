using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.HID.ActionsManagement.Components
{
    public abstract class GameActionsComponent : MonoBehaviour, InputActions.IGameActions
    {
        Maps.GameMap _GameMap;

        protected abstract void OnRotationTrigger(InputAction.CallbackContext context);
        void InputActions.IGameActions.OnRotationTrigger(InputAction.CallbackContext context) => OnRotationTrigger(context);

        protected abstract void OnRotationX(InputAction.CallbackContext context);
        void InputActions.IGameActions.OnRotationX(InputAction.CallbackContext context) => OnRotationX(context);

        protected abstract void OnRotationY(InputAction.CallbackContext context);
        void InputActions.IGameActions.OnRotationY(InputAction.CallbackContext context) => OnRotationY(context);

        protected abstract void OnZoom(InputAction.CallbackContext context);
        void InputActions.IGameActions.OnZoom(InputAction.CallbackContext context) => OnZoom(context);

        void Start()
        {
            _GameMap = ActionsSystem.Instance.Maps.Game;
            _GameMap.RegisterCallback(this);
        }

        void OnDestroy()
        {
            _GameMap.DeregisterCallback(this);
        }
    }
}
