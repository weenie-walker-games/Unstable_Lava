using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public static event System.Action OnResetLevel;
        public static event System.Action OnMainMenu;

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

        private void Update()
        {
            //use the escape key to bring up the main menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnMainMenu?.Invoke();
            }
        }
    }
}
