using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class PressurePlate : InteractableItems
    {
        [SerializeField] Color _usedColor = Color.black;

        private Renderer _rend;

        private void Start()
        {
            _rend = GetComponent<Renderer>();
        }

        protected override void DoOtherInteractionEffects()
        {
            try
            {
                _rend.material.color = _usedColor;
            }
            catch
            {
                Debug.LogError($"There is no Renderer component assigned for {this.name}");
            }
        }

    }
}
