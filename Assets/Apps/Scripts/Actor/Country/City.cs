using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.City
{
    public enum CityCode
    {
        Unknown,

        London,
        Newyork,
        Paris,
        Tokyo,
        HongKong,
        Singapore,
    }

    public class City : MonoBehaviour
    {
        public CityCode Code = CityCode.Unknown;
        public string Name = "";

        public bool IsTarget = false;
        private MeshRenderer _MeshRenderer = null;

        public float Health = 100f;
        public float MaxHealth = 100f;

        private void Awake()
        {
            MaxHealth = Health;
            _MeshRenderer = GetComponent<MeshRenderer>();
            SetTarget(false);
        }

        private void SetMeshRendererEnable(bool flag)
        {
            _MeshRenderer.enabled = flag;
        }

        public void SetTarget(bool flag)
        {
            IsTarget = flag;
            SetMeshRendererEnable(flag);
        }

        public void EatDamage(float damage)
        {
            if (Health > 0)
            {
                Health = Mathf.Max(Health - damage, 0);
            }
        }


        void Start()
        {
        }

        void Update()
        {
            if (Health <= 0)
            {
                GameSystem.GameManager.Level.BreakTarget(this);
                SetTarget(false);
            }
        }
    }
}
