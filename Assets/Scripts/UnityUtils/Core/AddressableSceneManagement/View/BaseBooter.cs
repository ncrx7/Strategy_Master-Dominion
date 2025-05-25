using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UnityUtils.SceneManagement.Views
{
    public class BaseBooter : MonoBehaviour
    {
        private void Start()
        {
            InitGame();
        }
        
        protected virtual void InitGame() { }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static async void InitBootScene()
        {
            if (SceneManager.GetActiveScene().name != "BootScene")
            {
                Debug.Log("Booting game..");
                await SceneManager.LoadSceneAsync("BootScene", LoadSceneMode.Single);
            }
            else
            {
                Debug.LogWarning("BootScene is already the active scene. Skipping load boot scene.");
            }
        }
    }
}
