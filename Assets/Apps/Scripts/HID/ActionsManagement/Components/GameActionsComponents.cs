using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.HID.ActionsManagement.Components
{
    public abstract class GameActionsComponent : MonoBehaviour, InputActions.IGameActions
    {
        Maps.GameMap _GameMap;

        protected virtual void OnRotationTrigger(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnRotationTrigger(InputAction.CallbackContext context) => OnRotationTrigger(context);

        protected virtual void OnRotationX(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnRotationX(InputAction.CallbackContext context) => OnRotationX(context);

        protected virtual void OnRotationY(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnRotationY(InputAction.CallbackContext context) => OnRotationY(context);

        protected virtual void OnZoom(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnZoom(InputAction.CallbackContext context) => OnZoom(context);

        protected virtual void OnGenerateWind(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnGenerateWind(InputAction.CallbackContext context) => OnGenerateWind(context);

        protected virtual void OnGenerateTyphoon(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnGenerateTyphoon(InputAction.CallbackContext context) => OnGenerateTyphoon(context);

        protected virtual void OnMousePositionX(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnMousePositionX(InputAction.CallbackContext context) => OnMousePositionX(context);

        protected virtual void OnMousePositionY(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnMousePositionY(InputAction.CallbackContext context) => OnMousePositionY(context);

        protected virtual void OnVectorFieldDrawerSwitch(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnVectorFieldDrawerSwitch(InputAction.CallbackContext context) => OnVectorFieldDrawerSwitch(context);

        protected virtual void OnReset(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnReset(InputAction.CallbackContext context) => OnReset(context);

        protected virtual void OnUTMode(InputAction.CallbackContext context) { }
        void InputActions.IGameActions.OnUTMode(InputAction.CallbackContext context) => OnUTMode(context);

        void Start()
        {
            _GameMap = ActionsSystem.Instance.Maps.Game;
            _GameMap.RegisterCallback(this);
        }

        void OnDestroy()
        {
            if (_GameMap != null)
            {

                _GameMap.DeregisterCallback(this);
            }
        }
    }
}
