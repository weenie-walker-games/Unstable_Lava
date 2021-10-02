using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Switch : InteractableItems
    {

        public Collider coll;
        [SerializeField] Color _usedColor = Color.black;

        [SerializeField] private Renderer _rend;
        [SerializeField] private Animator _anim;

        private Color _startColor;

        private void Start()
        {
            _startColor = _rend.material.color;
        }

        private void ChangeColor(Color color)
        {
            _rend.material.color = color;
        }

        protected override void DoOtherInteractionEffects()
        {
            _anim.SetTrigger("Interact");
            ChangeColor(_usedColor);

            if(_interactionType == InteractType.Reversible)
            {
                coll.enabled = false;
                coll.enabled = true;
            }
        }
        
        protected override void DoOtherResetEffects()
        {
            _anim.SetTrigger("Interact");
            ChangeColor(_startColor);
        }

    }
}
