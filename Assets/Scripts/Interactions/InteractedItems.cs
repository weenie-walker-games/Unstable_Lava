using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public abstract class InteractedItems : MonoBehaviour, IInteractable
    {
        [SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClip _clip;

        protected virtual void OnEnable()
        {
            GameManager.OnResetLevel += Reset;
        }

        protected virtual void OnDisable()
        {
            GameManager.OnResetLevel -= Reset;
        }

        protected bool _hasBeenTriggered = false;       //for one time use objects

        public abstract void Interact();

        public abstract void Reset();


        protected void PlayAudio()
        {
            if (_clip != null && _audioSource != null)
                _audioSource.PlayOneShot(_clip);
        }
    }
}
