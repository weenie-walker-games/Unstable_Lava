using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class ExitZone : MonoBehaviour
    {

        public static event System.Action OnPlayerReachExit;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPlayerReachExit?.Invoke();
                Debug.Log("Player reached exit");
            }

        }
    }
}
