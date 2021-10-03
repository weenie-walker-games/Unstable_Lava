using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WeenieWalker
{
    public class GameStart : MonoBehaviour
    {

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            Invoke("NewScene", 4f);

        }

        private void NewScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
