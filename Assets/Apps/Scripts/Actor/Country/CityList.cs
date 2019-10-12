using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.Actor.City
{
    public class CityList : MonoBehaviour
    {
        public List<City> Cities = new List<City>();

        private void Awake()
        {
            ActorManager.CityList = this;
        }

        void Start()
        {
            var cities = GetComponentsInChildren<City>();
            Cities.AddRange(cities);
        }

        void Update()
        {
        }
    }
}
