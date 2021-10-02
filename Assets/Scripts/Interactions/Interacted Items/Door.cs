using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Door : InteractedItems
    {

        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public override void Interact()
        {
            try
            {
                _anim.SetTrigger("Open");
            }
            catch
            {
                Debug.LogError($"{this.name} does not have an animator component.");
            }
        }

    }
}
