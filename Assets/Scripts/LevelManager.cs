using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WeenieWalker
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        public static event System.Action<Transform> OnResetPlayerPosition;

        [SerializeField] List<GameObject> _levels = new List<GameObject>();
        [SerializeField] List<Transform> _startingPositions = new List<Transform>();
        [SerializeField] private int _currentLevel = 0;
        public int CurrentLevel { get { return _currentLevel; } }

        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _lava;

        private void OnEnable()
        {
            GameManager.OnResetLevel += Reset;
            GameManager.OnMainMenu += ShowMainMenu;
            ExitZone.OnPlayerReachExit += EndLevel;

            _player.SetActive(false);
        }

        private void OnDisable()
        {
            GameManager.OnResetLevel -= Reset;
            GameManager.OnMainMenu -= ShowMainMenu;
            ExitZone.OnPlayerReachExit -= EndLevel;
        }

        private void ShowMainMenu()
        {
            MenusClosed(false);
        }

        public void ResumeGame()
        {
            MenusClosed(true);
        }

        private void MenusClosed(bool isMenuDisabled)
        {
            _player.SetActive(isMenuDisabled);
            _levels[_currentLevel].SetActive(isMenuDisabled);
            _lava.SetActive(isMenuDisabled);
        }

        private void EndLevel()
        {
            MenusClosed(false);
        }

        private void Start()
        {

        }

        private void BeginLevel()
        {
            MenusClosed(true);
            Reset();
        }

        private void Reset()
        {
            //Tell player to go back to start position
            OnResetPlayerPosition?.Invoke(_startingPositions[_currentLevel]);
        }

        public void LevelSelected(int levelNum)
        {
            _levels.ForEach(t => t.SetActive(false));
            _currentLevel = levelNum;
            BeginLevel(); 
        }
    }
}
