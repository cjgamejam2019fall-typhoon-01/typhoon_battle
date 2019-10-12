using Skuld.HID.ActionsManagement;

namespace Apps.HID.ActionsManagement.Maps
{
    [System.Serializable]
    public sealed class GameMap : ActionMapBase<InputActions, InputActions.IGameActions>
    {
        InputActions.GameActions _mapping;

        public override void RegisterCallback(InputActions.IGameActions instance)
        {
            RegisterCallback(_mapping.RotationTrigger, instance.OnRotationTrigger);
            RegisterCallback(_mapping.RotationX, instance.OnRotationX);
            RegisterCallback(_mapping.RotationY, instance.OnRotationY);
            RegisterCallback(_mapping.Zoom, instance.OnZoom);
        }

        public override void DeregisterCallback(InputActions.IGameActions instance)
        {
            DeregisterCallback(_mapping.RotationTrigger, instance.OnRotationTrigger);
            DeregisterCallback(_mapping.RotationX, instance.OnRotationX);
            DeregisterCallback(_mapping.RotationY, instance.OnRotationY);
            DeregisterCallback(_mapping.Zoom, instance.OnZoom);
        }

        protected override void Enable()
        {
            _mapping.Enable();
        }

        protected override void Disable()
        {
            _mapping.Disable();
        }

        protected override void Setup(InputActions input)
        {
            _mapping = new InputActions.GameActions(input);
        }
    }
}
