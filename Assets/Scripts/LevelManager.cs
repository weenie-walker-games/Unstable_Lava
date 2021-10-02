using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        public static event System.Action<Transform> OnResetPlayerPosition;

        [SerializeField] List<Transform> _startingPositions = new List<Transform>();
        [SerializeField] private int _currentLevel = 0;
        public int CurrentLevel { get { return _currentLevel; } }

        private void OnEnable()
        {
            GameManager.OnResetLevel += Reset;
        }

        private void OnDisable()
        {
            GameManager.OnResetLevel -= Reset;
        }

        private void Start()
        {
            BeginLevel();
        }

        private void BeginLevel()
        {
            Reset();
        }

        private void Reset()
        {
            //Tell player to go back to start position
            OnResetPlayerPosition?.Invoke(_startingPositions[_currentLevel]);
        }


    }
}
