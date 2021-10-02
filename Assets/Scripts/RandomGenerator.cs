using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class RandomGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _groundPrefab;
        [SerializeField] private Vector2 _groundDimensions;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            //Generate random level
            for (int i = 0; i < _groundDimensions.x; i++)
            {
                for (int j = 0; j < _groundDimensions.y; j++)
                {
                    Instantiate(_groundPrefab, new Vector3(i, 0, j), Quaternion.identity, this.transform);
                }
            }
        }
    }
}
