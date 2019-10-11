using UnityEngine;

namespace Skuld.HID.ActionsManagement
{
    public abstract class ActionsSystemBase<TInputActions, TActionMaps>
        : Core.SingletonBehavior<ActionsSystemBase<TInputActions, TActionMaps>>
        where TInputActions : UnityEngine.InputSystem.IInputActionCollection, new()
        where TActionMaps : ActionMapsBase<TInputActions>, new()
    {
        private void OnEnable()
        {
            _inputActions.Enable();
            _maps.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
            _maps.Disable();
        }

        override protected void Awake()
        {
            base.Awake();

            _inputActions = new TInputActions();
            _maps.Setup(_inputActions);
        }

        TInputActions _inputActions;

        public TActionMaps Maps { get { return _maps; } }
        [SerializeField] TActionMaps _maps = new TActionMaps();
    }
}
