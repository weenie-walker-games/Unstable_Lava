using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Switch : InteractableItems
    {
        [SerializeField] private Material _startColor;
        [SerializeField] private Material _usedColor;

        [SerializeField] private Renderer _rend;
        [SerializeField] private Animator _anim;


        private bool _isActive = false;

        private void Start()
        {
            _rend.material = _startColor;
        }

        private void ChangeMaterial(Material mat)
        {
            _rend.material = mat;
        }

        protected override void DoOtherInteractionEffects()
        {
            _isActive = !_isActive;
            PlayAudio();
            _anim.SetTrigger("Interact");
            Material toMat = _isActive ?  _usedColor : _startColor;
            ChangeMaterial(toMat);


        }
        
        protected override void DoOtherResetEffects()
        {
            _anim.SetTrigger("Interact");
            ChangeMaterial(_startColor);
            _isActive = false;
        }

    }
}
