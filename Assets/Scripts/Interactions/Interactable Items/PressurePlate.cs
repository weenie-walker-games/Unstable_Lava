using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class PressurePlate : InteractableItems
    {
        [SerializeField] private Material _startColor;
        [SerializeField] private Material _usedColor;

        [SerializeField] private Renderer _rend;

        private bool _isActive = false;

        private void Start()
        {
            _rend.material = _startColor;
        }

        protected override void DoOtherInteractionEffects()
        {
            _isActive = !_isActive;
            Material toMat = _isActive ? _usedColor : _startColor;
            ChangeMaterial(toMat);
        }

        protected override void DoOtherResetEffects()
        {
            ChangeMaterial(_startColor);
        }

        private void ChangeMaterial(Material mat)
        {
            _rend.material = mat;
        }

    }
}
