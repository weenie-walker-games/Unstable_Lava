using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class PressurePlate : InteractableItems
    {
        [SerializeField] Color _usedColor = Color.black;

        [SerializeField] private Renderer _rend;

        private Color _startColor;

        private void Start()
        {
            _startColor = _rend.material.color;
        }

        protected override void DoOtherInteractionEffects()
        {

            Color toColor = _isUsedDuringReversible ? _startColor : _usedColor;
            ChangeColor(toColor);
        }

        protected override void DoOtherResetEffects()
        {
            ChangeColor(_startColor);
        }

        private void ChangeColor(Color color)
        {
            _rend.material.color = color;
        }

    }
}
