using System.Collections.Generic;

namespace Skuld.HID.ActionsManagement
{
    public abstract class ActionMapsBase<TInputActions>
    {
        protected List<ActionsManagement.IActionMapBase<TInputActions>> _collection = new List<ActionsManagement.IActionMapBase<TInputActions>>();

        internal void Enable() => _collection.ForEach(_ => _.Enable());

        internal void Disable() => _collection.ForEach(_ => _.Disable());

        internal void Setup(TInputActions inputActions)
        {
            Setup();
            _collection.ForEach(_ => _.Setup(inputActions));
        }

        protected abstract void Setup();
    }
}
