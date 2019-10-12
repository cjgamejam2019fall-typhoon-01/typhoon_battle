using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Apps.Earth
{
    public class Earth : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("[Earth] OnTriggerEnter");
        }
    }
}
