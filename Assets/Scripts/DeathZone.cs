using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class DeathZone : MonoBehaviour
    {
        public static event System.Action OnPlayerDeath;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPlayerDeath?.Invoke();

            }
            
        }
    }
}
