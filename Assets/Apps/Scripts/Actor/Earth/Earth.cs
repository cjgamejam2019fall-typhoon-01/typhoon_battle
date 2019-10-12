using UnityEngine;

namespace Apps.Actor.Earth
{
    public class Earth : MonoBehaviour
    {
        private VectorField.VectorField _VectorField = null;

        private void Awake()
        {
            _VectorField = GetComponentInChildren<VectorField.VectorField>();
            ActorManager.Earth = this;
        }

        public VectorField.VectorField VectorField => _VectorField;
    }
}
