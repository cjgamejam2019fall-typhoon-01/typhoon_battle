using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.Controller
{
    public abstract class TapController : HID.ActionsManagement.Components.GameActionsComponent
    {
        private Vector2 mousePosition = Vector2.zero;

        public enum GenerateType
        {
            None,
            Wind,
            Typhoon
        }
        public GenerateType _GenerateType = GenerateType.None;

        protected override void OnMousePositionX(InputAction.CallbackContext context)
        {
            mousePosition.x = context.ReadValue<float>();
        }

        protected override void OnMousePositionY(InputAction.CallbackContext context)
        {
            mousePosition.y = context.ReadValue<float>();
        }

        protected override void OnGenerateWind(InputAction.CallbackContext context)
        {
            if (_GenerateType == GenerateType.Wind)
            {
                OnGenerate(context);
            }
        }

        protected override void OnGenerateTyphoon(InputAction.CallbackContext context)
        {
            if (_GenerateType == GenerateType.Typhoon)
            {
                OnGenerate(context);
            }
        }

        private void OnGenerate(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                var ray = UnityEngine.Camera.main.ScreenPointToRay(mousePosition);
                var hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    OnTap(hit);
                }
            }
        }

        protected abstract void OnTap(RaycastHit hit);
    }
}
