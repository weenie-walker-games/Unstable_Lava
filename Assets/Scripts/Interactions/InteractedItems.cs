using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public abstract class InteractedItems : MonoBehaviour, IInteractable
    {

        protected bool _hasBeenTriggered = false;       //for one time use objects

        public abstract void Interact();

        public abstract void Reset();
    }
}
