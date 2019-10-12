using UnityEngine;

namespace Apps.Controller
{
    public class TapGenerator : Controller.TapController
    {
        public GameObject SourceObject = null;
        public GameObject StackObject = null;
        public float FloatingOffset = 2f;
        public Vector2 ScaleRange = Vector2.one;

        public enum RotationDirection
        {
            Forward, Back, Up, Down, Right, Left
        }
        public RotationDirection Direction = RotationDirection.Forward;

        protected override void OnTap(RaycastHit hit)
        {
            var position = hit.point.normalized * (hit.point.magnitude + FloatingOffset);
            var direction = Vector3.zero;
            switch (Direction) {
                case RotationDirection.Forward:
                    direction = Vector3.forward; break;
                case RotationDirection.Back:
                    direction = Vector3.back; break;
                case RotationDirection.Up:
                    direction = Vector3.up; break;
                case RotationDirection.Down:
                    direction = Vector3.down; break;
                case RotationDirection.Left:
                    direction = Vector3.left; break;
                case RotationDirection.Right:
                    direction = Vector3.right; break;
            }
            var rotation = Quaternion.FromToRotation(direction, hit.normal);
            var instance = Instantiate<GameObject>(SourceObject, position, rotation);
            var scale = instance.transform.localScale * Random.Range(ScaleRange.x, ScaleRange.y);
            instance.transform.localScale = scale;
            instance.transform.parent = StackObject.transform;
        }
    }
}
