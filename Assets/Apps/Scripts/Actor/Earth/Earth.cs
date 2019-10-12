using UnityEngine;

namespace Apps.Actor.Earth
{
    public class Earth : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("[Earth] OnTriggerEnter");
        }
    }
}
