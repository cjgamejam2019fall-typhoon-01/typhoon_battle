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

        private MeshRenderer _MeshRenderer = null;

        private void Awake()
        {
            _MeshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetMeshRendererEnable(bool flag)
        {
            _MeshRenderer.enabled = flag;
        }

        void Start()
        {
            SetMeshRendererEnable(false);
        }

        void Update()
        {
        }
    }
}
