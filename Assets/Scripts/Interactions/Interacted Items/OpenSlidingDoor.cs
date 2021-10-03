using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class OpenSlidingDoor : Door
    {

        protected override void OnEnable()
        {
            //Start with this door open
            Interact();
        }


    }
}
