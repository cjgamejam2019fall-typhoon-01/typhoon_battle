using UnityEngine;

namespace Apps.Actor.Typhoon
{
    public class TyphoonGenerator : Controller.TapController
    {
        public GameObject TyphoonObject = null;
        public GameObject ParentTyphoonList = null;

        protected override void OnTap(RaycastHit hit)
        {
            var position = hit.point.normalized * (hit.point.magnitude + 2f);
            var rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            var instance = Instantiate<GameObject>(TyphoonObject, position, rotation);
            instance.transform.parent = ParentTyphoonList.transform;
            var scale = Random.Range(2f, 3f);
            instance.transform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
