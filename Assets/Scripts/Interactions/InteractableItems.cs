using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WeenieWalker
{
    public abstract class InteractableItems : MonoBehaviour, IInteractable
    {

        [SerializeField] List<InteractedItems> interactables = new List<InteractedItems>();

        protected bool _hasBeenTriggered = false;       //for one time use objects
        protected bool _isPlayerInRange = false;        //to store if player is close enough to interact
        private Coroutine _listenForInput;


        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }
        

        public virtual void Interact()
        {
            interactables.ForEach(t => t?.Interact());
            DoOtherInteractionEffects();
        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlayerInRange = true;

                //start coroutine to listen for button press
                if (!_hasBeenTriggered)
                {
                    _listenForInput = StartCoroutine(ListenForButtonPress());
                }
            }
        }

        IEnumerator ListenForButtonPress()
        {
            while (_isPlayerInRange)
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Interact();
                    _hasBeenTriggered = true;
                    StopCoroutine(_listenForInput);
                }

                yield return null;
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlayerInRange = false;
            }
        }

        protected abstract void DoOtherInteractionEffects();

    }
}
