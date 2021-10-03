using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Door : InteractedItems
    {


        [SerializeField] private Animator _anim;
        private bool _isOpen = false;

        public override void Interact()
        {
            _anim.SetTrigger("Interact");

            PlayAudio();

            _isOpen = !_isOpen;
        }

        public override void Reset()
        {
            if (_isOpen)
            {
                _anim.SetTrigger("Interact");
                _isOpen = false;
            }
        }
    }
}
