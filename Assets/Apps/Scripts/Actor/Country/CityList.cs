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

            var cities = GetComponentsInChildren<City>();
            Cities.AddRange(cities);
        }

        void Start()
        {
        }

        void Update()
        {
        }
    }
}
