using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.Typhoon
{
    public class Typhoon : MonoBehaviour
    {
        public Vector2 PowerRange = Vector2.one * 900f;
        private Vector3 InitialLocalScale = Vector3.one;
        [System.NonSerialized]
        public float Power = 900f;
        private float InitialPower = 900f;
        public float PowerRatio = 1f;
        public float EffectiveRange = 50f;
        public float MoveSpeedRatio = 1f;
        public float TargetCheckRadius = 10000f;
        public Vector2 ScaleShrinkRatioRange = Vector2.one;
        private float ScaleShrinkRatio = 1.0f;
        private List<VectorField.VectorField.VectorInfo> _NearVecorInfoList = new List<VectorField.VectorField.VectorInfo>();

        private void Awake()
        {
            GatherNearVectorInfo();
            InitialPower = Power = Random.Range(PowerRange.x, PowerRange.y);
            ScaleShrinkRatio = Random.Range(ScaleShrinkRatioRange.x, ScaleShrinkRatioRange.y);
        }

        private void Start()
        {
            InitialLocalScale = transform.localScale;
        }

        private void Update()
        {
            // 周囲のベクトルを収集
            GatherNearVectorInfo();
            var vec = CalcMoveVector();
            var rayStart = transform.position + vec * Time.deltaTime * MoveSpeedRatio;

            // ベクトルに合わせて移動
            var hit = new RaycastHit();
            if (Physics.Raycast(rayStart, -rayStart, out hit))
            {
                var position = hit.point.normalized * (hit.point.magnitude + 2f);
                var rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                transform.position = position;
                transform.rotation = rotation;
            }

            // 縮小
            Power = Mathf.Max(Power - Time.deltaTime * ScaleShrinkRatio, 0);
            var scaleRate = Power / InitialPower;
            transform.localScale = InitialLocalScale * scaleRate;
            if (Power <= 0)
            {
                Destroy(gameObject);
            }

            // ターゲット判定
#if UNITY_EDITOR
            if (GameSystem.GameManager.Level == null)
            {
                return;
            }
#endif
            var targetCities = GameSystem.GameManager.Level.TargetCities;
            foreach (var city in targetCities)
            {
                if ((city.transform.position - transform.position).magnitude < TargetCheckRadius * transform.localScale.x)
                {
                    city.EatDamage(Time.deltaTime * Power * PowerRatio);
                }
            }
        }

        private void LateUpdate()
        {
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
