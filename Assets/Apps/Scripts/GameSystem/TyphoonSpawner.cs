using UnityEngine;

namespace Apps.GameSystem
{
    public class TyphoonSpawner : MonoBehaviour
    {
        public Actor.Typhoon.Typhoon Typhoon = null;
        public GameObject TyphoonStackList = null;
        public float InitialSpawnTimer = 5;
        public float NextSpawnTimer = 10;
        public float SpawnTimer = 0;
        public Vector2 ScaleRange = Vector2.one;

        void Start()
        {
            SpawnTimer = InitialSpawnTimer;
        }

        void Update()
        {
            SpawnTimer -= Time.deltaTime;
            if (SpawnTimer <= 0)
            {
                SpawnTimer = NextSpawnTimer;

                var startPos = new Vector3(
                    Random.Range(-100f, 100f),
                    Random.Range(-100f, 100f),
                    Random.Range(-100f, 100f)
                    ) * 300f;
                var hit = new RaycastHit();
                if (Physics.Raycast(startPos, -startPos, out hit))
                {
                    var position = hit.point.normalized * (hit.point.magnitude + 2);
                    var rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    var instance = Instantiate<Actor.Typhoon.Typhoon>(Typhoon, position, rotation);
                    var scale = instance.transform.localScale * Random.Range(ScaleRange.x, ScaleRange.y);
                    instance.transform.localScale = scale;
                    instance.transform.parent = TyphoonStackList.transform;
                }
            }
        }
    }
}
