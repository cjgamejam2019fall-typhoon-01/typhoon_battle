using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.VectorField
{
    public class VectorField : MonoBehaviour
    {
        public class ForceInfo
        {
            public Wind.WindSource WindSource = null;
            public Vector3 Force = Vector3.zero;

            public ForceInfo(Wind.WindSource source, Vector3 force)
            {
                WindSource = source;
                Force = force;
            }
        }

        public class VectorInfo
        {
            private Vector3 _Root = Vector3.zero;
            private Vector3 _NormalEdge = Vector3.zero;
            private Vector3 _CurrentEdge = Vector3.zero;
            private Vector3 _TargetEdge = Vector3.zero;
            public VectorDrawer Drawer = null;
            public List<ForceInfo> ForceInfoList = new List<ForceInfo>();
            public float lerpRatio = 0f;

            public Vector3 CurrentEdge
            {
                private get => _CurrentEdge;
                set
                {
                    _CurrentEdge = value;
                    Drawer.SetPosition(_Root, _CurrentEdge);
                }
            }

            public Vector3 NormalEdge { get => _NormalEdge; }
            public Vector3 Root { get => _Root; set => _Root = value; }
            public Vector3 TargetEdge
            {
                get => _TargetEdge;
                private set => _TargetEdge = value;
            }

            public VectorInfo(Vector3 p0, Vector3 p1)
            {
                _Root = p0;
                _NormalEdge = _CurrentEdge = _TargetEdge = p1;
            }

            public void AddForce(Wind.WindSource source, Vector3 force)
            {
                ForceInfoList.Add(new ForceInfo(source, force));
                UpdateTargetForce();
            }

            public void RemoveForce(Wind.WindSource source)
            {
                foreach (var info in ForceInfoList)
                {
                    if (info.WindSource == source)
                    {
                        ForceInfoList.Remove(info);
                        break;
                    }
                }
                UpdateTargetForce();
            }

            private void UpdateTargetForce()
            {
                var edge = Vector3.zero;
                var num = 0;
                foreach (var info in ForceInfoList)
                {
                    edge += info.Force;
                    ++num;
                }
                if (num > 0)
                {
                    TargetEdge = edge / num;
                }
                else
                {
                    TargetEdge = Root;
                }
                lerpRatio = 1f;
            }

            public void UpdateCurrentForce(float force)
            {
                if (lerpRatio > 0f)
                {
                    lerpRatio = Mathf.Clamp01(lerpRatio - Time.deltaTime*force);
                    CurrentEdge = Vector3.Lerp(TargetEdge, CurrentEdge, lerpRatio);
                }
            }
        }

        public GameObject _DebugDrawer = null;
        public VectorDrawer _VectorDrawer = null;

        [Range(0.0f, 1.0f)]
        public float _FieldDensity = 0.1f;
        public MeshFilter _MeshFilter = null;
        public List<VectorInfo> VectorInfoList = new List<VectorInfo>();

        public float _ForceLerpSpeedRatio = 0.5f;

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
                    var vectorInfo = new VectorInfo(p0, p1);
                    VectorInfoList.Add(vectorInfo);

                    // Create debug vector fields drawer.
                    var drawer = Instantiate<VectorDrawer>(_VectorDrawer, _DebugDrawer.transform);
                    drawer.SetPosition(p0, p1);
                    vectorInfo.Drawer = drawer;
                }
            }
        }

        private void Update()
        {
            foreach (var info in VectorInfoList)
            {
                info.UpdateCurrentForce(_ForceLerpSpeedRatio);
            }
        }
    }
}
