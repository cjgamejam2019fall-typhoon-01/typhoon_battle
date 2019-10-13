using System;
using System.Linq;
using UnityEngine;

namespace Apps.GameSystem
{
    public class CityRequester : MonoBehaviour
    {
        public float InitialRequestTimer = 0;
        public float NextRequestTimer = 10;
        public float RequestTimer = 0;

        private System.Random random = new System.Random();

        void Start()
        {
            RequestTimer = InitialRequestTimer;
        }

        void Update()
        {
            RequestTimer -= Time.deltaTime;
            if (RequestTimer <= 0)
            {
                RequestTimer = NextRequestTimer;

                var targetCity = GetNextCity();
                if (targetCity != null)
                {
                    GameManager.Level.SetTarget(targetCity);
                }
            }
        }

        private Actor.City.City GetNextCity()
        {
            var n = 0;
            while (true)
            {
                if (n > 16)
                {
                    return null;
                }

                var cityCode = GetNextCityCode();
                if (cityCode == Actor.City.CityCode.Unknown)
                {
                    ++n;
                    continue;
                }
                var cities = Actor.ActorManager.CityList.Cities;
                foreach (var city in cities)
                {
                    if (city.Code == cityCode)
                    {
                        if (city.IsTarget)
                        {
                            ++n;
                            continue;
                        }
                        else
                        {
                            return city;
                        }
                    }
                }
                ++n;
                continue;
            }
        }

        private Actor.City.CityCode GetNextCityCode()
        {
            return Enum.GetValues(typeof(Actor.City.CityCode))
                .Cast<Actor.City.CityCode>()
                .OrderBy(c => random.Next())
                .FirstOrDefault();
        }
    }
}
