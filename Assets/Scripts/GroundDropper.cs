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
        [SerializeField] private Animator _anim;

        [Tooltip("Use this to identify how far down the block will fall")]
        [SerializeField] private float _dropAmount = 4f;

        private float _selectedTiming;
        private WaitForSeconds _yieldWait;
        private Vector3 startPos;
        public  bool _isPlayerIn = false;

        private void OnEnable()
        {
            GameManager.OnResetLevel += Reset;

        }

        private void OnDisable()
        {
            GameManager.OnResetLevel -= Reset;
        }

        private void Start()
        {
            startPos = this.transform.position;
        }

        private void RandomizeDropTime()
        {
            _selectedTiming = Random.Range(0, _timingRange);
            _yieldWait = new WaitForSeconds(_groundDefaultDropAmount + _selectedTiming);
            Invoke("StartAnimation", _groundDefaultDropAmount + _selectedTiming);
        }

        private void StartAnimation()
        {
            _anim.SetBool("Shake", true);
        }



        /// <summary>
        /// Called via the animation
        /// </summary>
        public void Drop()
        {
            transform.Translate(Vector3.down * _dropAmount);
        }

        private void Reset()
        {
            transform.position = startPos;
            _anim.SetBool("Shake", false);
            _anim.SetTrigger("Reset");
            _isPlayerIn = false;
            
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.CompareTag("Player"))
            {

                if (!_isPlayerIn)
                {

                    _isPlayerIn = true;
                    RandomizeDropTime();
                }
            }
        }


    }
}
