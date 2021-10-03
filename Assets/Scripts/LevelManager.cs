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

            _player.SetActive(false);
        }

        private void OnDisable()
        {
            GameManager.OnResetLevel -= Reset;
            GameManager.OnMainMenu -= ShowMainMenu;
        }

        private void ShowMainMenu()
        {
            _player.SetActive(false);
            _levels[_currentLevel].SetActive(false);
            _lava.SetActive(false);
        }

        public void ResumeGame()
        {
            _player.SetActive(true);
            _levels[_currentLevel].SetActive(true);
            _lava.SetActive(true);
        }

        private void Start()
        {

        }

        private void BeginLevel()
        {
            _player.SetActive(true);
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
            _levels[levelNum].SetActive(true);
            _currentLevel = levelNum;
            BeginLevel(); 
        }
    }
}
