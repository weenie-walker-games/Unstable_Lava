using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Door : InteractedItems
    {

        [SerializeField] private Animator _anim;


        public override void Interact()
        {
            _anim.SetTrigger("Interact");
        }

        public override void Reset()
        {
            _anim.SetTrigger("Interact");
        }
    }
}
