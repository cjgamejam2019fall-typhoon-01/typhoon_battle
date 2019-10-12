using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.Earth
{
    public class VectorField : MonoBehaviour
    {
        public class VectorInfo
        {
            public Vector3 start = Vector3.zero;
            public Vector3 end = Vector3.zero;

            public VectorInfo(Vector3 p0, Vector3 p1)
            {
                start = p0;
                end = p1;
            }
        }

        public GameObject _DebugDrawer = null;
        public VectorDrawer _VectorDrawer = null;

        [Range(0.0f, 1.0f)]
        public float _FieldDensity = 0.1f;
        public MeshFilter _MeshFilter = null;
        public List<VectorInfo> VectorInfoList = new List<VectorInfo>();

        public float _Radius = 100f;
        public float _Length = 50f;

        private void Awake()
        {
            // Get normals.
            var normals = new List<Vector3>();
            _MeshFilter.mesh.GetNormals(normals);

            VectorInfoList.Clear();
            _FieldDensity = Mathf.Clamp(_FieldDensity, 0.0f, 1.0f);
            foreach (var normal in normals)
            {
                if(Random.Range(0f,1f) <= _FieldDensity)
                {
                    var p0 = normal * _Radius;
                    var p1 = p0 + normal * _Length;
                    VectorInfoList.Add(new VectorInfo(p0, p1));
                }
            }

            // Create debug vector fields drawer.
            foreach (var vinfo in VectorInfoList)
            {
                var drawer = Instantiate<VectorDrawer>(_VectorDrawer, _DebugDrawer.transform);
                drawer.SetPosition(vinfo.start, vinfo.end);
            }
        }
    }
}
