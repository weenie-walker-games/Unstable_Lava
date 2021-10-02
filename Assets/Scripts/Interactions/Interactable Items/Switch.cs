using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Switch : InteractableItems
    {


        [SerializeField] Color _usedColor = Color.black;

        [SerializeField] private Renderer _rend;
        [SerializeField] private Animator _anim;

        protected override void DoOtherInteractionEffects()
        {
            _anim.SetTrigger("Interact");
        }

        public void ChangeColor()
        {
            _rend.material.color = _usedColor;
        }

    }
}
