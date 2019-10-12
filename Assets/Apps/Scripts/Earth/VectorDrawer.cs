using UnityEngine;

namespace Apps.Earth
{
    public class VectorDrawer : MonoBehaviour
    {
        private LineRenderer _Renderer = null;

        private void Awake()
        {
            _Renderer = GetComponent<LineRenderer>();
            _Renderer.positionCount = 2;
        }

        public void SetPosition(Vector3 a, Vector3 b)
        {
            // position
            _Renderer.SetPosition(0, a);
            _Renderer.SetPosition(1, b);

            // color
            var normal = a.normalized;
            var color = new Color(normal.x, normal.y, 1f);
            _Renderer.startColor = color;
            _Renderer.endColor = color;
            _Renderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        }
    }
}
