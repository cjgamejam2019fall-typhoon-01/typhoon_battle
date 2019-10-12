using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.Typhoon
{
    public class Typhoon : MonoBehaviour
    {
        public float EffectiveRange = 50f;
        public float MoveSpeedRatio = 1f;
        private List<VectorField.VectorField.VectorInfo> _NearVecorInfoList = new List<VectorField.VectorField.VectorInfo>();

        private void Awake()
        {
            GatherNearVectorInfo();
        }

        private void Update()
        {
            GatherNearVectorInfo();
            var vec = CalcMoveVector();
            var rayStart = transform.position + vec * Time.deltaTime * MoveSpeedRatio;

            var hit = new RaycastHit();
            if (Physics.Raycast(rayStart, -rayStart, out hit))
            {
                var position = hit.point.normalized * (hit.point.magnitude + 2f);
                var rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                transform.position = position;
                transform.rotation = rotation;
            }
        }

        private void GatherNearVectorInfo()
        {
#if UNITY_EDITOR
            if (ActorManager.Earth == null)
            {
                return;
            }
#endif

            var list = ActorManager.Earth.VectorField.VectorInfoList;
            foreach (var info in list)
            {
                var distance = EffectiveRange;
                if ((info.Root - transform.position).sqrMagnitude < distance*distance)
                {
                    _NearVecorInfoList.Add(info);
                }
            }
        }

        private Vector3 CalcMoveVector()
        {
            var vec = Vector3.zero;
            var num = 0;
            foreach (var info in _NearVecorInfoList)
            {
                vec += info.MoveVec;
                ++num;
            }
            if (num > 0)
            {
                vec /= num;
            }
            return vec;
        }
    }
}
