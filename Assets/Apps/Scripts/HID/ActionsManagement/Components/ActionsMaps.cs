using UnityEngine;

namespace Apps.HID.ActionsManagement
{
    public sealed class ActionMaps : Skuld.HID.ActionsManagement.ActionMapsBase<InputActions>
    {
        public Maps.GameMap Game { get { return _game; } }
        [SerializeField] Maps.GameMap _game = new Maps.GameMap();

        protected override void Setup()
        {
            _collection.Add(_game);
        }
    }
}
