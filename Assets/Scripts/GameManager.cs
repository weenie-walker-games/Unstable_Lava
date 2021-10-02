using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public static event System.Action OnResetLevel;

        private void OnEnable()
        {
            DeathZone.OnPlayerDeath += PlayerDeath;
        }

        private void OnDisable()
        {
            DeathZone.OnPlayerDeath -= PlayerDeath;
        }

        private void PlayerDeath()
        {

            OnResetLevel?.Invoke();

        }
    }
}
