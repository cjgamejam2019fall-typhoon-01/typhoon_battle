using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.Wind
{
    public class WindSource : MonoBehaviour
    {
        public float EffectiveRange = 100f;
        public float Force = 100f;
        private List<VectorField.VectorField.VectorInfo> _NearVecorInfoList = new List<VectorField.VectorField.VectorInfo>();

        public float Life = 50f;
        public float LifeDescreaseSpeed = 1f;
        [System.NonSerialized]
        public float CurrentLife = 0f;

        private MeshRenderer meshRenderer = null;

        private void Awake()
        {
            CurrentLife = Life;
            meshRenderer = GetComponentInChildren<MeshRenderer>();

            // 近所のベクトルを収集
            var list = ActorManager.Earth.VectorField.VectorInfoList;
            foreach (var info in list)
            {
                var distance = EffectiveRange;
                if ((info.Root - transform.position).sqrMagnitude < distance*distance)
                {
                    _NearVecorInfoList.Add(info);
                }
            }

            // ベクトルを操作
            foreach (var info in _NearVecorInfoList)
            {
                var power = 1f - ((info.Root - transform.position).magnitude / EffectiveRange);
                var force = (info.Root - transform.position).normalized * Force * power;
                var forcedEdge = info.Root + force;
                var candidateEdge = info.Root + (forcedEdge - info.Root).normalized * (Force*power);
                info.AddForce(this, candidateEdge);
            }
        }

        private void Update()
        {
            UpdateLife();
        }

        private void UpdateLife()
        {
            if (CurrentLife > 0)
            {
                CurrentLife -= Time.deltaTime * LifeDescreaseSpeed;
                var lifeRate = CurrentLife / Life;

                var color = meshRenderer.material.color;
                color.a = lifeRate;
                meshRenderer.material.color = color;

                if (CurrentLife <= 0)
                {
                    foreach (var info in _NearVecorInfoList)
                    {
                        info.RemoveForce(this);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
