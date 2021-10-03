using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class EnableDropper : MonoBehaviour
    {
        [SerializeField] private GroundDropper _dropperScript;
        [SerializeField] private bool _isGoingToUseDropper = false;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("isgoing " + _isGoingToUseDropper);
                _dropperScript.enabled = _isGoingToUseDropper;
            }
        }
    }
}
