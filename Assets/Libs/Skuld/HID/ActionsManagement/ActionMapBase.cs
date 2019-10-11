using UnityEngine.InputSystem;

namespace Skuld.HID.ActionsManagement
{
    public interface IActionMapBase<TInputActions>
    {
        void Enable();
        void Disable();
        void Setup(TInputActions inputActions);
    }

    public abstract class ActionMapBase<TInputActions, TActionsInterface> : IActionMapBase<TInputActions>
    {
        public abstract void RegisterCallback(TActionsInterface instance);
        public abstract void DeregisterCallback(TActionsInterface instance);

        protected void RegisterCallback(InputAction action, System.Action<InputAction.CallbackContext> context)
        {
            action.started += context;
            action.performed += context;
            action.canceled += context;
        }

        protected void DeregisterCallback(InputAction action, System.Action<InputAction.CallbackContext> context)
        {
            action.started -= context;
            action.performed -= context;
            action.canceled -= context;
        }

        protected abstract void Enable();
        void IActionMapBase<TInputActions>.Enable()
        {
            Enable();
        }
        protected abstract void Disable();
        void IActionMapBase<TInputActions>.Disable()
        {
            Disable();
        }
        protected abstract void Setup(TInputActions inputActions);
        void IActionMapBase<TInputActions>.Setup(TInputActions inputActions)
        {
            Setup(inputActions);
        }
    }
}
