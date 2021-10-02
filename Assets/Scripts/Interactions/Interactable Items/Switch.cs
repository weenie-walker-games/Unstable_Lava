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

        private Color _startColor;
        private bool _isActive = false;

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
            _isActive = !_isActive;
            _anim.SetTrigger("Interact");
            Color toColor = _isActive ?  _usedColor : _startColor;
            ChangeColor(toColor);


        }
        
        protected override void DoOtherResetEffects()
        {
            _anim.SetTrigger("Interact");
            ChangeColor(_startColor);
        }

    }
}
