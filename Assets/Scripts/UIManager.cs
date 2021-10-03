using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System;

namespace WeenieWalker
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private TMP_Text _treasureScoreBox;
        private int _treasureScore = 0;

        [SerializeField] private GameObject _levelSelectCanvas;
        [SerializeField] private GameObject _mainMenu;

        private void OnEnable()
        {
            TreasureChest.OnTreasureChestOpen += UpdateScore;
            GameManager.OnMainMenu += ShowMainMenu;
        }

        private void OnDisable()
        {
            TreasureChest.OnTreasureChestOpen -= UpdateScore;
            GameManager.OnMainMenu -= ShowMainMenu;
        }

        private void ShowMainMenu()
        {
            _mainMenu.SetActive(true);
        }



        private void Start()
        {
            UpdateScore(0);
            _levelSelectCanvas.SetActive(true);
        }

        private void UpdateScore(int addToAmount)
        {
            _treasureScore += addToAmount;
            _treasureScoreBox.text = _treasureScore.ToString();
        }

        public void QuitGame()
        {
            Debug.Log("Qutting");
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
