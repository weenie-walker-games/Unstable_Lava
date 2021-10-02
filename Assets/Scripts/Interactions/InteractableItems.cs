using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WeenieWalker
{
    public abstract class InteractableItems : MonoBehaviour, IInteractable
    {

        [SerializeField] protected List<InteractedItems> interactables = new List<InteractedItems>();
        [SerializeField] protected InteractType _interactionType;
        [SerializeField] protected float _timerCooldown = 5f;

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

            //Setup what to do next
            switch (_interactionType)
            {
                case InteractType.SingleUse:
                    _hasBeenTriggered = true;
                    break;
                case InteractType.Timed:
                    Invoke("Reset", _timerCooldown);
                    break;
                case InteractType.Reversible:
                    //Reset the input listener
                    _hasBeenTriggered = false;
                    //StartListening();
                    break;
                default:
                    break;
            }
        }

        public virtual void Reset()
        {
            interactables.ForEach(t => t?.Interact());
            _hasBeenTriggered = false;
            DoOtherResetEffects();
        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isPlayerInRange = true;
                StartListening();

            }
        }

        private void StartListening()
        {
            if (_isPlayerInRange)
            {
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
        protected abstract void DoOtherResetEffects();

    }
}
