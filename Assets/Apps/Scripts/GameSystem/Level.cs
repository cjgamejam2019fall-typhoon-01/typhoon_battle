using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.GameSystem
{
    public class Level : MonoBehaviour
    {
        public List<Actor.City.City> TargetCities = new List<Actor.City.City>();
        [Range(1, 7)]
        public uint MaxWindSlotNum = 7;

        private void Awake()
        {
            GameManager.Level = this;
        }

        void Start()
        {
            var cities = Actor.ActorManager.CityList.Cities;
            foreach (var city in cities)
            {
                // [TEST]
                if (city.Code == Actor.City.CityCode.Tokyo)
                {
                    SetTarget(city);
                    break;
                }
            }
        }

        public void SetTarget(Actor.City.City target)
        {
            foreach (var city in TargetCities)
            {
                if (city == target) return;
            }

            TargetCities.Add(target);
            target.SetTarget(true);
        }

        public void BreakTarget(Actor.City.City target)
        {
            foreach (var city in TargetCities)
            {
                if (city == target)
                {
                    TargetCities.Remove(city);
                    break;
                }
            }
        }

        void Update()
        {
        }
    }
}
