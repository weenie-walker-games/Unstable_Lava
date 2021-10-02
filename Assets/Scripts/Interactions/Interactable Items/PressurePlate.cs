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

            _rend.material.color = _usedColor;
        }

        protected override void DoOtherResetEffects()
        {
            _rend.material.color = _startColor;
        }

    }
}
