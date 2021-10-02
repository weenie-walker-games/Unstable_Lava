using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class GroundDropper : MonoBehaviour
    {
        [SerializeField] private float _groundDefaultDropAmount = 30f;
        public float GroundDefaultDropAmount { get { return _groundDefaultDropAmount; } }

        [Tooltip("Select a higher end to the random drop timing variable. This will be the random amount that will be added to the default value before dropping the ground piece.")]
        [Range(0, 20)]
        [SerializeField] private float _timingRange;
        [SerializeField] 

        private float _selectedTiming;
        private WaitForSeconds _yieldWait;

        private void OnEnable()
        {
            _selectedTiming = Random.Range(0, _timingRange);
            _yieldWait = new WaitForSeconds(_groundDefaultDropAmount + _selectedTiming);
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            StartCoroutine(DropRoutine()); 
        }

        IEnumerator DropRoutine()
        {

            yield return _yieldWait;

            //Drop
            transform.Translate(Vector3.down * 4);
        }


    }
}
