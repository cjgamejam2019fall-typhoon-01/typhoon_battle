using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.Typhoon
{
    public class TyphoonGenerator : HID.ActionsManagement.Components.GameActionsComponent
    {
        public GameObject TyphoonObject = null;
        public GameObject ParentTyphoonList = null;

        private Vector2 mousePosition = Vector2.zero;

        protected override void OnMousePositionX(InputAction.CallbackContext context)
        {
            mousePosition.x = context.ReadValue<float>();
        }

        protected override void OnMousePositionY(InputAction.CallbackContext context)
        {
            mousePosition.y = context.ReadValue<float>();
        }

        protected override void OnRespawn(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                var ray = UnityEngine.Camera.main.ScreenPointToRay(mousePosition);
                var hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    var position = hit.point.normalized * (hit.point.magnitude + 2f);
                    var rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                    var instance = Instantiate<GameObject>(TyphoonObject, position, rotation);
                    instance.transform.parent = ParentTyphoonList.transform;
                    var scale = Random.Range(2f, 3f);
                    instance.transform.localScale = new Vector3(scale, scale, 1f);
                }
            }
        }
    }
}
