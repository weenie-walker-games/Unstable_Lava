using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class TreasureChest : InteractedItems
    {
        public static event System.Action<int> OnTreasureChestOpen;

        [SerializeField] private Animator _anim;
        [SerializeField] private int _treasureValue = 10;

        public override void Interact()
        {
            _anim.SetTrigger("Interact");
            OnTreasureChestOpen?.Invoke(_treasureValue);
        }

        public override void Reset()
        {
            //Does not reset
        }
    }
}
