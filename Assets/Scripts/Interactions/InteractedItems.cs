using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public abstract class InteractedItems : MonoBehaviour, IInteractable
    {


        public abstract void Interact();
    }
}
