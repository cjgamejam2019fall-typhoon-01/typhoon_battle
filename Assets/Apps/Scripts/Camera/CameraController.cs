using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Apps.Camera
{
    public class CameraController : HID.ActionsManagement.Components.GameActionsComponent
    {
        [ReadOnly] public InputActionPhase CurrentPhase = InputActionPhase.Disabled;
        [ReadOnly] public bool _IsRotation = false;

        [ReadOnly] public float azimuthalAngle = 45f;
        [ReadOnly] public float polarAngle = 45f;

        [ReadOnly] public Vector2 mouseDelta = Vector2.zero;

        [SerializeField] private GameObject lookAtTarget = null;
        [SerializeField] private float distance = 10f;
        [SerializeField] private float inputSensitivity = 1f;
        [SerializeField] private float rotationDeceleration = 1f;

        protected override void OnRotationTrigger(InputAction.CallbackContext context)
        {
            CurrentPhase = context.phase;
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    _IsRotation = true;
                    break;

                case InputActionPhase.Canceled:
                    _IsRotation = false;
                    mouseDeltaRemnant = mouseDelta;
                    break;
            }
        }

        protected override void OnRotationX(InputAction.CallbackContext context)
        {
            mouseDelta.x = (float)context.ReadValue<float>();
        }

        protected override void OnRotationY(InputAction.CallbackContext context)
        {
            mouseDelta.y = -(float)context.ReadValue<float>();
        }

        private void rotateAround(Vector2 delta)
        {
            var axis = transform.up * delta.x + transform.right * delta.y;
            var angle = Mathf.Pow(delta.magnitude * 0.5f, inputSensitivity);
            transform.RotateAround(lookAtTarget.transform.position, axis, angle);
        }

        private Vector2 mouseDeltaRemnant = Vector2.zero;
        private void LateUpdate()
        {
            if (_IsRotation)
            {
                rotateAround(mouseDelta);
            }
            else
            {
                var magnitude = mouseDeltaRemnant.magnitude;
                if (magnitude > 0.01f)
                {
                    rotateAround(mouseDeltaRemnant);

                    mouseDeltaRemnant = mouseDeltaRemnant.normalized * (magnitude * rotationDeceleration * Time.deltaTime);
                }
            }
        }
    }
}
